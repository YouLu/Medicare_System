using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Medical.Framework.Base.Entity;

namespace Medical.Framework.Util
{
    [Serializable]
    public class Param : ISerializable
    {
        #region 属性

        private string paramName;
        private Object paramValue;
        private Type typeOfParamValue;

        #endregion

        #region 构造方法

        /// <summary>
        /// 默认构造方法
        /// </summary>
        public Param()
        { 
        
        }

        /// <summary>
        /// 实现ISerializable接口中的方法,提供反序列化功能
        /// </summary>
        public Param(SerializationInfo info, StreamingContext context)
        {
            Type type = Type.GetType("System.Object");
            this.paramName = info.GetString("paramName");
            this.typeOfParamValue = (Type)info.GetValue("typeOfParamValue", typeof(Type));
            this.paramValue = info.GetValue("paramValue", typeOfParamValue);
        }

        #endregion 

        #region 访问器方法

        public string ParamName
        {
            get { return paramName; }
            set { paramName = value; }
        }
       

        public Object ParamValue
        {
            get { return paramValue; }
            set { paramValue = value; }
        }

        public Type TypeOfParamValue
        {
            get { return typeOfParamValue; }
            set { typeOfParamValue = value; }
        }

        #endregion

        #region 实现ISerializable接口中的方法,提供序列化功能

        /// <summary>
        /// 实现ISerializable接口中的方法,提供反序列化功能
        /// </summary>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("paramName", paramName);
            info.AddValue("typeOfParamValue", typeOfParamValue);
            info.AddValue("paramValue", paramValue);
        }

        #endregion
    }
}
