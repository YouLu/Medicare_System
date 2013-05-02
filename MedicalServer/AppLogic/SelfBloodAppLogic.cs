using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Base.Impl;
using Medical.Framework.Util;
using Business;
using Entity;
using System.Collections;

namespace AppLogic
{
    class SelfBloodAppLogic : AbsAppLogicBase
    {
        public AppParam GetReserveInfo(AppParam appParam)
        {
            AppParam retParam = new AppParam();
            //患者基本信息和身体信息
            PatientBiz patientBiz = CreateBizInstance(typeof(PatientBiz)) as PatientBiz;
            PatientEntity patient = patientBiz.GetPatientByID(appParam);
            //受付信息
            MstOrderBiz mstOrderBiz = CreateBizInstance(typeof(MstOrderBiz)) as MstOrderBiz;
            MstOrderEntity mstOrderEntity = mstOrderBiz.GetLeastOrder(appParam);            
            retParam.Add("patient",patient);
            retParam.Add("MstOrderEntity", mstOrderEntity);
            return retParam;
        }

        public AppParam DeleteOrder(AppParam appParam)
        {
            MstOrderBiz mstOrderBiz = CreateBizInstance(typeof(MstOrderBiz)) as MstOrderBiz;
            AppParam retParam = new AppParam();
            bool flag = mstOrderBiz.DeleteOrder(appParam);
            retParam.Add("deleteFlag", flag);
            return retParam;
        }

        public AppParam Init(AppParam appParam)
        {
            AppParam retParam = new AppParam();
            //医生信息
            MstDoctorBiz mstDoctorBiz = CreateBizInstance(typeof(MstDoctorBiz)) as MstDoctorBiz;
            IList doctorList = mstDoctorBiz.GetAllMstDoctor();
            //病房信息
            MstWardBiz mstWardBiz = CreateBizInstance(typeof(MstWardBiz)) as MstWardBiz;
            IList mstWardList = mstWardBiz.GetAllMstWard();
            //科室信息
            MstDiagnosisDeptBiz mstDiagnosisDeptBiz = CreateBizInstance(typeof(MstDiagnosisDeptBiz)) as MstDiagnosisDeptBiz;
            IList mstDiagnosisDeptList = mstDiagnosisDeptBiz.GetAllMstDiagnosisDept();
            retParam.Add("doctorList", doctorList);
            retParam.Add("mstWardList", mstWardList);
            retParam.Add("mstDiagnosisDeptList", mstDiagnosisDeptList);
            return retParam;
        }
    }
}
