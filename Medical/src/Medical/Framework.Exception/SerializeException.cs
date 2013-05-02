using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Constant;

namespace Medical.Framework.Exception
{
    class SerializeException : AppException
    {
        private const string EXCEPTION_CODE = ExceptionCode.ERROR004; 

        public SerializeException()
            : base(EXCEPTION_CODE, new Object[]{})
        { 
            
        }
    }
}
