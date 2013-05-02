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
    public class CodeNameBiz : AbsBizBase
    {
        public AppParam GetCodeNameMap()
        {
            AppParam retParam = new AppParam();
        
            CodeAccess codeAccess = new CodeAccess();
            Dictionary<string,string>  codeMap= codeAccess.GetCodeMap();
            Dictionary<string,string>  containerMap=codeAccess.GetContainerMap();
            Dictionary<string,string>  diagnosisDeptMap=codeAccess.GetDiagnosisDeptMap();
            Dictionary<string,string>  diseaseMap=codeAccess.GetDiseaseMap();
            Dictionary<string,string>  doctorMap=codeAccess.GetDoctorMap();
            Dictionary<string,string>  drugProductMap=codeAccess.GetDrugProductMap();
            Dictionary<string,string>  wardMap = codeAccess.GetWardMap();

            retParam.Add("codeMap", codeMap);
            retParam.Add("containerMap", containerMap);
            retParam.Add("diagnosisDeptMap", diagnosisDeptMap);
            retParam.Add("diseaseMap", diseaseMap);
            retParam.Add("doctorMap", doctorMap);
            retParam.Add("drugProductMap", drugProductMap);
            retParam.Add("wardMap", wardMap);
      

            return retParam;
        }
    }
}
