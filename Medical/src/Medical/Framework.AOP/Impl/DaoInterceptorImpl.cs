/*
 * 作者:李博
 * 日期:2009.3.26
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Medical.Framework.AOP;
using Castle.DynamicProxy;
using Medical.Framework.AOP.ClassManager;
using System.Collections;
using Medical.Framework.AOP.AopUtil;
using Medical.Framework.Exception;

namespace Medical.Framework.AOP.Impl
{
    public sealed class DaoInterceptorImpl : IDaoInterceptor
    {

        #region  初始化 log4net
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region IDaoInterceptor メンバ

        public object Invorke(IAttributeReader attributeReader, params object[] methodParams)
        {
            IDbHelper dbHelper = AopClassManager.GreateDbHelper(attributeReader, methodParams);
            string newSql = dbHelper.SqlAnalysis();//解析后的sql语句
            object result = dbHelper.SqlExcute(newSql);//数据库查询结果

            if ((result.GetType()).Equals(typeof(ArrayList)))
            {
                if (dbHelper.DaoReturnType.IsInterface)
                {
                    return result;
                }
                else if (dbHelper.DaoReturnType.IsArray)
                {
                    ArrayList list = (ArrayList)result;
                    Array resultArray = Array.CreateInstance(dbHelper.EntityType, ((IList)result).Count);
                    list.CopyTo(resultArray);
                    return resultArray;
                }
                else if (dbHelper.DaoReturnType.IsClass)
                {
                    ArrayList list = (ArrayList)result;
                    return list[0];
                }
                else
                {
                    //方法返回类型定义错误
                    log.Debug("方法返回类型定义错误");
                    throw new MethodReturnTypeException(dbHelper.DaoReturnType.Name);
                }
            }
            else //返回值为int的情况
            {
                return result;
            }
        }

        #endregion

        #region IInterceptor メンバ

        public object Intercept(IInvocation invocation, params object[] methodParams)
        {
            IAttributeReader attributeReader = AopClassManager.GreateAttributeReader(invocation);
            #region 判定拦截方法是否为抽象方法
            MethodInfo methodInfo = invocation.Method;
            if (!methodInfo.IsAbstract && !methodInfo.IsVirtual)
            {
                return invocation.Proceed(methodParams);//调用最初的执行方法
            }
            #endregion
            return Invorke(attributeReader, methodParams);
        }

        #endregion
    }
}
