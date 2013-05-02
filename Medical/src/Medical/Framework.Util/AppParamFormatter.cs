using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Medical.Framework.Exception;
using System.IO.Compression;

namespace Medical.Framework.Util
{
    public class AppParamFormatter
    {
        #region  初始化 log4net
        /// <summary>
        /// 初始化 log4net
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region 序列化功能

        /// <summary>
        /// 序列化功能
        /// </summary>
        /// <param name="appParam">系统参数类的实例</param>
        /// <returns>序列化之后的byte数组</returns>
        public byte[] Serialize(AppParam appParam)
        {
            log.Info("begin serizlize");

            if (appParam == null)
            {
                throw new SerializeException();
            }
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, appParam);
            memoryStream.Position = 0;
            byte[] read = new byte[memoryStream.Length];
            memoryStream.Read(read, 0, read.Length);
            memoryStream.Close();

            log.Info("serizlize success");

            return read;
        }

        #endregion

        #region 反序列化功能

        /// <summary>
        /// 反序列化功能
        /// </summary>
        /// <param name="b">需要被反序列化byte数组</param>
        /// <returns>系统参数类的实例</returns>
        public AppParam Deserialize(byte[] b)
        {
            log.Info(" start deserialize");

            MemoryStream memoryStream = new MemoryStream(b);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Object obj = binaryFormatter.Deserialize(memoryStream);
            AppParam appParam = obj as AppParam;
            memoryStream.Close();

            log.Info("deserialize success");

            return appParam;
        }

        #endregion

        #region 压缩

        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="buf">需要被压缩的byte数组</param>
        /// <returns>压缩过的byte数组</returns>
        public byte[] Compress(byte[] buf)
        {
            log.Info("begin compress");

            byte[] ret;
            MemoryStream memoryStream = new MemoryStream();
            GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true);
            gZipStream.Write(buf, 0, buf.Length);
            gZipStream.Flush();
            gZipStream.Close();
            memoryStream.Position = 0;
            ret = new byte[memoryStream.Length];
            memoryStream.Read(ret, 0, (int)memoryStream.Length);
            memoryStream.Close();

            log.Info("compress success");

            return ret;
        }

        #endregion

        #region 解压缩

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="buf">压缩过后的byte数组</param>
        /// <returns>解压之后,正常的byte数组</returns>
        public byte[] Decompress(byte[] buf)
        {
            log.Info("begin decompress");

            long totalLength = 0;
            int size = 0;
            byte[] retByte;
            bool readed = false;
            MemoryStream memoryStream = new MemoryStream();
            MemoryStream retMemoryStream = new MemoryStream();
            memoryStream.Write(buf, 0, buf.Length);
            memoryStream.Seek(0, SeekOrigin.Begin);
            GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
            while (true)
            {
                size = gZipStream.ReadByte();
                if (size != -1)
                {
                    if (!readed)
                    {
                        readed = true;
                    }
                    totalLength++;
                    retMemoryStream.WriteByte((byte)size);
                }
                else
                {
                    if (readed)
                    {
                        break;
                    }
                }
            }
            gZipStream.Close();
            retByte = retMemoryStream.ToArray();
            retMemoryStream.Close();

            log.Info("decompress success");

            return retByte;
        }

        #endregion

        #region 判断一个byte[]是否被压缩过

        /// <summary>
        /// 判断一个byte[]是否被压缩过
        /// </summary>
        /// <param name="buf">任意byte数组</param>
        /// <returns>压缩过返回true,未被压缩过返回false</returns>
        public bool isZipCompressed(byte[] buf)
        {
            byte[] sub = {31,139,8,0,0,0,0,0,4,0,237,189,7,96,28,73,150,37,38,47,
                         109,202,123,127,74,245,74,215,224,116,161,8,128,96,
                         19,36,216,144,64,16,236,193,136,205,230,146,236,29,
                         105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,
                         204,237,157,188,247,222,123,239,189,247,222,123,239,
                         189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,
                         108,246,206,74,218,201,158,33,128};       //zip算法压缩文件头byte数组
            if (buf.Count() < 100)
            {
                return false;
            }
            else
            {
                int num = 0;
                for (int i = 0; i < sub.Count(); i++)
                {
                    if (buf[i] == sub[i])
                    {
                        num++;
                    }
                }
                if (num == 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region 判断是否byte[]是否需要被压缩

        /// <summary>
        /// 判断是否byte[]是否需要被压缩
        /// </summary>
        /// <param name="buf">序列化之后的参数</param>
        /// <returns>需要压缩返回true,不需要压缩返回false</returns>
        public bool isNeedCompressed(byte[] buf)
        {
            int temp = 0;    //压缩的临界值，初始设置为3Mb
            if (buf.Count() > temp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
