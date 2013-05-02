using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Util;
using System.Data;
using Medical.Framework.Base.Impl;

namespace Medical.Framework.Base
{
    public interface IAppLogicBase
    {
        AppParam DoApplication(AppParam appParam, AbsAppLogicBase appLogicBase);
    }
}
