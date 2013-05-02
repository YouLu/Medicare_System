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

namespace MedicalSystem.Pf.MessageBox.Form
{
    /// <summary>
    /// MessageBoxWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MessageBoxWindow : Window
    {
        #region log4net　ログ部品の初期化
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
   
        //图标常量
        public const string ICON_ERROR = "E";

        
        public const string ICON_WARNING = "W";


        public const string ICON_QUESTION = "C";



        //按钮常量
        public const string BUTTONS_OK_CANCEL = "OKCancel";

        public const string BUTTONS_YES_NO = "YesNo";

        public const string BUTTONS_OK = "OK";

        public const string BUTTONS_YES_NO_CANCEL = "YesNoCancel";

        //显示隐藏常量
        public const string VISIBILITY_VISIBLE = "VISIBLE";
        public const string VISIBILITY_HIDE = "HIDE";


       
     

        public static MessageBoxResult Show(string i_DetaileMessage, string i_Icon)
        {
            return MessageBoxWindow.ShowMessage(null, null, i_DetaileMessage, i_Icon, SetBottunAtIcon(i_Icon));
        }
  
        public static MessageBoxResult Show(string i_BriefeMessage, string i_DetaileMessage, string i_Icon)
        {
            return MessageBoxWindow.ShowMessage(null, i_BriefeMessage, i_DetaileMessage, i_Icon, SetBottunAtIcon(i_Icon));
        }


        public static MessageBoxResult ShowMessage(string i_Title, string i_BriefeMessage, string i_DetaileMessage, string i_Icon, string i_Button)
        {
            log.Info("MessageBoxWindow ShowMessge Of String Start!----------------------------------");
            MessageBoxWindow window = new MessageBoxWindow(i_Title, i_BriefeMessage, i_DetaileMessage, i_Icon, i_Button);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
            log.Info("MessageBoxWindow ShowMessge End!----------------------------------");
            return window.result;
           
            
        }




  
       public static MessageBoxResult ShowMessage(Exception exp)
        {
            log.Info("MessageBoxWindow ShowMessge Of Exception Start!----------------------------------");

            MedicalSystemErrorMessageBox  window = new MedicalSystemErrorMessageBox(exp);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
            log.Info("MessageBoxWindow ShowMessge Of Exception End!----------------------------------");
            return window.result;
        }
   

        private string title;


        private string briefeMessage;


        private string detaileMessage;


        private string icon;


        private string button;



        public MessageBoxResult result;





       
        public MessageBoxWindow(string i_Title, string i_BriefeMessage, string i_DetaileMessage, string i_Icon, string i_BtnType)
        {
            this.title = i_Title;                     
            this.detaileMessage = i_DetaileMessage;     
            this.icon = i_Icon;                       
            this.button = i_BtnType;                
            InitializeComponent();


        }



 
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
          

         
    
            if (this.detaileMessage != null)
            {
                if (this.detaileMessage.Length % 10 == 0)
                { 
                    
                
                }
                this.DETAIL.Text = this.detaileMessage;
            }

  
            this.DisplayIcon();


            this.DisplayButton();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClick(sender);
        }

        
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClick(sender);
        }

      
        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClick(sender);
        }

        
        private void BtnClick(object sender)
        {

            Button btn = (Button)sender;
            if (btn.Content.Equals("YES"))
            {
                result = MessageBoxResult.Yes;
           
            }
            else if (btn.Content.Equals("NO"))
            {
                result = MessageBoxResult.No;
            }
            else if (btn.Content.Equals("OK"))
            {
                result = MessageBoxResult.OK;
            }
            else if (btn.Content.Equals("CANCEL"))
            {
                result = MessageBoxResult.Cancel;
            }

            // メッセージボックスを閉じる
            this.Close();
        }




        private void DisplayIcon()
        {
            switch (this.icon)
            {
                case ICON_ERROR:
                    this.ICONERROR.Visibility = Visibility.Visible;
                    this.ICONWARNING.Visibility = Visibility.Hidden;
                    this.ICONINFORMATION.Visibility = Visibility.Hidden;
                    this.ICONQUESTION.Visibility = Visibility.Hidden;
                    break;

                case ICON_WARNING:
                    this.ICONERROR.Visibility = Visibility.Hidden;
                    this.ICONWARNING.Visibility = Visibility.Visible;
                    this.ICONINFORMATION.Visibility = Visibility.Hidden;
                    this.ICONQUESTION.Visibility = Visibility.Hidden;
                    break;


                case ICON_QUESTION:
                    this.ICONERROR.Visibility = Visibility.Hidden;
                    this.ICONWARNING.Visibility = Visibility.Hidden;
                    this.ICONINFORMATION.Visibility = Visibility.Hidden;
                    this.ICONQUESTION.Visibility = Visibility.Visible;
                    break;

                default:
                    this.ICONERROR.Visibility = Visibility.Hidden;
  
                    this.ICONWARNING.Visibility = Visibility.Hidden;
                    this.ICONINFORMATION.Visibility = Visibility.Hidden;
                    this.ICONQUESTION.Visibility = Visibility.Hidden;
                    break;
            }

        }

     
        private void DisplayButton()
        {
         
            switch (this.button)
            {
                case BUTTONS_OK:
                    this.BUTTON1.Visibility = Visibility.Hidden;
                    this.BUTTON2.Visibility = Visibility.Hidden;
                    this.BUTTON3.Content = "OK";
                    break;
                case BUTTONS_OK_CANCEL:
                    this.BUTTON1.Visibility = Visibility.Hidden;
                    this.BUTTON2.Content = "OK";
                    this.BUTTON3.Content = "CANCEL";
                    break;

                case BUTTONS_YES_NO:
                    this.BUTTON1.Visibility = Visibility.Hidden;
                    this.BUTTON2.Content = "YES";
                    this.BUTTON3.Content = "NO";
                    break;
                case BUTTONS_YES_NO_CANCEL:
                    this.BUTTON1.Content = "YES";
                    this.BUTTON2.Content = "NO";
                    this.BUTTON3.Content = "CANCEL";
                    break;

                default:
                    this.BUTTON1.Visibility = Visibility.Hidden;
                    this.BUTTON2.Visibility = Visibility.Hidden;
                    this.BUTTON3.Content = "OK";
                    break;
            }

           
            this.BUTTON3.Focus();
        }


        private static string SetBottunAtIcon(string i_Icon)
        {
            string button;

 
            switch (i_Icon)
            {
                case ICON_ERROR:
                    button = BUTTONS_OK;
                    break;

                case ICON_WARNING:
                    button = BUTTONS_OK;
                    break;
                case ICON_QUESTION:
                    button = BUTTONS_YES_NO;
                    break;

                default:
                    button = BUTTONS_OK;
                    break;
            }
            return button;
        }





    }
}
