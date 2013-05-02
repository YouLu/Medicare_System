/*
 * 作者:李博
 * 日期:2009.4.15
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Constant;

namespace Medical.Framework.Exception
{
    public class DatabaseQueryException : AppException
    {
        private const string EXCEPTION_CODE = ExceptionCode.ERROR037;

        public DatabaseQueryException()
            : base(EXCEPTION_CODE, new object[] { })
        {
 
        }
    }
}
