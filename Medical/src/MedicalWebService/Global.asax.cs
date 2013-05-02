using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using Medical.Framework.Container;
using Medical.Framework.Exception;
using Medical.Framework.Container.Factory;
using System.IO;

namespace MedicalWebService
{
    public class Global : System.Web.HttpApplication
    {
        #region  初始化 log4net
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        protected void Application_Start(object sender, EventArgs e)
        {
            log.Debug("WebService start");
            try
            {
                string xmlPath = SingletonContainerFactory.ConfigPath();
                ISingletonContainer container = SingletonContainerFactory.create(xmlPath);
            }
            catch (AppException ex)
            {
                log.Fatal("application occurred fatal exception", ex);
                throw ex;
            }
            catch (SysException ex)
            {
                log.Fatal("system occurred fatal exception", ex);
                throw ex;
            }
            log.Debug("WebService start success");
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            ISingletonContainer container = SingletonContainerFactory.Container;
            if (container == null)
            {
                throw new ContainerInitException();
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            ISingletonContainer container = SingletonContainerFactory.Container;
            if(container == null)
            {
                throw new ContainerInitException();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            ISingletonContainer container = SingletonContainerFactory.Container;
            if (container == null)
            {
                throw new ContainerInitException();
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            SingletonContainerFactory.Destory();
        }
    }
}