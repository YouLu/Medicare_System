using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Framework.Exception
{
    class AppConfigException : AppException
    {
        private const string EXCEPTION_CODE = "ERROR007";

        public AppConfigException()
            : base(EXCEPTION_CODE, new Object[] { })
        { 
            
        }
    }
}
