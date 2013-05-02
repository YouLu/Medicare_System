using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Framework.Container.Util
{
    public class RequestUtil
    {
        private string classKey;
        private string method;

        public string ClassKey
        {
            get { return classKey; }
            set { classKey = value; }
        }
       

        public string Method
        {
            get { return method; }
            set { method = value; }
        }
    }
}
