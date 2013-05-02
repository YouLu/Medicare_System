/*
 * 日期：2009-3-30
 * 作者：吕游
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Constant;

namespace Medical.Framework.Exception
{
    public class ClassNotFoundException : AppException
    {

        #region ClassNotFoundException对应异常编号是ERROR001

        private const string EXCEPTION_CODE = ExceptionCode.ERROR001;

        public ClassNotFoundException(string className)
            : base(EXCEPTION_CODE, new Object[] { className })
        { 
         
        }

        #endregion
    }
}
