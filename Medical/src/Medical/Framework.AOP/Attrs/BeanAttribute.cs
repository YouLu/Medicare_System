/*
 * 作者:李博
 * 日期:2009.3.10
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Medical.Framework.AOP.Attrs
{
    #region 解析Entity属性信息
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class BeanAttribute : Attribute
    {
        private Type _beanType;

        public BeanAttribute(Type beanType)
        {
            _beanType = beanType;
        }

        public Type BeanType
        {
            get { return _beanType; }
        }
    }
    #endregion
}
