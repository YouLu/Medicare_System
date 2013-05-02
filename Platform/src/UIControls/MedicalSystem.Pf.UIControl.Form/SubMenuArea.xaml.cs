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
    /// SubMenuArea.xaml の相互作用ロジック
    /// </summary>
    public partial class SubMenuArea : UserControl,IArea
    {
        #region log4net　ログ部品の初期化
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        private List<Button> buttonList = new List<Button>();
        private List<MenuEntity> subMenuList = new List<MenuEntity>();
        
        
        
        

        
        public SubMenuArea()
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

            foreach(Button btn in buttonList)
            {
                btn.Visibility = System.Windows.Visibility.Collapsed;
            }




        }

       



        public void UpdateArea(object obj)
        {
            log.Info("SubMenuArea UpdateArea Start!----------------------------------");
            foreach (Button btn in buttonList)
            {
                btn.Visibility = System.Windows.Visibility.Collapsed;
            }

            subMenuList = (List<MenuEntity>)obj;


            for (int i = 0; i <subMenuList.Count; i++)
            {
                buttonList[i].Content = subMenuList[i].MenuName;
                buttonList[i].Visibility = System.Windows.Visibility.Visible;
            }
            foreach (Button button in buttonList)
            {
                button.Background = Brushes.Black;
            }
            log.Info("SubMenuArea UpdateArea Start!----------------------------------");
        }


        public void UpdateArea(object obj,MenuEntity menuEntity)
        {
            int index=-1;
     
           
            foreach (Button btn in buttonList)
            {
                btn.Visibility = System.Windows.Visibility.Collapsed;
            }

            subMenuList = (List<MenuEntity>)obj;


            for (int i = 0; i < subMenuList.Count; i++)
            {
                if (subMenuList[i].MenuId == menuEntity.MenuId) 
                {
                    index = i;
                }

                buttonList[i].Content = subMenuList[i].MenuName;
                buttonList[i].Visibility = System.Windows.Visibility.Visible;
            }
            foreach (Button button in buttonList)
            {
                button.Background = Brushes.Black;
            }
            this.buttonList[index].Background = Brushes.SteelBlue;

   
        }
      

       


        #region

       
        
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


        private void Button_Click(Button subMenu,int index) 
        {
            try
            {
                foreach (Button button in buttonList)
                {
                    button.Background = Brushes.Black;
                }
                this.buttonList[index].Background = Brushes.SteelBlue;

                if (subMenu!= null)
                {
                    MenuEntity menuEntity = subMenuList[index];
                    SubMenuEventArgs args = new SubMenuEventArgs(menuEntity);
                    SendEvent(this, args);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender,0);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender, 4);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender, 3);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender, 2);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender, 1);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender, 5);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender, 6);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender, 7);
        }


        private void button9_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender, 8);
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender, 9);
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender, 10);
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            Button_Click((Button)sender, 11);
        }


























    }
}
