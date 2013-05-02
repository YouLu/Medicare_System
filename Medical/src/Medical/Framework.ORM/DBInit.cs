using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using System.Reflection;

namespace Medical.Framework.ORM
{
    public class DBInit
    {
        #region  初始化 log4net
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        /// <summary>
        /// 提供配置文件初始化方法
        /// </summary>
        public static void Initli(string configPath,string assemblyName)
        {
            try
            {
                XmlConfigurationSource source = new XmlConfigurationSource(configPath);
                Assembly ass = Assembly.Load(assemblyName);
                ActiveRecordStarter.Initialize(ass, source);
            }
            catch (System.Exception e)
            {
                log.Debug("init ARConfig failed");
            }
            
        }
    }
}
