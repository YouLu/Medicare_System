/*
 * 作者:李博
 * 日期:2009.3.10
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Framework.AOP
{
    #region SQL文解析接口
    public interface IDbHelper
    {
        string SqlAnalysis();
        object SqlExcute(string newSql);
        Type EntityType { get; set; }
        Type DaoReturnType { get; set; }
    }
    #endregion
}
