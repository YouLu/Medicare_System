using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace Medical.Framework.Util
{
    public class ZipAppParam
    {
        #region  初始化 log4net
        /// <summary>
        /// 初始化 log4net
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
    }
}
