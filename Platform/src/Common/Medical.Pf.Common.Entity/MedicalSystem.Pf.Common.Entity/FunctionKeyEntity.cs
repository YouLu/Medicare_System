//----------------------------------------------------------- 
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
    public class FunctionKeyEntity
    {

        public FunctionKeyEntity() 
        {
        
        
        
        }


        public FunctionKeyEntity(FncType functionKeyType, string functionKeyname, bool visibility, bool effectiveness)
        {
            this.functionKeyType = functionKeyType;
            this.functionKeyname = functionKeyname;
            this.visibility = visibility;
            this.effectiveness = effectiveness;
        }


        private FncType functionKeyType;

        public FncType FunctionKeyType
        {
            get { return functionKeyType; }
            set { functionKeyType = value; }
        }


        private string functionKeyname;

        public string FunctionKeyname
        {
            get { return functionKeyname; }
            set { functionKeyname = value; }
        }




        private bool visibility;

        public bool Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }

        private bool effectiveness;

       
        public bool Effectiveness
        {
            get { return effectiveness; }
            set { effectiveness = value; }
        }



        public enum FncType
        {
            F1 = 1,     
            F2 = 2,    
            F3 = 3,    
            F4 = 4,     
            F5 = 5,     
            F6 = 6,     
            F7 = 7,    
            F8 = 8,    
            F9 = 9,     
            F10 = 10,    
            F11 = 11,   
            F12 = 12   
        }










    }
}
