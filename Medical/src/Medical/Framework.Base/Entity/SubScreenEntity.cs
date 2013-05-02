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
    public class SubScreenEntity : BaseEntity
    {

        public SubScreenEntity() 
        {
        
        
        
        }
        public SubScreenEntity(string screenId,string name,string assemblyName,string className) 
        {
            this.screenId = screenId;
            this.name = name;
            this.assemblyName = assemblyName;
            this.className = className;           
        }





        private string screenId;

        public string ScreenId
        {
            get { return screenId; }
            set { screenId = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string assemblyName;

        public string AssemblyName
        {
            get { return assemblyName; }
            set { assemblyName = value; }
        }


        private string className;

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

 

    }
}
