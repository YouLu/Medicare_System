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
    #region 解析SqlFile特性信息
    [AttributeUsage(AttributeTargets.Method)]
    public class SqlFileAttribute : Attribute
    {
        private string _fileName;

        public SqlFileAttribute()
        {
        }

        public SqlFileAttribute(string fileName)
        {
            _fileName = fileName;
        }

        public string FileName
        {
            get { return _fileName; }
        }
    }
    #endregion
}
