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
using MedicalSystem.pf.Common.Event;
using Medical.Framework.Base.Entity;



namespace MedicalSystem.Pf.UIControl.Form
{
    /// <summary>
    /// FunctionKeyArea.xaml の相互作用ロジック
    /// </summary>
    public partial class FunctionKeyArea : UserControl,IArea
    {

        #region log4net　ログ部品の初期化
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        private List<Button> buttonList = new List<Button>();
        private List<FunctionKeyEntity> functionKeyList= new List<FunctionKeyEntity>();
        

       


        public FunctionKeyArea()
        {
            InitializeComponent();

            buttonList.Add(this.button1);
            buttonList.Add(this.button2);
            buttonList.Add(this.button3);
            buttonList.Add(this.button4);
            buttonList.Add(this.button5);
            buttonList.Add(this.button6);
            buttonList.Add(this.button7);
            buttonList.Add(this.button8);
            buttonList.Add(this.button9);
            buttonList.Add(this.button10);
            buttonList.Add(this.button11);
            buttonList.Add(this.button12);




            foreach (Button btn in buttonList)
            {
                btn.Visibility = System.Windows.Visibility.Collapsed;
            }      
        }








        public void Clear() 
        {

            foreach (Button btn in buttonList)
            {
                btn.Visibility = System.Windows.Visibility.Collapsed;
            }   
        
    
        
        }
        public void UpdateArea(object obj)
        {
            log.Info("FunctionKeyArea UpdateArea Start!----------------------------------");
            functionKeyList = (List<FunctionKeyEntity>)obj;


            foreach (Button button in buttonList)
            {
                button.Background = Brushes.Black;
            }
            for (int i = 0; i < functionKeyList.Count; i++)
            {
                buttonList[i].Content =functionKeyList[i].FunctionKeyname;
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
            log.Info("FunctionKeyArea UpdateArea End!----------------------------------");

        }




    

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


        public void SendEvent(object sender, MedicalSystem.pf.Common.Event.MedicalSystemEventArgs e)
        {
            eventHandler(sender,e);
        }

        #endregion




        public void ButtonClick(int index)
        {

            foreach (Button button in buttonList)
            {
                button.Background = Brushes.Black;
            }
            this.buttonList[index].Background = Brushes.SteelBlue;
            SendEvent(this.buttonList[index], new FunctionKeyEventArgs(this.functionKeyList[index]));
        }








        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(0);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(1);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(2);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(3);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(4);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(5);
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(8);
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(9);
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(10);
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(11);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(6);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(7);
        }


        













    }
}
