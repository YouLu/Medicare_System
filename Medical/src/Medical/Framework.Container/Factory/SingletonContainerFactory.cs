/*
 * 作者：吕游
 * 时间：2009-3-31
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Medical.Framework.Constant;
using Medical.Framework.Container;
using Medical.Framework.Container.Impl;
using Medical.Framework.Util;
using Medical.Framework.ORM;
using System.Xml.Linq;
using System.Reflection;
using Medical.Framework.Exception;
using Medical.Framework.Container.Util;
using Medical.Framework.ADO;

namespace Medical.Framework.Container.Factory
{
    public static class SingletonContainerFactory
    {
        #region  初始化 log4net
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion


        #region 整个应用的Xml文件对应在Web.config中的key

        private const string WEBCONFIG_COMMON = Constants.WEBCONFIG_COMMON;
        private const string ISSSTRUTS = Constants.STRUTS_PATH;
        private const string EXCEOTION_CODE = Constants.EXCEPTION_CODE;

        #endregion

        #region 属性

        private static ISingletonContainer container;
        private static IEnumerable<XNode> xNodes ;
        private static Dictionary<string, object> dictionary;

        #endregion

        #region 容器的访问器
        public static ISingletonContainer Container
        {
            get
            {
                if (container == null)
                {
                    log.Debug("");
                    throw new ContainerInitException();
                }
                return container;
            }
            set { SingletonContainerFactory.container = value; }
        }

        public static string ConfigPath() 
        {
            string path = ConfigurationSettings.AppSettings[WEBCONFIG_COMMON];
            if(path == null || path == "")
            {
                throw new AppConfigException();
            }
            return path;
        }

        #endregion

        #region 创建容器
        /// <summary>
        /// 创建容器
        /// </summary>
        /// <param name="xmlPath">需要被容器实例化的类的配置文件</param>
        /// <returns>容器的实例</returns>

        public static ISingletonContainer create(string xmlPath)
        {
            if(container == null)
            {
                container = new SingletonContainerImpl();
            }
            LoadDBConfig();//加载DB配置文件
            LoadIssStruts();//加载映射配置文件
            LoadMessageCode();//加载异常信息
            return build(xmlPath);
        }

        #endregion

        #region 加载需要被容器实例化的类

        /// <summary>
        /// 加载需要被容器实例化的类
        /// </summary>
        /// <param name="xmlPath">需要被容器实例化的类的配置文件</param>
        /// <returns>容器的实例</returns>
        private static ISingletonContainer build(string xmlPath)
        {
            if(xmlPath == null || xmlPath == "")
            {
                throw new AppConfigException();
            }
            ParseXml parseXml = new ParseXml();
            IEnumerable<XElement> components = parseXml.ParseCommon(xmlPath);
            foreach (XElement com in components)
            {
                //dictionary = parseXml.ParseChildNode(com.Attribute("path").Value);
                //xNodes = (IEnumerable<XNode>)dictionary["xNodes"];
                xNodes = parseXml.ParseChildNode(com.Attribute("path").Value);
                foreach (XNode node in xNodes)
                {
                    Type type = node.GetType();
                    if (type.Equals(typeof(XElement)))
                    {
                        if (container == null)
                        {
                            throw new ContainerInitException();
                        }
                        container.AddComponent((string)((XElement)node).Attribute("key"),
                                ((XElement)node).Element("Class").Value);
                    }
                }
            }
            return container;
        }

        #endregion

        #region 加载WebService和AppLogic的映射关系 IssStruts.xml

        /// <summary>
        /// 加载WebService和AppLogic的映射关系 IssStruts.xml
        /// </summary>
        private static void LoadIssStruts()
        {
            log.Debug("start init IssStruts");
            string path = ConfigurationSettings.AppSettings[ISSSTRUTS];
            ParseXml parseXml = new ParseXml();
            IEnumerable<XElement> actions = parseXml.ParseIssStruts(path);
            foreach (XElement xe in actions)
            {
                if(container == null)
                {
                    log.Debug("init IssStruts failed");
                    throw new ContainerInitException();
                    
                }
                string key = (string)xe.Attribute("name");
                RequestUtil requestUtil = new RequestUtil();
                requestUtil.ClassKey = ((XElement)xe.FirstNode).Attribute("classKey").Value;
                requestUtil.Method = ((XElement)xe.FirstNode).Attribute("method").Value;
                container.AddComponent(key, requestUtil);
            }

            log.Debug("init IssStruts success");
        }

        #endregion


        #region 加载异常信息MessageCode.xml

        /// <summary>
        /// 加载异常信息MessageCode.xml
        /// </summary>
        //private static void LoadMessageCode()
        //{
        //    log.Debug("init MessageCode");

        //    string path = ConfigurationSettings.AppSettings[EXCEOTION_CODE];
        //    ParseXml parseXml = new ParseXml();
        //    IEnumerable<XElement> messageCodes = parseXml.ParseMessageCode(path);
        //    foreach (XElement xe in messageCodes)
        //    {
        //        if (container == null)
        //        {
        //            throw new ContainerInitException();
        //            log.Debug("init MessageCode failed");
        //        }
        //        string code = (string)xe.Attribute("code");
        //        string message = ((XElement)xe.FirstNode).Value;
        //        container.AddComponent(code, message);
        //    }

        //    log.Debug("init MessageCode success");
        //}

        private static void LoadMessageCode()
        {
            DbAccess db = new DbAccess();
            db.PutExceptionIntoContainer();

        }

        #endregion

        #region 加载数据库配置
        /// <summary>
        /// 加载数据库配置
        /// </summary>
        private static void LoadDBConfig()
        {
            log.Debug("init ARConfig");

            string ARConfigpath = ConfigurationSettings.AppSettings["ARConfig"];
            string entityAssemblyName = ConfigurationSettings.AppSettings["entity"];
            DBInit.Initli(ARConfigpath, entityAssemblyName);

            log.Debug("init ARConfig success");
        }

        #endregion

        #region 销毁容器

        public static void Destory()
        {
            SingletonContainerImpl.Destroy();
            container = null;
        }

        #endregion
    }
}
