/*
 * 作者:李博
 * 日期:2009.3.10
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Medical.Framework.AOP.Attrs;

namespace Medical.Framework.AOP.AopUtil
{
    public class AttributeUtil
    {
        public AttributeUtil()
        {

        }

        public BeanAttribute GetBeanAttribute(Type type)
        {
            return Attribute.GetCustomAttribute(type,
                                                typeof(BeanAttribute)) as BeanAttribute;
        }

        public SqlAttribute GetSqlAttributes(MethodInfo mi)
        {
            return Attribute.GetCustomAttribute(mi,
                                                 typeof(SqlAttribute)) as SqlAttribute;
        }

        public SqlFileAttribute GetSqlFileAttribute(MethodInfo mi)
        {
            return Attribute.GetCustomAttribute(mi, typeof(SqlFileAttribute)) as SqlFileAttribute;
        }
    }
}
