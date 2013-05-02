﻿//----------------------------------------------------------- 
// 
// 系统名  : MedicalSystem 
// 作者    :  王梓烨
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Pf.Common.Entity
{
    public class UserEntity
    {
        public UserEntity() 
        {
        
        
        }

        public UserEntity(string userId,string userName,string password,string roleId) 
        {
            this.userId = userId;
            this.userName = userName;
            this.password = password;
            this.roleId = roleId;
        
        
        
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string roleId;

        public string RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }








    }
}
