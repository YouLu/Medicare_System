using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Base.Impl;
using Dao;
using System.Collections;

namespace Business
{
    public class MstWardBiz : AbsBizBase
    {
        public IList GetAllMstWard()
        {
            MstWardDao mstWardDao = CreateDaoInstance(typeof(MstWardDao)) as MstWardDao;
            IList mstWardList = mstWardDao.FindAllEntity();
            return mstWardList;
        }
    }
}
