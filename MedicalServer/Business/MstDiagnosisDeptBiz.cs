using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Base.Impl;
using Dao;
using System.Collections;

namespace Business
{
    public class MstDiagnosisDeptBiz : AbsBizBase
    {
        public IList GetAllMstDiagnosisDept()
        {
            MstDiagnosisDeptDao diagnosisDeptDao = CreateDaoInstance(typeof(MstDiagnosisDeptDao)) as MstDiagnosisDeptDao;
            IList diagnosisDeptList = diagnosisDeptDao.FindAllEntity();
            return diagnosisDeptList;
        }
    }
}
