using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Medical.Framework.Util;
using System.Reflection;
using MedicalSystem.Pf.Common.Proxy.EnterService;


namespace MedicalSystem.Pf.Common.Proxy
{
    public class ProxyService
    {
        #region 属性

        private AppParamFormatter formatter = new AppParamFormatter();
        private MainWebService enter = new MainWebService();

        #endregion

        #region WebService中Execute方法的代理代理方法

        public AppParam Execute(AppParam appParam)
        {
            byte[] retByte = { };
            AppParam retParam = null;
            byte[] buf = Serialize(appParam);
            retByte = RequestServer(buf);   //客户端请求服务器端

            retParam = AnalysisData(retByte);    //处理客户端处理服务器端响应的数据

            return retParam;
        }

        #endregion

        #region 客户端请求服务器端

        /// <summary>
        /// 客户端请求服务器端
        /// </summary>
        /// <param name="buf">客户端发送给服务器端的参数数据</param>
        /// <returns>服务器端返回给客户端的参数数据</returns>
        private byte[] RequestServer(byte[] buf)
        {
            byte[] temp = { };
            if (formatter.isNeedCompressed(buf))
            {
                temp = Compress(buf);
                return enter.Execute(temp);
            }
            else
            {
                return enter.Execute(buf);
            }
        }

        #endregion

        #region 处理客户端处理服务器端响应的数据

        /// <summary>
        /// 处理客户端处理服务器端响应的数据
        /// </summary>
        /// <param name="buf">服务器端响应给客户端的参数</param>
        /// <returns>系统参数类</returns>
        private AppParam AnalysisData(byte[] buf)
        {
            if (formatter.isZipCompressed(buf))
            {
                return DecompressAndDeserialize(buf);
            }
            else
            {
                return Deserialize(buf);
            }
        }

        #endregion

        #region 解压缩并且反序列化

        /// <summary>
        /// 解压缩并且反序列化
        /// </summary>
        /// <param name="buf">服务器端响应到客户端的参数数据</param>
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
        /// <param name="buf">服务器响应到客户端的参数数据或者是被客户端端解压缩之后的参数数据</param>
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
