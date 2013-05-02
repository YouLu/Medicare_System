using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Base.Impl;
using Medical.Framework.Util;
using Business;

namespace AppLogic
{
    public class SampleAppLogic : AbsAppLogicBase
    {
        public AppParam GetUserByGuid(AppParam appParam)
        {
            SampleBiz sampleBiz = CreateBizInstance(typeof(SampleBiz)) as SampleBiz;
            return sampleBiz.GetUserByGuid(appParam);
        }

        public AppParam GetAll(AppParam appParam)
        {
            SampleBiz sampleBiz = CreateBizInstance(typeof(SampleBiz)) as SampleBiz;
            return sampleBiz.GetAll();
        }

        public AppParam ShowRollBack(AppParam appParam)
        {
            SampleBiz sampleBiz = CreateBizInstance(typeof(SampleBiz)) as SampleBiz;
            return sampleBiz.ShowRollBack(appParam);
        }

        public AppParam GetAllName(AppParam appParam)
        {
            SampleBiz sampleBiz = CreateBizInstance(typeof(SampleBiz)) as SampleBiz;
            return sampleBiz.GetAllName(appParam);
        }
    }
}
