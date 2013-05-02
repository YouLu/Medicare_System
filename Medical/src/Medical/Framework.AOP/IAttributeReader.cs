/*
 * 作者:李博
 * 日期:2009.3.10
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace Medical.Framework.AOP
{
    #region 特性读取接口
    public interface IAttributeReader
    {
        Type GetEntityType();
        string GetSql();
        MethodInfo MethodInfo { get; set; }

    }
    #endregion
}
