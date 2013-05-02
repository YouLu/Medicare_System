using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Medical.Framework.Base.Impl;
using Medical.Framework.AOP.Attrs;

namespace Dao
{
    [Bean(typeof(MstDoctorEntity))]
    public abstract class MstDoctorDao : BaseDao
    {
    }
}
