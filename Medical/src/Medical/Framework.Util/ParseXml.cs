using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Medical.Framework.Constant;
using System.Configuration;
using Medical.Framework.Exception;

namespace Medical.Framework.Util
{
    public class ParseXml
    {
        #region linq to xml解析自定义整个应用的XML(Common.xml)

        public IEnumerable<XElement> ParseCommon(string xmlPath)
        {
            if (xmlPath == null || xmlPath == "")
            {
                throw new AppConfigException();
            }
            XDocument document = XDocument.Load(xmlPath);
            XElement component = document.Element("components");

            IEnumerable<XElement> components =
                from com in component.Elements("include")
                select com;
            return components;
        }

        #endregion

        #region 解析在自定义整个应用的XML中配置的XML文件

        //public Dictionary<string, Object> ParseChildNode(string childNode)
        //{
        //    Dictionary<string, Object> dictionary = new Dictionary<string, Object>();
        //    XElement document = XElement.Load(childNode);
        //    XElement xNameSpace = document.Element("NameSpace");
        //    IEnumerable<XNode> componentes =
        //        from el in xNameSpace.Nodes()
        //        select el;
        //    dictionary.Add("NameSpace", getXmlNameSpace(document));
        //    dictionary.Add("xNodes", componentes);

        //    return dictionary;
        //}
        public IEnumerable<XNode> ParseChildNode(string childNode)
        { 
            XElement document = XElement.Load(childNode);
            IEnumerable<XNode> componentes =
                from el in document.Nodes()
                select el;

            return componentes;
        }

        #endregion

        #region 辅助方法，得到每个XML的叫NameSpace节点的属性值

        private string getXmlNameSpace(XElement document)
        {
            return document.Element("NameSpace").Attribute("name").Value;
        }

        #endregion

         

        #region 解析IssStruts.xml文件

        public IEnumerable<XElement> ParseIssStruts(string path)
        {
            if (path == null || path == "")
            {
                throw new AppConfigException();
            }
            XElement xe = XElement.Load(path);
            IEnumerable<XElement> actions =
                from el in xe.Elements("Action")
                select el;
            return actions;
        }

        #endregion

        #region 解析异常信息文件 MessageCode.xml

        public IEnumerable<XElement> ParseMessageCode(string path)
        {
            if (path == null || path == "")
            {
                throw new AppConfigException();
            }
            XElement xe = XElement.Load(path);
            IEnumerable<XElement> messageCodes =
                from el in xe.Elements("MessageCode")
                select el;
            return messageCodes;
        }

        #endregion

    }
}
