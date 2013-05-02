using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Medical.Framework.Container;
using Medical.Framework.Container.Factory;
using Medical.Framework.Base;
using Medical.Framework.Util;
using Medical.Framework.Base.Impl;
using Medical.Framework.Exception;
using Medical.Framework.Container.Util;
namespace MedicalWebService
{
    /// <summary>
    /// Service1 の概要の説明です
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // この Web サービスを、スクリプトから ASP.NET AJAX を使用して呼び出せるようにするには、次の行のコメントを解除します。
    // [System.Web.Script.Services.ScriptService]
    public class MainWebService : System.Web.Services.WebService
    {
        #region  初始化 log4net
        /// <summary>
        /// 初始化 log4net
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region 属性

        private AppParamFormatter formatter = new AppParamFormatter();

        #endregion

        #region server端入口

        [WebMethod]
        public byte[] Execute(byte[] b)
        {
            log.Info("begin remote method");
            try
            {
                AppParam appParam = null;
                byte[] temp = { };
                ISingletonContainer container = SingletonContainerFactory.Container;
                AppParamFormatter formatter = new AppParamFormatter();
                if (formatter.isZipCompressed(b))           //判断byte[]是否被压缩过
                {
                    appParam = DecompressAndDeserialize(b);     //解压缩并且反序列化
                }
                else
                {
                    appParam = Deserialize(b);       //反序列化
                }
                string name = appParam.RequestClass;  //得到请求地址
                string classKey = ((RequestUtil)container.GetObject(name)).ClassKey;   //根据映射关系得到要调用的applogic
                AbsAppLogicBase iAppLogicBase = container.GetComponent(classKey) as AbsAppLogicBase;//容器中加载applogic的实例
                AppParam retParam = iAppLogicBase.DoApplication(appParam, iAppLogicBase);
                byte[] retByte = Serialize(retParam);//二进制序列化AppParam
                if (formatter.isNeedCompressed(retByte))
                {
                    temp = Compress(retByte);
                    return temp;
                }
                else
                {
                    return retByte;
                }
            }
            catch (AppException e)
            {
                log.Debug(e.FullMessage);
                throw e;
            }
            catch (SysException ex)
            {
                log.Debug(ex.StackTrace);
                throw ex;
                
            }
            catch (System.Exception ex1)
            {
                log.Debug(ex1.StackTrace);
                throw ex1;
            }
            log.Info("end remote method");
        }

        #endregion

        #region 解压缩并且反序列化

        /// <summary>
        /// 解压缩并且反序列化
        /// </summary>
        /// <param name="buf">客户端传递到服务器端的参数数据</param>
        /// <returns>解压缩并且反序列化后的系统参数类</returns>
        private AppParam DecompressAndDeserialize(byte[] buf)
        {
            byte[] tempByte = formatter.Decompress(buf);
            return Deserialize(tempByte);
        }
        
        #endregion

        #region 反序列化

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="buf">客户端传递到服务器端的参数数据或者是被服务器端解压缩之后的参数数据</param>
        /// <returns>反序列化后的系统参数类</returns>
        private AppParam Deserialize(byte[] buf)
        {
            return formatter.Deserialize(buf);
        }

        #endregion

        #region 压缩

        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="buf">序列化之后的参数</param>
        /// <returns>压缩过后的参数</returns>
        private byte[] Compress(byte[] buf)
        {
            return formatter.Compress(buf);
        }

        #endregion

        #region 序列化

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="appParam">系统参数类</param>
        /// <returns>序列化之后的byte数组</returns>
        private byte[] Serialize(AppParam appParam)
        {
            return formatter.Serialize(appParam);
        }

        #endregion
    }
}
