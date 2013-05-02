using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

namespace Medical.Framework.Container.Impl
{
    public class SingletonContainerImpl : ISingletonContainer
    {
        #region 初始化容器的Dictionary

        private static readonly Dictionary<string,Object> dictionary = new Dictionary<string,Object>();

        #endregion 

        #region 向容器中添加可实例化的元素

        /// <summary>
        /// 向容器中添加可实例化的元素
        /// </summary>
        /// <param name="NameSpace">命名空间</param>
        /// <param name="key">唯一逻辑名称</param>
        /// <param name="className">类名</param>
        //public void AddComponent(string NameSpace,string key, string className)
        //{
        //    dictionary.Add(key, NameSpace+"."+className);
        //}

        #endregion

        #region 向容器中添加不需要实例化的元素

        /// <summary>
        /// 向容器中添加不需要实例化的元素
        /// </summary>
        /// <param name="key">唯一逻辑名称</param>
        /// <param name="message">消息</param>
        public void AddComponent(string key, string value)
        {
            dictionary.Add(key, value);
        }

        #endregion

        #region 向容器中添加对象

        /// <summary>
        /// 向容器中添加对象
        /// </summary>
        /// <param name="key">唯一逻辑名</param>
        /// <param name="obj">实例</param>
        public void AddComponent(string key,Object obj)
        {
            dictionary.Add(key, obj);
        }

        #endregion

        #region 从容器中取出可实例化的元素

        /// <summary>
        /// 从容器中取出可实例化的元素
        /// </summary>
        /// <param name="key">唯一逻辑名</param>
        /// <returns>为一逻辑名对应的类的一个实例</returns>
        public Object GetComponent(string key)
        {
            string className = (string)dictionary[key];
            string nameSpace = parseClassName(className);
            Assembly ass = Assembly.Load(nameSpace);
            Assembly[] a = AppDomain.CurrentDomain.GetAssemblies();
            Object obj = ass.CreateInstance(className);
            return obj;
        }

        #endregion

        #region 从容器中取出不需要实例化的元素

        /// <summary>
        /// 从容器中取出不需要实例化的元素
        /// </summary>
        /// <param name="key">唯一逻辑名</param>
        /// <returns>为一逻辑名对应的消息</returns>
        public string GetMessage(string key)
        {
            string message = (string)dictionary[key];
            return message;
        }

        #endregion 

        #region 从容器中取出对象元素

        /// <summary>
        /// 从容器中取出对象元素
        /// </summary>
        /// <param name="key">唯一逻辑名</param>
        /// <returns>唯一逻辑名对应的实例</returns>
        public Object GetObject(string key)
        {
            Object obj = dictionary[key];
            return obj;
        }

        #endregion

        #region 解析类名，得到命名空间

        private string parseClassName(string className)
        {
            string[] strs = className.Split('.');
            int len = strs[strs.Length - 1].Length;
            string retStr = className.Substring(0, className.Length - len-1);
            return retStr;
        }

        #endregion

        #region 销毁容器

        public static void Destroy()
        {
            dictionary.Clear();
        }

        #endregion
    }
}
