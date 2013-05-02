
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
    public interface ISendEvent
    {
        event MedicalSystem.pf.Common.Event.MedicalSystemEventArgs.MedicalSystemEventHandler EventHandler;
        
        void SendEvent(Object sender, MedicalSystemEventArgs e);
    }
}
