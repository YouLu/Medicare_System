//----------------------------------------------------------- 
// 
// 系统名  : MedicalSystem 
// 作者    :  王梓烨
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.pf.Common.Event
{
    public class MedicalSystemEventArgs: EventArgs
    {
        
        public delegate bool MedicalSystemEventHandler(Object sender,MedicalSystemEventArgs e);


        private MedicalSystemEventType type;

        public MedicalSystemEventType Type
        {
            set { type = value; }
            get { return type; }
        }

        private object data;

        public object Data
        {
            set { data = value; }
            get { return data; }
        }

        public MedicalSystemEventArgs(MedicalSystemEventType t)
        {
            this.Type = t;
        }

        public enum MedicalSystemEventType
        {

            GlobalMenuArea = 1,
            SubMenuArea = 2,
            FunctionArea = 3,
            MessageArea = 4,
            Screen = 5,
            HeaderArea =6
        }

    }
}
