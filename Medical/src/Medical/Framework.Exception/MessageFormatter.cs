/*
 * 日期：2009-3-30
 * 作者：吕游
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Resources;
using System.Configuration;
using Medical.Framework.Constant;
using Medical.Framework.Container;
using Medical.Framework.Container.Factory;


namespace Medical.Framework.Exception
{
    class MessageFormatter
    {
        //#region 编号异常对应表存放位置

        //private static string EXCEPTION_ERROR = ConfigurationSettings.AppSettings[Constants.EXCEPTION_ERROR];

        //#endregion

        #region 根据编号得到异常信息

        /// <summary>
        /// 根据编号得到异常信息
        /// </summary>
        /// <param name="messageCode">异常编号</param>
        /// <param name="args">异常信息中的参数</param>
        /// <returns>格式化的异常信息</returns>
        public static string GetSampleMessage(string messageCode,Object[] args)
        {
            //应该从container中获得
            //ResourceManager rmManager = new ResourceManager(EXCEPTION_ERROR, Assembly.GetExecutingAssembly()); 
            //return string.Format(rmManager.GetString(messageCode), args);
            ISingletonContainer container = SingletonContainerFactory.Container;
            string message = container.GetMessage(messageCode);
            return string.Format(message, args);
        }

        #endregion
    }
}
