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
    /// GlobalMenuArea.xaml の相互作用ロジック
    /// </summary>
    public partial class GlobalMenuArea : UserControl,IArea
    {
        #region log4net　ログ部品の初期化
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
       
        private  List<Button> buttonList = new List<Button>();
        private  List<MenuEntity> mainMenuList =new List<MenuEntity>();



        
        public GlobalMenuArea()
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
          
            
            foreach (Button btn in buttonList)
            {
                btn.Visibility = System.Windows.Visibility.Collapsed;
            }



        }

      







        //更新该域menu的显示
        public void UpdateArea(object obj)
        {
            log.Info("GlobalMenuArea UpdateArea Start!----------------------------------");

            mainMenuList=(List<MenuEntity>)obj;
            

            for (int i = 0; i < mainMenuList.Count; i++)
            {


                if (mainMenuList[i].MenuLevel.Equals("1"))
                {
                    buttonList[i].Content = mainMenuList[i].MenuName;
                    buttonList[i].Visibility = System.Windows.Visibility.Visible;
                }
            }
            log.Info("GlobalMenuArea UpdateArea End!----------------------------------");
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



        public void SendEvent(object sender, MedicalSystemEventArgs e)
        {
           eventHandler(sender,e);
        }

        #endregion


        public void ButtonClick(Button btn, int index)
        {
            foreach (Button button in buttonList)
            {
                button.Background=Brushes.Black;
            }
           this.buttonList[index].Background = Brushes.SteelBlue;
           MenuEntity menuEntity = mainMenuList[index];
           GlobalMenuEventArgs args = new GlobalMenuEventArgs(menuEntity);
           SendEvent(this, args);
          
      
            
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick((Button)sender, 0);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick((Button)sender, 3);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick((Button)sender, 4);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick((Button)sender, 5);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick((Button)sender, 6);
        }
  

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick((Button)sender, 7);
        }
       

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick((Button)sender, 1);
      
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick((Button)sender, 2);
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

            if (this.button1.IsMouseOver)
                this.button1.Background = Brushes.Blue;
      
                this.button1.Background = Brushes.Black;
                       
          




        }
















    }
}
