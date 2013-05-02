/*
 * 作者:李博
 * 日期:2009.3.10
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using System.Reflection;
using Medical.Framework.AOP.AopUtil;
using Medical.Framework.ADO;

namespace Medical.Framework.AOP
{
    #region 拦截器接口
    public interface IDaoInterceptor : IInterceptor
    {
        Object Invorke(IAttributeReader attributeReader, params object[] args);
    }
    #endregion
}
