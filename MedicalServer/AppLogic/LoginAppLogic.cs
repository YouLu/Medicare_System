using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Base.Impl;
using Medical.Framework.Util;
using Medical.Framework.ADO;
using Medical.Framework.Base.Entity;
using Business;

namespace AppLogic
{
    public class LoginAppLogic : AbsAppLogicBase
    {
        public AppParam GetCodeNameMap(AppParam appParam)
        {
            CodeNameBiz codeNameBiz = CreateBizInstance(typeof(CodeNameBiz)) as CodeNameBiz;
            return codeNameBiz.GetCodeNameMap();
        }

        public AppParam GetMessageMap(AppParam appParam)
        {
            MessageBiz messageBiz = CreateBizInstance(typeof(MessageBiz)) as MessageBiz;
            return messageBiz.GetMessageMap();
        }

        public AppParam Login(AppParam appParam)
        {
            LoginBiz loginBiz = CreateBizInstance(typeof(LoginBiz)) as LoginBiz;
            return loginBiz.Login(appParam);
        }
    }
}
