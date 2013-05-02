//----------------------------------------------------------- 
// 
// 系统名  : MedicalSystem 
// 作者    :  王梓烨
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.pf.Common.Event;


namespace MedicalSystem.Pf.UIControl.Form
{
    public interface IArea: ISendEvent
    {
        //更新域
        void UpdateArea(object obj);
    }
}
