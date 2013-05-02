using System;
using Castle.ActiveRecord;
using NHibernate;
using Castle.ActiveRecord.Queries.Modifiers;
using System.Data;
using Castle.ActiveRecord.Framework;
using System.Collections;
using System.Data.SqlClient;
using Medical.Framework.Exception;

namespace Medical.Framework.ORM.Util
{
    public class DBUtil
    {
        /// <summary>
        /// 特殊查询
        /// </summary>
        /// <typeparam name="MyEntityType"></typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IList ExecuteQuery(Type myEntityType, String query, params QueryParameter[] parameters)
        {
            IList result = null;
            try
            {
                ISession session = ActiveRecordMediator.GetSessionFactoryHolder().CreateSession(myEntityType);

                ISQLQuery sqlQuery = session.CreateSQLQuery(query).AddEntity(myEntityType);

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        sqlQuery.SetParameter(param.Name,
                                              param.Value);
                    }
                }

                result = sqlQuery.List();


            }
            catch (ActiveRecordException are)
            {
                throw new OrmException("ActiveRecordException" + are.Message);
            }
            catch (System.Exception e)
            {
                throw new OrmException("其它异常" + e.Message);
            }
            return result;
        }




        /// <summary>
        /// 查询影响记录
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteCommand(Type myEntityType, String commandText, params SqlParameter[] parameters)
        {
            int result = 0;
            try
            {
                using (ISession session = ActiveRecordMediator.GetSessionFactoryHolder().CreateSession(typeof(int)))
                {
                    IDbCommand sqlCommand = session.Connection.CreateCommand();

                    sqlCommand.CommandText = commandText;

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            sqlCommand.Parameters.Add(param);
                        }
                    }

                    result = sqlCommand.ExecuteNonQuery();

                    session.Close();
                }
            }
            catch (ActiveRecordException are)
            {
                throw new OrmException("ActiveRecordException" + are.Message);
            }
            catch (System.Exception e)
            {
                throw new OrmException("其它异常" + e.Message);
            }
            return result;
        }
    }
}
