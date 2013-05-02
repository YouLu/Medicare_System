using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Base.Impl;
using Entity;
using Dao;
using System.Collections;

namespace Business
{
    public class MstDoctorBiz : AbsBizBase
    {
        public IList GetAllMstDoctor()
        {
            MstDoctorDao doctorDao = CreateDaoInstance(typeof(MstDoctorDao)) as MstDoctorDao;
            IList doctorList = doctorDao.FindAllEntity();
            return doctorList;
        }
    }
}
