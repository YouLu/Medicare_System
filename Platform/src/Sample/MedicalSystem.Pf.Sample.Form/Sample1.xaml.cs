//----------------------------------------------------------- 
// 
// 系统名  : MedicalSystem 
// 作者    :  王梓烨
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MedicalSystem.Pf.Common.ScreenTemplate;
using MedicalSystem.pf.Common.Event;
using System.Reflection;
using Medical.Framework.Base.Entity;

using MedicalSystem.Pf.Common.Context;

namespace MedicalSystem.Pf.Sample.Form
{
    /// <summary>
    /// Sample1.xaml の相互作用ロジック
    /// </summary>
    public partial class Sample1 : MedicalSystemScreenBase,IBusinessScreen
    {


        private Object[] param;

        public Object[] Param
        {
            get { return param; }
            set { param = value; }
        }

       


        
        
        
        public Sample1()
        {

            InitializeComponent();
        }

        #region IBusinessScreen メンバ

       


        public List<FunctionKeyEntity> GetFunctionAreaInfo()
        {					
            List<FunctionKeyEntity> functionKeyList = new List<FunctionKeyEntity>();
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F1, "F1", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F2, "F2", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F3, "F3", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F4, "F4", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F5, "F5", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F6, "F6", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F7, "F7", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F8, "F8", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F9, "F9	", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F10, "F10", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F11, "F11", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F12, "录入", true, true));
            return functionKeyList;
        }

        public void FunctionBtnClick(FunctionKeyEntity functionKey)
        {
            ScreenEventArgs args;
            try
            {
                switch (functionKey.FunctionKeyType)
                {


                    case FunctionKeyEntity.FncType.F9:
                        MedicalSystemMessage message = MedicalSystemContext.GetInstance().MessageMap["PF0001"];
                        string formatMessage = message.DetailMessage;
                        string fullMessage = string.Format(formatMessage,new Object[]{"Wangziye"});
                        args = new ScreenEventArgs(new MedicalSystemMessage(fullMessage),ScreenEventArgs.TransferScreenType.Message);
                        SendEvent(functionKey,args);
                        break;
          
                    case FunctionKeyEntity.FncType.F12:
                       


                        break;

                    default:

                        break;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #region ISendEvent メンバ

        public event MedicalSystemEventArgs.MedicalSystemEventHandler eventHandler;


        public event MedicalSystemEventArgs.MedicalSystemEventHandler EventHandler
        {
            add
            {
                eventHandler += value;
            }
            remove
            {
                eventHandler -= value;
            }
        }

        public void SendEvent(object sender, MedicalSystemEventArgs e)
        {
            eventHandler(sender,e);
        }

        #endregion

        private void MedicalSystemScreenBase_Loaded(object sender, RoutedEventArgs e)
        {

        }

 



    }
}
