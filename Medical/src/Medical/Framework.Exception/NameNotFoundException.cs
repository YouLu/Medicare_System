using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Constant;

namespace Medical.Framework.Exception
{
    class NameNotFoundException : AppException
    {
        private const string EXCEPTION_CODE = ExceptionCode.ERROR002;

        public NameNotFoundException(string key)
            : base(EXCEPTION_CODE, new Object[] { key })
        {

        }
    }
}
