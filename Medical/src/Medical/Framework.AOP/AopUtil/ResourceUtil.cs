/*
 * 作者:李博
 * 日期:2009.3.10
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using Medical.Framework.Exception;
namespace Medical.Framework.AOP.AopUtil
{
    public class ResourceUtil 
    {
        public Stream GetResourceNoException(string path, Assembly asm)
        {

            if (asm == null)
            {
                return null;
            }


            if (asm is AssemblyBuilder)
            {
                return null;
            }

            Stream stream = asm.GetManifestResourceStream(path);

            return stream;
        }

        public bool IsExist(string path, Assembly asm)
        {
            return GetResourceNoException(path, asm) != null;
        }

        public StreamReader GetResourceAsStreamReader(string path)
        {
            return GetResourceAsStreamReader(path, Assembly.GetEntryAssembly());
        }

        public StreamReader GetResourceAsStreamReader(string path, Assembly assembly)
        {
            return new StreamReader(GetResourceAsStream(path, assembly));
        }

        public Stream GetResourceAsStream(string path, Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }
            Stream stream = GetResourceNoException(path, assembly);
            if (stream != null)
            {
                return stream;
            }
            else
            {
                throw new SqlFileNotFoundException(path);
            }
        }
    }
}
