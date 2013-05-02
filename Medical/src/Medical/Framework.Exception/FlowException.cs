using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Constant;

namespace Medical.Framework.Exception
{
    class FlowException : AppException
    {
        private const string EXCEPTION_CODE = ExceptionCode.ERROR005;

        public FlowException()
            : base (EXCEPTION_CODE,new Object[]{}) 
        {
            
        }

        public FlowException(string type)
            : base(EXCEPTION_CODE, new Object[] { type })
        {

        }
    }
}
