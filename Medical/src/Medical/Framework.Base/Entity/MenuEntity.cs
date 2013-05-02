//----------------------------------------------------------- 
// 
// 系统名  : MedicalSystem 
// 作者    :  王梓烨
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Base.Impl;

namespace Medical.Framework.Base.Entity
{
    [Serializable]
    public class MenuEntity : BaseEntity
    {
        public MenuEntity(string menuId) 
        {
            this.menuId = menuId;
        
        
        }


        public MenuEntity() 
        {
        
        
        
        }

        public MenuEntity(string menuId,string menuName,string menuLevel,string parentMenuId) 
        {
            this.menuId = menuId;
            this.menuName = menuName;
            this.parentMenuId = parentMenuId;
            this.menuLevel = menuLevel;
        
        
        
        }

        private string menuId;

        public string MenuId
        {
            get { return menuId; }
            set { menuId = value; }
        }

        private string menuName;

        public string MenuName
        {
            get { return menuName; }
            set { menuName = value; }
        }

        private string subScreenId;

        public string SubScreenId
        {
            get { return subScreenId; }
            set { subScreenId = value; }
        }

        private string menuLevel;

        public string MenuLevel
        {
            get { return menuLevel; }
            set { menuLevel = value; }
        }


        private string parentMenuId;

        public string ParentMenuId
        {
            get { return parentMenuId; }
            set { parentMenuId = value; }
        }
















    }
}
