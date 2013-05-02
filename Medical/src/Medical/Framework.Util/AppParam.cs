using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Exception;
using System.Runtime.Serialization;

namespace Medical.Framework.Util
{
    [Serializable]
    public class AppParam : ISerializable
    {
        #region 属性

        private string requestClass;
        private IList<Param> paramList;

        #endregion

        #region 访问器方法

        public string RequestClass
        {
            get { return requestClass; }
            set { requestClass = value; }
        }

        #endregion

        #region 默认访问器方法

        public AppParam()
        { 
            paramList = new List<Param>();
        }

        #endregion

        #region 实现ISerializable接口的构造方法,反序列化时需要

        public AppParam(SerializationInfo info, StreamingContext context)
        {
            this.requestClass = info.GetString("requestClass");
            Type type = typeof(IList<Param>);
            this.paramList = (IList<Param>)info.GetValue("paramList", type);
        }

        #endregion

        #region 向参数类中加入元素

        /// <summary>
        /// 向参数类中加入元素
        /// </summary>
        /// <param name="paramName">唯一逻辑名</param>
        /// <param name="paramValue">要添加到参数类中的值</param>
        public void Add(string paramName,Object paramValue)
        {
            if(isParamNameExist(paramName))
            {
                throw new AppParamException(paramName);
            }
            Param param = new Param();
            param.ParamName = paramName;
            param.ParamValue = paramValue;
            param.TypeOfParamValue = paramValue.GetType();
            paramList.Add(param);
        }

        #endregion

        #region 从参数类中取得元素

        /// <summary>
        /// 从参数类中取得元素
        /// </summary>
        /// <param name="paramName">唯一逻辑名</param>
        /// <returns>唯一逻辑名对应的元素</returns>
        public Object Get(string paramName)
        { 
            object data = null;
            foreach(Param p in paramList)
            {
                if(p.ParamName.Equals(paramName))
                {
                    data = p.ParamValue;
                    break;
                }
            }
            if (data == null)
            {
                throw new NameNotFoundException(paramName);
            }
            return data;
        }

        #endregion

        #region 得到参数类中元素的个数

        /// <summary>
        /// 得到参数类中元素的个数
        /// </summary>
        /// <returns>参数类中元素的个数</returns>
        public int Count()
        {
            return paramList.Count;
        }

        #endregion

        #region 判断唯一逻辑名是否存在

        /// <summary>
        /// 判断唯一逻辑名是否存在
        /// </summary>
        /// <param name="paramName">唯一逻辑名</param>
        /// <returns>true表示存在,false表示不存在</returns>
        public bool isParamNameExist(string paramName)
        {
            bool flag = false;
            foreach(Param p in paramList)
            {
                if(p.ParamName.Equals(paramName))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        #endregion

        #region 实现ISerializable接口的方法,序列化时需要

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("requestClass", requestClass);
            info.AddValue("paramList", paramList);
        }

        #endregion
    }
}
