using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Framework.Constant
{
    public class ExceptionCode
    {
        #region 系统异常key
        /// <summary>
        /// 系统异常key
        /// </summary>
        public const string ERROR001 = "ERROR001";//Class not found, details are {0}

        public const string ERROR002 = "ERROR002";//the ParamName {0} is not in the AppParam.

        public const string ERROR003 = "ERROR003";//ParamName {0} has been already exist.

        public const string ERROR004 = "ERROR004";//AppParam can not be null.

        public const string ERROR005 = "ERROR005";//业务调用流程发生错误

        public const string ERROR006 = "ERROR006";//初始化容器失败

        public const string ERROR007 = "ERROR007";//容器初始化加载配置文件时，路径不能为空

        public const string ERROR030 = "ERROR030";//没有找到指定的sqlFile文件

        public const string ERROR031 = "ERROR031";//没有找到指定的entity

        public const string ERROR032 = "ERROR032";//没有找到指定路径的sqlFile资源文件

        public const string ERROR033 = "ERROR033";//没有找到sql或sqlFile特性

        public const string ERROR034 = "ERROR034";//方法返回类型定义错误

        public const string ERROR035 = "ERROR035";//方法不满足命名规范

        public const string ERROR036 = "ERROR036";//参数格式错误

        public const string ERROR037 = "ERROR037";//数据库查询失败

        #endregion
    }
}
