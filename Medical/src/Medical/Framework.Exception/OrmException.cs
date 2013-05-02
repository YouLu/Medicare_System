using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Constant;

namespace Medical.Framework.Exception
{
    class OrmException : AppException
    {
        public OrmException(string message)
            : base("ERROR009", new Object[] { message })
        {

        }
    }
}
