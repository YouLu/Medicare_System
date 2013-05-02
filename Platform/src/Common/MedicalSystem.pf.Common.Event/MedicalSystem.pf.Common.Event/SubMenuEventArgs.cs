//----------------------------------------------------------- 
// 
// 系统名  : MedicalSystem 
// 作者    :  王梓烨
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Base.Entity;


namespace MedicalSystem.pf.Common.Event
{
    public class SubMenuEventArgs:MedicalSystemEventArgs
    {
        private MenuEntity menuEntity;

        public MenuEntity MenuEntity
        {
            get { return menuEntity; }
            set { menuEntity = value; }

        }

    
        public SubMenuEventArgs(MenuEntity menuEntity)
            : base(MedicalSystemEventArgs.MedicalSystemEventType.SubMenuArea)
        {
            this.menuEntity = menuEntity;



        }





    }
}
