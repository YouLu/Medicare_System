/*
 * 作者:李博
 * 日期:2009.3.10
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.AOP.AopUtil;
using Medical.Framework.AOP;
using Medical.Framework.AOP.Impl;
using Castle.DynamicProxy;
using System.Reflection;

namespace Medical.Framework.AOP.ClassManager
{
    public class AopClassManager
    {

        public static IDbHelper GreateDbHelper(IAttributeReader attributeReader, params object[] methodParams)
        {
            return new DbHelperImpl(attributeReader, methodParams);
        }


        public static IAttributeReader GreateAttributeReader(IInvocation invocation)
        {
            return new AttributeReaderImpl(invocation);
        }


        public static AttributeUtil CreateAttributeUtil()
        {
            return new AttributeUtil();
        }

        public static ResourceUtil GreateResourceUtil()
        {
            return new ResourceUtil();
        }


    }
}
