using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Exception;

namespace Medical.Framework.Exception
{
    public class ContainerInitException : AppException
    {
        private const string EXCEPTION_CODE = "ERROR006";

        public ContainerInitException() 
            : base(EXCEPTION_CODE, new Object[] { })
        {
        
        }
    }
}
