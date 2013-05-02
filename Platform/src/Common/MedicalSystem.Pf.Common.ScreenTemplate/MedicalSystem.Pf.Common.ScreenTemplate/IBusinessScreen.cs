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
using Medical.Framework.Base.Entity;


namespace MedicalSystem.Pf.Common.ScreenTemplate
{

    public interface IBusinessScreen :ISendEvent
    {

       
        //传递的参数
         Object[] Param
        {
            set;
            get;
        }

      


        //得到该画面所用到的功能键
        List<FunctionKeyEntity> GetFunctionAreaInfo();

        //功能键事件处理函数
        void FunctionBtnClick(FunctionKeyEntity info);



        

    }
}














