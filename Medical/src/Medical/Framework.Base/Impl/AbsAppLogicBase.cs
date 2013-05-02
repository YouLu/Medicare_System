/*
 * 作者：吕游
 * 时间：2009-3-30
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Util;
using Medical.Framework.Container;
using Medical.Framework.Container.Util;
using Medical.Framework.Container.Factory;
using Medical.Framework.Base;
using System.Data;
using System.Reflection;
using Castle.ActiveRecord;
using Medical.Framework.Exception;

namespace Medical.Framework.Base.Impl
{
    public abstract class AbsAppLogicBase : IAppLogicBase
    {
        #region  初始化 log4net
        /// <summary>
        /// 初始化 log4net
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region 处理AppLogic层与Business层之间的一对多关系
        /// <summary>
        /// 处理AppLogic层与Business层之间的一对多关系
        /// </summary>
        /// <param name="appParam">系统参数类</param>
        /// <param name="appLogicBase">AppLogic层的一个实例</param>
        /// <returns>client端需要的数据</returns>
        
        public AppParam DoService(AppParam appParam, AbsAppLogicBase appLogicBase)
        {
            ISingletonContainer container = SingletonContainerFactory.Container;
            Type type = appLogicBase.GetType();
            string name = appParam.RequestClass;  //得到请求地址
            string methodName = ((RequestUtil)container.GetObject(name)).Method;
            MethodInfo method = type.GetMethod(methodName);
            AppParam retParam = (AppParam)method.Invoke(appLogicBase, new Object[] { appParam });
            return retParam;
       
        }

        #endregion

        #region 创建Business层的实例
        /// <summary>
        /// 创建Business层的实例
        /// </summary>
        /// <param name="bizType">需要创建的实例类型</param>
        /// <returns>业务逻辑的实例</returns>
        public IBizBase CreateBizInstance(Type bizType)
        {
            IBizBase iBizBase = null;
            AppParam ret = null;
            Assembly ass = Assembly.Load(bizType.Namespace);
            Object obj = ass.CreateInstance(bizType.ToString());
            Type bizBaseType = typeof(AbsBizBase);
            if (bizBaseType.IsInstanceOfType(obj))
            {
                iBizBase = obj as IBizBase;
            }
            else
            {
                log.Info("create Business instance failed");
                throw new FlowException(bizType.ToString());
            }
            return iBizBase;
        }

        #endregion

        #region 暴露给WebService的方法,此处提供一些前后处理与事务功能
        /// <summary>
        /// 暴露给WebService的方法,此处提供一些前后处理与事务功能
        /// </summary>
        /// <param name="appParam">client端传递给server端处理的数据封装类</param>
        /// <param name="appLogicBase">AppLogic的一个实例</param>
        /// <returns>client端需要的数据的参数封装类</returns>

        public AppParam DoApplication(AppParam appParam, AbsAppLogicBase appLogicBase)
        {
            AppParam ret = null;
            using (TransactionScope scope = new TransactionScope(TransactionMode.Inherits))
            {
                try
                {

                    ret = DoService(appParam, appLogicBase);
                    scope.VoteCommit();
                    return ret;
                }
                catch (AppException e)
                {
                    log.Debug(e.FullMessage);
                    scope.VoteRollBack();
                    throw e;
                }
                catch (SysException ex)
                {
                    log.Debug(ex.StackTrace);
                    scope.VoteRollBack();
                    throw ex;
                }
                catch (System.Exception ex1)
                {
                    log.Debug(ex1.StackTrace);
                    scope.VoteRollBack();
                    throw ex1;
                }
            }

        }
 



        #endregion
    }
}
