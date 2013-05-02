using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Medical.Framework.Base.Entity;
using System.Xml.Linq;


namespace Medical.Framework.ADO
{
    public  class CodeAccess
    {



        #region  初始化 log4net
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        
        private string param;

        public CodeAccess()
        {
            string xmlpath = @"E:\Final\Medical\config\db.xml";
            XElement xe = XElement.Load(xmlpath);
            IEnumerable<XElement> xel =
                from el in xe.Elements()
                where el.Attribute("name").Value == "CodeAccess"
                select el;
            foreach (XElement x in xel)
            {
                param = ((XElement)x.FirstNode).Value;

            }
        }


        public Dictionary<string, string> GetCodeMap()
        {

            log.Info("---------------------db connection start------------------");

            Dictionary<string, string> codeMap = new Dictionary<string, string>();
            SqlConnection con = new SqlConnection(param);
            try
            {

                string sql = "select (codeClass+code) as codeKey,name from Mstcode";

                con.Open();

                SqlCommand sqlCommend = new SqlCommand(sql, con);

                SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    codeMap.Add(sqlDataReader.GetString(0), sqlDataReader.GetString(1));
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
            return codeMap;
        }























        public Dictionary<string, string> GetContainerMap()
        {

            log.Info("---------------------db connection start------------------");
           
            Dictionary<string, string> containerMap = new Dictionary<string, string>();
            SqlConnection con = new SqlConnection(param);
            try
            {

                string sql = "select containercd,containername from mstcontainer";
 
                con.Open();

                SqlCommand sqlCommend = new SqlCommand(sql, con);

                SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    containerMap.Add( sqlDataReader.GetString(0),sqlDataReader.GetString(1));
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
            return containerMap;
        }


        public Dictionary<string, string> GetDiagnosisDeptMap()
        {

            log.Info("---------------------db connection start------------------");

            Dictionary<string, string> diagnosisDeptMap = new Dictionary<string, string>();
            SqlConnection con = new SqlConnection(param);
            try
            {

                string sql = "select diagnosisDeptCD,diagnosisDeptname from MstDiagnosisDept";

                con.Open();

                SqlCommand sqlCommend = new SqlCommand(sql, con);

                SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    diagnosisDeptMap.Add(sqlDataReader.GetString(0), sqlDataReader.GetString(1));
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
            return diagnosisDeptMap;
        }




        public Dictionary<string, string> GetDiseaseMap()
        {

            log.Info("---------------------db connection start------------------");

            Dictionary<string, string> diseaseMap = new Dictionary<string, string>();
            SqlConnection con = new SqlConnection(param);
            try
            {

                string sql = "select diseasecd,diseasename from mstdisease";

                con.Open();

                SqlCommand sqlCommend = new SqlCommand(sql, con);

                SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    diseaseMap.Add(sqlDataReader.GetString(0), sqlDataReader.GetString(1));
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
            return diseaseMap;
        }


        public Dictionary<string, string> GetDoctorMap()
        {

            log.Info("---------------------db connection start------------------");

            Dictionary<string, string> doctorMap = new Dictionary<string, string>();
            SqlConnection con = new SqlConnection(param);
            try
            {

                string sql = "select doctorcd,doctorname from mstdoctor";

                con.Open();

                SqlCommand sqlCommend = new SqlCommand(sql, con);

                SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    doctorMap.Add(sqlDataReader.GetString(0), sqlDataReader.GetString(1));
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
            return doctorMap;
        }


        public Dictionary<string, string> GetDrugProductMap()
        {

            log.Info("---------------------db connection start------------------");

            Dictionary<string, string> DrugProductMap = new Dictionary<string, string>();
            SqlConnection con = new SqlConnection(param);
            try
            {

                string sql = "select drugproductcd,drugproductname from mstdrugproduct";

                con.Open();

                SqlCommand sqlCommend = new SqlCommand(sql, con);

                SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    DrugProductMap.Add(sqlDataReader.GetString(0), sqlDataReader.GetString(1));
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
            return DrugProductMap;
        }


        public Dictionary<string, string> GetWardMap()
        {

            log.Info("---------------------db connection start------------------");

            Dictionary<string, string> wardMap = new Dictionary<string, string>();
            SqlConnection con = new SqlConnection(param);
            try
            {

                string sql = "select wardcd,wardname from mstward";

                con.Open();

                SqlCommand sqlCommend = new SqlCommand(sql, con);

                SqlDataReader sqlDataReader = sqlCommend.ExecuteReader();

                while (sqlDataReader.Read())
                {
                   wardMap.Add(sqlDataReader.GetString(0), sqlDataReader.GetString(1));
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
            return wardMap;
        }










    }
}
