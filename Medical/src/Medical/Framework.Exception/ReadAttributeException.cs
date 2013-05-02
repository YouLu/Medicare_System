using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Constant;

namespace Medical.Framework.Exception
{
    public class ReadAttributeException :AppException
    {
        private const string EXCEPTION_CODE = ExceptionCode.ERROR033;

        public ReadAttributeException()
            : base(EXCEPTION_CODE, new object[] { })
        {
 
        }
    }
}
