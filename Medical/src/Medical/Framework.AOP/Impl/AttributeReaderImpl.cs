/*
 * 作者:李博
 * 日期:2009.3.28
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.AOP;
using Medical.Framework.AOP.Attrs;
using System.Reflection;
using Castle.DynamicProxy;
using Medical.Framework.AOP.ClassManager;
using System.IO;
using Medical.Framework.Exception;

namespace Medical.Framework.AOP.Impl
{
    public sealed class AttributeReaderImpl : IAttributeReader
    {
        private IInvocation _invocation;
        private MethodInfo methodInfo;

        public MethodInfo MethodInfo
        {
            get
            {
                return methodInfo;
            }
            set
            {
                methodInfo = value;
            }
        }


        public AttributeReaderImpl(IInvocation invocation)
        {
            _invocation = invocation;
            methodInfo = invocation.Method;

        }

        #region  初始化 log4net
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        //得到entity的特性信息
        public Type GetEntityType()
        {
            BeanAttribute beanAttribute
               = AopClassManager.CreateAttributeUtil().GetBeanAttribute(_invocation.InvocationTarget.GetType());
            if (beanAttribute != null)
            {
                return beanAttribute.BeanType;
            }
            else
            {
                //找不到指定的entity
                log.Debug("找不到指定的entity");
                throw new EntityNotFoundException();
            }
        }

        //得到sql语句
        public string GetSql()
        {
            SqlAttribute sqlAttribute
               = AopClassManager.CreateAttributeUtil().GetSqlAttributes(_invocation.Method);
            if (sqlAttribute != null)
            {
                return sqlAttribute.Sql;
            }
            else
            {
                return GetSqlFromSqlFile();
            }

        }

        //从sqlFile中读取sql语句
        private string GetSqlFromSqlFile()
        {
            SqlFileAttribute sqlFileAttribute
                = AopClassManager.CreateAttributeUtil().GetSqlFileAttribute(_invocation.Method);
            if (sqlFileAttribute != null)
            {
                string sqlFilePath = sqlFileAttribute.FileName;
                Type baseType = _invocation.InvocationTarget.GetType().BaseType;
                Assembly daoAssembly = baseType.Assembly;
                if (AopClassManager.GreateResourceUtil().IsExist(sqlFilePath, daoAssembly))
                {
                    return ReadText(sqlFilePath, daoAssembly);
                }
                else
                {
                    //资源文件不存在
                    log.Debug("资源文件不存在");
                    throw new SourceNotFoundException(sqlFilePath);
                }
            }
            else
            {
                //找不到sql或sqlFile
                log.Debug("找不到sql或sqlFile");
                throw new ReadAttributeException();
            }
        }

        #region 读文件
        public string ReadText(string sqlPath, System.Reflection.Assembly asm)
        {
            using (Stream stream = AopClassManager.GreateResourceUtil().GetResourceAsStream(sqlPath, asm))
            {
                using (TextReader reader = new StreamReader(stream, Encoding.GetEncoding(Encoding.Default.WebName)))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        #endregion
    }
}
