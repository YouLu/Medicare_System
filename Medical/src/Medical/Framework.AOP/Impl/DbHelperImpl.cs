/*
 * 作者:李博
 * 日期:2009.3.25
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.AOP;
using System.Text.RegularExpressions;
using System.Reflection;
using Castle.ActiveRecord.Queries.Modifiers;
using System.Collections;
using System.Data.SqlClient;
using Medical.Framework.ORM.Util;
using Medical.Framework.Exception;

namespace Medical.Framework.AOP.Impl
{
    public sealed class DbHelperImpl : IDbHelper
    {
        private IAttributeReader _attributeReader;
        private MethodInfo methodInfo;
        private object[] _methodParams;
        private Type daoReturnType;
        private Type entityType;

        public Type EntityType
        {
            get
            {
                return entityType;
            }
            set
            {
                entityType = value;
            }
        }
        public Type DaoReturnType
        {
            get
            {
                return daoReturnType;
            }
            set
            {
                daoReturnType = value;
            }
        }



        public DbHelperImpl(IAttributeReader attributeReader, params object[] methodParams)
        {
            _attributeReader = attributeReader;
            _methodParams = methodParams;
            methodInfo = attributeReader.MethodInfo;
            daoReturnType = attributeReader.MethodInfo.ReturnType;
            entityType = attributeReader.GetEntityType();
        }


        private string[] _selectPrefixes = new string[] { "Get" };
        private string[] _insertPrefixes = new string[] { "Insert", "Create", "Add" };
        private string[] _updatePrefixes = new string[] { "Update", "Modify", "Store" };
        private string[] _deletePrefixes = new string[] { "Delete", "Remove" };

        private string DEFAULT_PARAMETER_MARKER_FORMAT
            = @"("
            + @"(?<![@\p{Lo}\p{Lu}\p{Ll}\p{Lm}\p{Nd}\uff3f_#\$\.])@[\p{Lo}\p{Lu}\p{Ll}\p{Lm}\p{Nd}\uff3f_#\$\.]*(?=[\s,\(\);]+|$)"
            + @"|"
            + @"(?<![:\p{Lo}\p{Lu}\p{Ll}\p{Lm}\p{Nd}\uff3f_#\$\.]):[\p{Lo}\p{Lu}\p{Ll}\p{Lm}\p{Nd}\uff3f_#\$\.]*(?=[\s,\(\);]+|$)"
            + @"|"
            + @"\?(?=[\s,\(\);]+|$)"
            + @")"
            ;

        #region  初始化 log4net
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region SQL文解析
        public string SqlAnalysis()
        {
            string sign, newSql;
            if (IsSelect(methodInfo.Name))
            {
                sign = ":";
                newSql = GetChangeSignCommandText(_attributeReader.GetSql(), sign);
            }
            else if (IsInsert(methodInfo.Name) || IsDelete(methodInfo.Name) || IsUpdate(methodInfo.Name))
            {
                sign = "@";
                newSql = GetChangeSignCommandText(_attributeReader.GetSql(), sign);
            }
            else
            {
                //方法名不满足命名规范
                log.Debug("方法名不满足命名规范");
                throw new MethodNamingException(methodInfo.Name);
            }
            return newSql;

        }

        private string GetChangeSignCommandText(string oldSql, string sign)
        {
            log.Debug("start changeSignCommandText");
            ParameterInfo[] pi = methodInfo.GetParameters();
            string parameterName = string.Empty;
            bool tag = false;//用于判断有没有参数赋值错误
            StringBuilder text = new StringBuilder(oldSql);
            for (int startIndex = 0; ; )
            {
                Match match = Match(text.ToString(), startIndex);
                if (!match.Success)
                {
                    break;
                }
                foreach (ParameterInfo piName in pi)
                {
                    if (match.ToString().Substring(1).Equals(piName.Name))
                    {
                        parameterName = sign + piName.Name;
                        tag = true;
                    }
                }
                if (!tag)
                {
                    // 参数格式错误
                    log.Debug("参数格式错误");
                    throw new ParameterFormatException(match.ToString());
                }
                text.Replace(match.Value, parameterName, match.Index, match.Length);
                startIndex = match.Index + parameterName.Length;
            }
            log.Debug("end changeSignCommandText");
            return text.ToString();
        }

        private Match Match(string sql, int startIndex)
        {
            return new Regex(DEFAULT_PARAMETER_MARKER_FORMAT, RegexOptions.Compiled).Match(sql, startIndex);
        }

        #region 判断是否是select方法 select方法使用:替换 其他方法用@替换
        private bool IsSelect(string methodName)
        {
            foreach (string selectName in _selectPrefixes)
            {
                if (methodName.StartsWith(selectName)) return true;
            }
            return false;
        }

        private bool IsInsert(string methodName)
        {
            foreach (string insertName in _insertPrefixes)
            {
                if (methodName.StartsWith(insertName)) return true;
            }
            return false;
        }

        private bool IsUpdate(string methodName)
        {
            foreach (string updateName in _updatePrefixes)
            {
                if (methodName.StartsWith(updateName)) return true;
            }
            return false;
        }

        private bool IsDelete(string methodName)
        {
            foreach (string deleteName in _deletePrefixes)
            {
                if (methodName.StartsWith(deleteName)) return true;
            }
            return false;
        }
        #endregion

        #endregion

        #region 执行SQL文
        public object SqlExcute(string newSql)
        {
            ParameterInfo[] pi = methodInfo.GetParameters();
            DBUtil dt = new DBUtil();
            IList list = null;
            string daoReturnTypeName;
            if (IsSelect(methodInfo.Name))
            {
                QueryParameter[] qp = new QueryParameter[_methodParams.Length];
                for (int i = 0; i < qp.Length; i++)
                {
                    qp[i] = new QueryParameter(pi[i].Name, _methodParams[i]);
                }
                if (daoReturnType.IsArray)
                {
                    daoReturnTypeName = daoReturnType.Name.Substring(0, daoReturnType.Name.Length - 2);
                    if (!entityType.Name.Equals(daoReturnTypeName))
                    {
                        list = dt.ExecuteQuery(daoReturnType, newSql, qp);
                    }
                    else
                    {
                        list = dt.ExecuteQuery(entityType, newSql, qp);
                    }
                }
                else if (daoReturnType.IsClass)
                {
                    if (!entityType.Name.Equals(daoReturnType.Name))
                    {
                        list = dt.ExecuteQuery(daoReturnType, newSql, qp);
                    }
                    else
                    {
                        list = dt.ExecuteQuery(entityType, newSql, qp);
                    }
                }
                else
                {
                    list = dt.ExecuteQuery(entityType, newSql, qp);
                }

                if (list != null)
                {
                    return list;
                }
                else
                {
                    //数据库查询失败
                    log.Debug("数据库查询失败");
                    throw new DatabaseQueryException();
                }
            }
            else
            {
                SqlParameter[] sp = new SqlParameter[_methodParams.Length];
                for (int i = 0; i < sp.Length; i++)
                {
                    sp[i] = new SqlParameter(pi[i].Name, _methodParams[i]);
                }
                int result = dt.ExecuteCommand(entityType, newSql, sp);
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    //数据库查询失败
                    log.Debug("数据库查询失败");
                    throw new DatabaseQueryException();
                }
            }
        }
        #endregion






    }

}
