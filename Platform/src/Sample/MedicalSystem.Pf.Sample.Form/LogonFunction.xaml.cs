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
using Medical.Framework.Base.Entity;

namespace MedicalSystem.Pf.Sample.Form
{
    /// <summary>
    /// LogonFunction.xaml の相互作用ロジック
    /// </summary>
    public partial class LogonFunction : MedicalSystemScreenBase,IBusinessScreen
    {

        private List<Button> buttonList = new List<Button>();
        private List<FunctionKeyEntity> functionKeyList;
        
        private Object[] param;

        public Object[] Param
        {
            get { return param; }
            set { param = value; }
        }

      


        
        
        
        public LogonFunction()
        {

            InitializeComponent();
            buttonList.Add(this.button1);
            buttonList.Add(this.button2);
            buttonList.Add(this.button3);
            buttonList.Add(this.button4);
            buttonList.Add(this.button5);
            buttonList.Add(this.button6);


           
        }

        #region IBusinessScreen メンバ

       


        public List<FunctionKeyEntity> GetFunctionAreaInfo()
        {					
            List<FunctionKeyEntity> functionKeyList = new List<FunctionKeyEntity>();
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F1, "帮助", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F2, "自己血採血予定一覧", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F3, "F3", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F4, "F4", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F5, "F5", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F6, "F6",true, true));
    
          
            return functionKeyList;
        }

        

 

        public void FunctionBtnClick(FunctionKeyEntity functionKey)
        {
            ScreenEventArgs args;
            try
            {
                switch (functionKey.FunctionKeyType)
                {
                    case FunctionKeyEntity.FncType.F6:

                        MessageBoxWindow.Show("message","message");

                        break;

                    case FunctionKeyEntity.FncType.F2:




                        break;

                    case FunctionKeyEntity.FncType.F1:

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
            functionKeyList = this.GetFunctionAreaInfo();
            for (int i = 0; i < functionKeyList.Count; i++)
            {
                buttonList[i].Content = functionKeyList[i].FunctionKeyname;
                buttonList[i].IsEnabled = functionKeyList[i].Effectiveness;
                if (functionKeyList[i].Visibility == true)
                {
                    buttonList[i].Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    buttonList[i].Visibility = System.Windows.Visibility.Collapsed;
                }
            }




        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            FunctionBtnClick(functionKeyList[0]);
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            FunctionBtnClick(functionKeyList[1]);

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            FunctionBtnClick(functionKeyList[2]);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            FunctionBtnClick(functionKeyList[3]);
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            FunctionBtnClick(functionKeyList[4]);
        }
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            FunctionBtnClick(functionKeyList[5]);
        }
       
   }
}
