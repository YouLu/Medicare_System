using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.AOP.Attrs;
using Entity;
using Medical.Framework.Base.Impl;

namespace Dao
{
    [Bean(typeof(MstWardEntity))]
    public abstract class MstWardDao : BaseDao
    {
    }
}
