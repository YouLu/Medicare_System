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
    public class FunctionKeyEventArgs:MedicalSystemEventArgs
    {



        private FunctionKeyEntity functionKeyEntity;

        public FunctionKeyEntity FunctionKeyEntity
        {
            get { return functionKeyEntity; }
            set { functionKeyEntity = value; }
        }


        public FunctionKeyEventArgs(FunctionKeyEntity functionKeyEntity)
            : base(MedicalSystemEventArgs.MedicalSystemEventType.FunctionArea)
        {
            this.functionKeyEntity = functionKeyEntity;
        }


    }
}
