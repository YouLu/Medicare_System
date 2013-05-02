using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Util;
using Medical.Framework.Base.Impl;
using Medical.Framework.ADO;
using Medical.Framework.Base.Entity;

namespace Business
{
    public class MessageBiz : AbsBizBase
    {
        public AppParam GetMessageMap()
        {
            AppParam retParam = new AppParam();
            DbAccess access = new DbAccess();
            Dictionary<string, MedicalSystemMessage> dictionary = access.GetMessageMap();
            retParam.Add("messageMap", dictionary);
            return retParam;
        }
    }
}
