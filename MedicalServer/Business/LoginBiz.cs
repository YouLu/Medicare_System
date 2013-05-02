using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Util;
using Medical.Framework.ADO;
using Medical.Framework.Base.Entity;
using Medical.Framework.Base.Impl;

namespace Business
{
    public class LoginBiz : AbsBizBase
    {
        public AppParam Login(AppParam appParam)
        {
            AppParam retParam = new AppParam();
            DbAccess access = new DbAccess();
            string userId = (string)appParam.Get("userId");
            UserEntity userEntity = access.GetUserEntity(userId);
            List<MenuEntity> list = access.GetMenuList(userId);
            Dictionary<string, SubScreenEntity> dictionary = access.GetMenuScreenMap(userId);
            retParam.Add("userEntity", userEntity);
            retParam.Add("menuList", list);
            retParam.Add("dictionary", dictionary);
            return retParam;
        }
    }
}
