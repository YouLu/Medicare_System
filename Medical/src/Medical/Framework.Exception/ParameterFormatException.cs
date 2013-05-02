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
    public class ParameterFormatException :AppException
    {
        private const string EXCEPTION_CODE = ExceptionCode.ERROR036;

        public ParameterFormatException(string paramName)
            : base(EXCEPTION_CODE, new object[] { paramName })
        {
 
        }
    }
}
