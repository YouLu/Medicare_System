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


using MedicalSystem.Pf.MessageBox.Form;
using MedicalSystem.Pf.MainScreen.Form;
using MedicalSystem.Pf.Component.Validation;
using MedicalSystem.Pf.Common.Context;
using Medical.Framework.Base.Entity;
using MedicalSystem.Pf.Common.Proxy;
using Medical.Framework.Util;
using MedicalSystem.Pf.Common.Utility;
 
namespace MedicalSystem.Pf.Logon.Form
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class LogonScreen : Window
    {

        #region log4net　ログ部品の初期化
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        //lABAL和BUTTON上显示的常量
        public const string ID = "ID";

        public const string PASSWORD = "密码";

        public const string LOGON = "登录";

        public const string CLEAR = "清空";



        //按照用户权限所查询得到的Menu,MenuScreenMap,和系统消息信息
        private List<MenuEntity> menuList;
        private Dictionary<string, SubScreenEntity> menuScreenMap;
        private Dictionary<string, MedicalSystemMessage> messageMap;
        MedicalSystemMessage message;

      



        public LogonScreen()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(@"App.config"));
        }



        public void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.labName.Content = ID;
            this.labPassword.Content = PASSWORD;
            this.btnLogon.Content = LOGON;
            this.btnClear.Content = CLEAR;

           
            ProxyService proxy = new ProxyService();
            AppParam appParam = new AppParam();
            appParam.RequestClass = "MessageAction";
            AppParam returnParam = proxy.Execute(appParam);

            messageMap = (Dictionary<string, MedicalSystemMessage>)returnParam.Get("messageMap");
            MedicalSystemContext.GetInstance().MessageMap = messageMap;

            AppParam codeNameParam = new AppParam();
            codeNameParam.RequestClass = "CodeNameAction";
            AppParam returnCodeNameParam = proxy.Execute(codeNameParam);
            MedicalSystemContext.GetInstance().MstCodeMap = (Dictionary<string, string>)returnCodeNameParam.Get("codeMap");
            MedicalSystemContext.GetInstance().MstContainerMap = (Dictionary<string, string>)returnCodeNameParam.Get("containerMap");
            MedicalSystemContext.GetInstance().MstDiagnosisDeptMap = (Dictionary<string, string>)returnCodeNameParam.Get("diagnosisDeptMap");
            MedicalSystemContext.GetInstance().MstDiseaseMap = (Dictionary<string, string>)returnCodeNameParam.Get("diseaseMap");
            MedicalSystemContext.GetInstance().MstDoctorMap = (Dictionary<string, string>)returnCodeNameParam.Get("doctorMap");
            MedicalSystemContext.GetInstance().MstDrugProductMap = (Dictionary<string, string>)returnCodeNameParam.Get("drugProductMap");
            MedicalSystemContext.GetInstance().MstWardMap = (Dictionary<string, string>)returnCodeNameParam.Get("wardMap");




        }


     
        private void BtnClick(object sender) 
        {
            log.Info("Logon Start!----------------------------------");


           
            if (((Button)sender).Content.Equals(LOGON))
            {
                    message=MedicalSystemContext.GetInstance().MessageMap["PF0002"];
                    string userId = this.txtName.Text;
                    string password = PasswordConverter.convertToMD5Passwd(this.txtPassword.Password);
              
                //输入验证 


                    if (!MedicalSystemValidation.EngNumHalfWidthCharAndSymbolValidation(userId))
                    {
                        MessageBoxWindow.Show(message.DetailMessage, message.MessageLevel);
                        return;
                    }
                    else if (!MedicalSystemValidation.LengthValidation(userId, 1, 32))
                    {
                        MessageBoxWindow.Show( message.DetailMessage, message.MessageLevel);
         
                        return;
                    }

                    //查询该用户
                    ProxyService proxyService = new ProxyService();
                    AppParam appParam = new AppParam();
                    appParam.RequestClass = "LoginAction";
                    appParam.Add("userId", userId);
                    AppParam returnParam = proxyService.Execute(appParam);

                    UserEntity logonUser = (UserEntity)returnParam.Get("userEntity");

                    //用户不存在
                    if (userId != logonUser.UserId)
                    {
                        message = MedicalSystemContext.GetInstance().MessageMap["PF0003"];
                        MessageBoxWindow.Show(message.DetailMessage, message.MessageLevel);
                    }
                    //密码正确的情况下,显示主画面
                    else if (password.Equals(logonUser.Password))
                    {
                        menuList = (List<MenuEntity>)returnParam.Get("menuList");
                        menuScreenMap = (Dictionary<string, SubScreenEntity>)returnParam.Get("dictionary");
       
                        MedicalSystemContext.GetInstance().MenuList = menuList;
                        MedicalSystemContext.GetInstance().MenuScreenMap = menuScreenMap;
                        MedicalSystemContext.GetInstance().LogonUser = logonUser;
                    
                        new MainScreen.Form.MainScreen().Show();
                        this.Close();
                    }
                    else
                    {
                        message = MedicalSystemContext.GetInstance().MessageMap["PF0004"];
                        MessageBoxWindow.Show(message.DetailMessage, message.MessageLevel);
                    }
                                
            }

            //当点击CLEAR按钮
            else if (((Button)sender).Content.Equals(CLEAR)) 
            {

                this.txtName.Clear();
                this.txtPassword.Clear();
            
            }

            log.Info("Logon End!----------------------------------");
       
        }






        private void btnLogon_Click(object sender, RoutedEventArgs e)
        
        {
            BtnClick(sender);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            BtnClick(sender);
        }



       



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            message = MedicalSystemContext.GetInstance().MessageMap["PF0005"];
            if (MessageBoxResult.Yes.Equals(MessageBoxWindow.Show(message.DetailMessage, message.MessageLevel)))
            {
                this.Close();
            }
        
        }



    }
}
