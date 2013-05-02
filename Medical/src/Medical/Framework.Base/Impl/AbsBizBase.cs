/*
 * 作者:李博
 * 日期:2009.4.10
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Util;
using System.Data;
using Medical.Framework.AOP;
using Medical.Framework.AOP.Impl;
using Castle.DynamicProxy;
namespace Medical.Framework.Base.Impl
{
    public abstract class AbsBizBase : IBizBase
    {
        #region 动态生成Dao代理的实例

        /// <summary>
        /// 动态生成Dao代理的实例
        /// </summary>
        /// <typeparam name="DaoType">需要的Dao层的实例类型</typeparam>
        /// <returns>Dao层代理的实例</returns>
        public DaoType CreateDaoInstance<DaoType>()
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            IDaoInterceptor interceptor = new DaoInterceptorImpl();
            return (DaoType)proxyGenerator.CreateClassProxy(typeof(DaoType),
                                                            interceptor,
                                                            false);
        }

        #endregion

        #region 动态生成Dao代理的实例

        /// <summary>
        /// 动态生成Dao代理的实例
        /// </summary>
        /// <typeparam name="DaoType">需要的Dao层的实例类型</typeparam>
        /// <returns>Dao层代理的实例</returns>
        public BaseDao CreateDaoInstance(Type typeOfDao)
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            IDaoInterceptor interceptor = new DaoInterceptorImpl();
            return (BaseDao)proxyGenerator.CreateClassProxy(typeOfDao,
                                                            interceptor,
                                                            false);
        }
        #endregion

    }
}
