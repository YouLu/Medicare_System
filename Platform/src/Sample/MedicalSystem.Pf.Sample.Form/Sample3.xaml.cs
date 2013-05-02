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
using Medical.Framework.Base.Entity;
using Medical.Framework.Exception;
using MedicalSystem.Pf.MessageBox.Form;


namespace MedicalSystem.Pf.Sample.Form
{
    /// <summary>
    /// sample3.xaml の相互作用ロジック
    /// </summary>
    public partial class Sample3 : MedicalSystemScreenBase,IBusinessScreen
    {

        private Object[] param;

        public Object[] Param
        {
            get { return param; }
            set { param = value; }
        }

     



      
        public Sample3()
        {
            InitializeComponent();
        }

        #region IBusinessScreen メンバ

      

        public List<FunctionKeyEntity> GetFunctionAreaInfo()
        {
				

            List<FunctionKeyEntity> functionKeyList = new List<FunctionKeyEntity>();
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F1, "帮助", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F2, "自己血採血予定一覧", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F3, "F3", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F4, "F4", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F5, "F5", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F6, "F6", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F7, "F7", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F8, "F8", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F9, "F9", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F10, "F10", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F11, "F11", false, true));
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

                    case FunctionKeyEntity.FncType.F1:
                  
                        string helpContent = "各患者采血履历帮助";
                        args = new ScreenEventArgs(new MenuEntity("F1"), new Object[] { helpContent }, ScreenEventArgs.TransferScreenType.PopUp);
                        SendEvent(functionKey, args);
                        

                        break;

                    case FunctionKeyEntity.FncType.F2:
                        args = new ScreenEventArgs(new MenuEntity("1_1"), null, ScreenEventArgs.TransferScreenType.Content);
                        SendEvent(functionKey, args);
                        break;

                    case FunctionKeyEntity.FncType.F10:

                        break;

                    case FunctionKeyEntity.FncType.F11:


                        break;

                    default:

                        break;

                }
            }
            catch(AppException ex)
            {
                MessageBoxWindow.ShowMessage(ex);
            
            
            }
            catch(Exception ex)
            {
               
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
            eventHandler(sender, e);
        }

        #endregion

        private void MedicalSystemScreenBase_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
