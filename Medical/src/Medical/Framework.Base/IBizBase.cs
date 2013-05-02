using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Util;
using Medical.Framework.Base.Impl;
namespace Medical.Framework.Base
{
    public interface IBizBase
    {
        DaoType CreateDaoInstance<DaoType>();
        BaseDao CreateDaoInstance(Type typeOfDao);
    }
}
