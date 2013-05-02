using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Medical.Framework.Base.Entity;
using System.Xml.Linq;
using Medical.Framework.Container.Impl;
using Medical.Framework.Container.Factory;
using Medical.Framework.Container;

namespace Medical.Framework.ADO
{
    public class DbAccess
    {

        #region  初始化 log4net
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        private string param;

        public DbAccess()
        {
            string xmlpath = @"E:\Final\Medical\config\db.xml";
            XElement xe = XElement.Load(xmlpath);
            IEnumerable<XElement> xel =
                from el in xe.Elements()
                where el.Attribute("name").Value == "DBConnection"
                select el;
            foreach (XElement x in xel)
            {
                param = ((XElement)x.FirstNode).Value;

            }
        }

        public UserEntity GetUserEntity(string userId)
        {
             
             UserEntity user= new UserEntity();
             log.Info("---------------------db connection start------------------");
             SqlConnection con = null;
             try
             {
                    con = new SqlConnection(param);
                    string sql = " select userInfo.*,userRole.roleName from userInfo ,userRole where userInfo.id=userRole.userId and userInfo.id='" + userId + "'";

                    con.Open();

                    SqlCommand sqlCommend = new SqlCommand(sql, con);

                     SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();
    
                    while(sqlDataReader.Read())
                    {
                        user.UserId = sqlDataReader.GetString(0);
                        user.UserName = sqlDataReader.GetString(1);
                        user.Password = sqlDataReader.GetString(2);
                        user.RoleName = sqlDataReader.GetString(3);
                    }
             }
             catch (System.Exception ex)
             {
                 log.Debug("db connection error,detail :"+ ex.StackTrace);
                 throw ex;
             }
             finally
             {

                if (con!= null)
                {
                    con.Close();

                }

             }
            
             return user;



        }


        public List<MenuEntity> GetMenuList(string userId)
        {
            log.Info("---------------------db connection start------------------");
            MenuEntity menuEntity;
            List<MenuEntity> menuList = new List<MenuEntity>();
            SqlConnection con = new SqlConnection(param);
            try
            {

                string sql = 
                " SELECT   MenuInfo.menuId,MenuInfo.name,MenuInfo.menuLevel,MenuInfo.parentId "+ 
                " FROM UserRole, RoleMenu, MenuInfo "
                +"  WHERE UserRole.roleId= RoleMenu.roleId"                                     
                +"   AND RoleMenu.menuId=MenuInfo.menuId "
                +"  AND RoleMenu.permission=1 "
                +"   AND UserRole.userId='"+userId+"'"
                + "  order by menuLevel desc   ";  
 
         

                con.Open();

                SqlCommand sqlCommend = new SqlCommand(sql, con);

                SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    menuEntity = new MenuEntity();
                    menuEntity.MenuId = sqlDataReader.GetString(0);
                    menuEntity.MenuName = sqlDataReader.GetString(1);
                    menuEntity.MenuLevel = sqlDataReader.GetString(2);
                    menuEntity.ParentMenuId = sqlDataReader.GetString(3);
                    menuList.Add(menuEntity);

                }
            }
            catch (System.Exception ex)
            {
                log.Debug("db connection error,detail :" + ex.StackTrace);
                throw ex;
            }
            finally
            {

                if (con != null)
                {
                    con.Close();

                }

            }

            return menuList;



        }




        public Dictionary<string, SubScreenEntity> GetMenuScreenMap(string userId)
        {

            log.Info("---------------------db connection start------------------");
            string menuId ;
            SubScreenEntity subScreenEntity;
            Dictionary<string, SubScreenEntity> menuScreenMap = new Dictionary<string, SubScreenEntity>();
            SqlConnection con = new SqlConnection(param);
            try
            {

                string sql =
                " SELECT  MenuInfo.menuId,ScreenInfo.subScreenId,ScreenInfo.name,ScreenInfo.assemblyName,ScreenInfo.formName" +
                "   FROM UserRole, RoleMenu, MenuInfo,ScreenInfo " +
                "   WHERE UserRole.roleId= RoleMenu.roleId " +
                "   AND RoleMenu.menuId=MenuInfo.menuId  " +
                "   AND MenuInfo.subScreenId=ScreenInfo.subScreenId   " +
                "   AND RoleMenu.permission=1 " +
                "   AND UserRole.userId='" + userId + "'" +
                "   order by menuLevel desc";   
 
         

                con.Open();

                SqlCommand sqlCommend = new SqlCommand(sql, con);

                SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    subScreenEntity = new SubScreenEntity();
                    menuId = sqlDataReader.GetString(0);                
                    subScreenEntity.ScreenId = sqlDataReader.GetString(1);
                    subScreenEntity.Name = sqlDataReader.GetString(2);
                    subScreenEntity.AssemblyName = sqlDataReader.GetString(3);
                    subScreenEntity.ClassName = sqlDataReader.GetString(4);
                    menuScreenMap.Add(menuId,subScreenEntity);
                }
            }
            catch (System.Exception ex)
            {
                log.Debug("db connection error,detail :" + ex.StackTrace);
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();

                }

            }
            return menuScreenMap;
        }

        //取消息
        public Dictionary<string, MedicalSystemMessage> GetMessageMap()
        {
            log.Info("---------------------db connection start------------------");
            string code;
            Dictionary<string, MedicalSystemMessage> messageMap = new Dictionary<string, MedicalSystemMessage>();
            SqlConnection con = new SqlConnection(param);
            try
            {

                string sql = "select * from messageinfo where messagelevel != 'E'";

                con.Open();

                SqlCommand sqlCommend = new SqlCommand(sql, con);

                SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    MedicalSystemMessage message = new MedicalSystemMessage();
                    code = sqlDataReader.GetString(0);
                    message.MessageLevel = sqlDataReader.GetString(1);
                    message.DetailMessage = sqlDataReader.GetString(2);
                    messageMap.Add(code, message);

                }
            }
            catch (System.Exception ex)
            {
                log.Debug("db connection error,detail :" + ex.StackTrace);
                throw ex;
            }
            finally
            {

                if (con != null)
                {
                    con.Close();

                }

            }

            return messageMap;

        }

        //取异常
        public void PutExceptionIntoContainer()
        {
            log.Info("---------------------db connection start------------------");
            string code = string.Empty;
            string detailMessage = string.Empty;
            ISingletonContainer container = SingletonContainerFactory.Container;
            SqlConnection con = new SqlConnection(param);
            try
            {

                string sql = "select * from messageinfo where messagelevel = 'E'";

                con.Open();

                SqlCommand sqlCommend = new SqlCommand(sql, con);

                SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    code = sqlDataReader.GetString(0);
                    detailMessage = sqlDataReader.GetString(2);
                    container.AddComponent(code, detailMessage);

                }
            }
            catch (System.Exception ex)
            {
                log.Debug("db connection error,detail :" + ex.StackTrace);
                throw ex;
            }
            finally
            {

                if (con != null)
                {
                    con.Close();

                }

            }
        }
    }
}
