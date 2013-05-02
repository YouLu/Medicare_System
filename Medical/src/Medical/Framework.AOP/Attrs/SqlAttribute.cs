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
    #region 解析Sql文信息
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SqlAttribute : Attribute
    {
        private string _sql;

        public SqlAttribute(string sql)
        {
            _sql = sql;
        }

        public string Sql
        {
            get { return _sql; }
        }
    }
    #endregion
}
