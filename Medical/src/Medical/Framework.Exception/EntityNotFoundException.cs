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
    public class EntityNotFoundException : AppException
    {   
        private const string EXCEPTION_CODE = ExceptionCode.ERROR031;
        public EntityNotFoundException()
            :base(EXCEPTION_CODE,new object[]{})
        {
 
        }
    }
}
