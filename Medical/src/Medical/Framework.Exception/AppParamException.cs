using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Constant;

namespace Medical.Framework.Exception
{
    class AppParamException : AppException
    {
        private const string EXCEPTION_CODE = ExceptionCode.ERROR003; 

        public AppParamException(string paramName)
            : base(EXCEPTION_CODE, new Object[] { paramName })
        { 
            
        }
    }
}
