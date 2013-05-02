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
    public class HeaderEventArgs : MedicalSystemEventArgs
    {
        public HeaderEventArgs()
            : base(MedicalSystemEventArgs.MedicalSystemEventType.HeaderArea)
        {

        }


    }
}
