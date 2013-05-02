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
using MedicalSystem.Pf.MessageBox.Form;
using MedicalSystem.Pf.Common.Context;
using System.Reflection;
using Medical.Framework.Base.Entity;


namespace MedicalSystem.Pf.Sample.Form
{
    /// <summary>
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class Sample : MedicalSystemScreenBase,IBusinessScreen
    {
       
        private   Object[] param;


        public Object[] Param
        {
            get { return param; }
            set { param = value; }
        }

       


        public Sample()
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
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F4, "F4",false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F5, "刷新画面", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F6, "F6", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F7, "F7", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F8, "F8", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F9, "F9", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F10, "F10", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F11, "采血预约登录", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F12, "F12", false, true));
            return functionKeyList;
        }

        public void FunctionBtnClick(FunctionKeyEntity functionKey)
        {
            ScreenEventArgs args;
            try
            {
                switch (functionKey.FunctionKeyType)
                {
                    
                    

                    case FunctionKeyEntity.FncType.F5:
                        
                      
                        break;


                    case FunctionKeyEntity.FncType.F11:
        
                        args = new ScreenEventArgs(new MenuEntity("bloodScheduledLogon"), null, ScreenEventArgs.TransferScreenType.PopUp);
                        SendEvent(functionKey, args);

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

      

        public void SendEvent(object sender, MedicalSystemEventArgs e)
        {
            eventHandler(sender,e);
        }



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










        #endregion

        private void MedicalSystemScreenBase_Loaded(object sender, RoutedEventArgs e)
        {
           //if (param != null)
           //     this.textBox1.Text = (string)param[0];
        }



    }
}
