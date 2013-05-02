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
using MedicalSystem.Pf.Common.ScreenTemplate;
using MedicalSystem.Pf.MessageBox.Form;
using MedicalSystem.Pf.Common.Context;


using MedicalSystem.Pf.Logon.Form;
using System.Reflection;
using Medical.Framework.Base.Entity;


#region 主画面


namespace MedicalSystem.Pf.MainScreen.Form
{



    public partial class MainScreen : Window
    {


        #region log4net　ログ部品の初期化
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region 定义变量
        //登录的用户信息
        private UserEntity logonUser;

        //存放根据用户权限得到的主menu子menu
        private List<MenuEntity> menuList;

        //存放子menuId和子画面的对应关系
        private Dictionary<string, SubScreenEntity> menuScreenMap;

        List<MenuEntity> subMenuList = new List<MenuEntity>();


        //子画面接口
        private IBusinessScreen currentScreen;

        private MedicalSystemMessage message;
        #endregion

       
        #region 主画面初始化
        public MainScreen()
        {

            InitializeComponent();

            //将各个域的事件处理挂在MainScreen的事件处理中
            this.headerArea.EventHandler += this.HeaderAreaEvent;
            this.globalMenuArea.EventHandler += this.GlobalMenuAreaEvent;
            this.subMenuArea.EventHandler += this.SubMenuAreaEvent;
            this.functionKeyArea.EventHandler += this.FunctionKeyAreaEvent;
            this.messageArea.EventHandler += this.MessageAreaEvent;
         



            //从全局上下文中取得logonUser，menuScreen和MapmenuList
            logonUser = MedicalSystemContext.GetInstance().LogonUser;
            menuList = MedicalSystemContext.GetInstance().MenuList;
            menuScreenMap = MedicalSystemContext.GetInstance().MenuScreenMap;
            
      
          
            //将用户信息显示在头部
            this.headerArea.UpdateArea(logonUser);
            //更新主menu的信息
            this.globalMenuArea.UpdateArea(menuList);
            MedicalSystemMessage message = MedicalSystemContext.GetInstance().MessageMap["PF0001"];
            string formatMessage = message.DetailMessage;
            string fullMessage = string.Format(formatMessage, new Object[] { logonUser.UserName});
            this.messageArea.UpdateArea(new MedicalSystemMessage(fullMessage));

        }

        #endregion

       
        #region 主画面加载
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        #endregion

      
        #region  主MENU的事件处理

        //主MENU的事件处理
        private bool GlobalMenuAreaEvent(Object sender, MedicalSystemEventArgs e)
        {
            log.Info("MainScreen GlobalMenuAreaEvent Start!----------------------------------");
            try
            {
       
                   
               
                this.functionKeyArea.Clear();
                this.GridSubScreen.Children.Clear();
                subMenuList.Clear();
                GlobalMenuEventArgs eArgs = (GlobalMenuEventArgs)e;
                foreach (MenuEntity subMenuEntity in menuList)
                {
                    if (subMenuEntity.ParentMenuId.Equals(eArgs.MenuEntity.MenuId))
                    {
                        subMenuList.Add(subMenuEntity);
                    }
                }

                this.headerArea.UpdateArea(eArgs.MenuEntity.MenuName);
                this.subMenuArea.UpdateArea(subMenuList);

            }
            catch (Exception ex)
            {
                MessageBoxWindow.ShowMessage(ex);
            }

            log.Info("MainScreen GlobalMenuAreaEvent End!----------------------------------");
            return true;

        }

        #endregion


        #region  子MENU的事件处理
        //子MENU的事件处理
        private bool SubMenuAreaEvent(Object sender, MedicalSystemEventArgs e)
        {
            log.Info("MainScreen SubMenuAreaEvent Start!----------------------------------");
            try
            {
    
                this.functionKeyArea.Clear();
                this.GridSubScreen.Children.Clear();
                SubMenuEventArgs eArgs = (SubMenuEventArgs)e;
                List<FunctionKeyEntity> btnInfos = null;

                
                //创建业务画面实例
                currentScreen = CreateBusinessScreenInstance(eArgs.MenuEntity.MenuId);
                this.GridSubScreen.Visibility = Visibility.Visible;
                GridSubScreen.Children.Add((System.Windows.UIElement)currentScreen);
                currentScreen.EventHandler += this.ScreenTransferEvent;
                btnInfos = currentScreen.GetFunctionAreaInfo();
                this.headerArea.UpdateArea(eArgs.MenuEntity.MenuName);
                this.functionKeyArea.UpdateArea(btnInfos);
     
            }
            catch (Exception ex)
            {
                MessageBoxWindow.ShowMessage(ex);
            }
            log.Info("MainScreen SubMenuAreaEvent End!----------------------------------");
            return true;
        }

        #endregion


        #region 功能键的事件处理
        //功能键的事件处理
        private bool FunctionKeyAreaEvent(Object sender, MedicalSystemEventArgs e)
        {
            log.Info("MainScreen FunctionKeyAreaEvent Start!----------------------------------");
            try
            {
          
                FunctionKeyEventArgs eArgs = (FunctionKeyEventArgs)e;
                IBusinessScreen currentScreen = this.currentScreen;
                if (currentScreen != null)
                {
                    currentScreen.FunctionBtnClick(eArgs.FunctionKeyEntity);
                }
            }
            catch (Exception ex)
            {
                MessageBoxWindow.ShowMessage(ex);
            }
            log.Info("MainScreen FunctionKeyAreaEvent End!----------------------------------");
            return true;
        }

        #endregion


        #region 消息域的事件处理
        //消息域的事件处理
        private bool MessageAreaEvent(Object sender, MedicalSystemEventArgs e)
        {




            return true;
        }

        #endregion


        #region 主画面顶部域的事件处理
        //主画面顶部域的事件处理
        private bool HeaderAreaEvent(Object sender, MedicalSystemEventArgs e)
        {
            log.Info("MainScreen HeaderAreaEvent Start!----------------------------------");
            try
            {
                message = message = MedicalSystemContext.GetInstance().MessageMap["PF0005"];
                if (MessageBoxResult.Yes.Equals(MessageBoxWindow.Show(message.BriefMessage, message.DetailMessage, message.MessageLevel)))
                 {
                     new LogonScreen().Show();
                     this.Close();          
                 }   
            }
            catch (Exception ex)
            {
                MessageBoxWindow.ShowMessage(ex);
            }
            log.Info("MainScreen FunctionKeyAreaEvent End!----------------------------------");
            return true;
        }

        #endregion

       
        #region 画面迁移事件处理
        //画面迁移事件处理
        private bool ScreenTransferEvent(Object sender, MedicalSystemEventArgs e)
        {
            log.Info("MainScreen ScreenTransferEvent Start!----------------------------------");
            try
            { 
                ScreenEventArgs eArgs = (ScreenEventArgs)e;
                switch (eArgs.TransferType)
                {

                    case ScreenEventArgs.TransferScreenType.Content:

                        this.functionKeyArea.Clear();
                        this.GridSubScreen.Children.Clear();
                        List<FunctionKeyEntity> btnInfos = null;
                        foreach(MenuEntity menuEntity in menuList)
                        {
                            if (menuEntity.MenuId.Equals(eArgs.MenuEntity.MenuId))
                            {
                                eArgs.MenuEntity.MenuName = menuEntity.MenuName;
                            }
                          
                        }
                        this.headerArea.UpdateArea(eArgs.MenuEntity.MenuName);
                        //创建业务画面实例
                        currentScreen = CreateBusinessScreenInstance(eArgs.MenuEntity.MenuId);
                        this.GridSubScreen.Visibility = Visibility.Visible;
                        GridSubScreen.Children.Add((System.Windows.UIElement)currentScreen);
                        currentScreen.Param = eArgs.Param;
                        currentScreen.EventHandler += this.ScreenTransferEvent;
                        btnInfos = currentScreen.GetFunctionAreaInfo();
                        this.functionKeyArea.UpdateArea(btnInfos);
                        this.subMenuArea.UpdateArea(subMenuList,eArgs.MenuEntity);
                        break;

                    case ScreenEventArgs.TransferScreenType.PopUp:
                       // List<FunctionKeyEntity> btnInfos = null;
                        IBusinessScreen popUpScreen = CreateBusinessScreenInstance(eArgs.MenuEntity.MenuId);
                        popUpScreen.EventHandler += ScreenTransferEvent;
                        popUpScreen.Param = eArgs.Param;
                        Window win = new Window();
                        win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        win.Content = popUpScreen;
                      //  btnInfos=popUpScreen.GetFunctionAreaInfo();
                       
                        win.ShowDialog();
                        break;

                    case ScreenEventArgs.TransferScreenType.Message:

                        this.messageArea.UpdateArea(eArgs.Message);
                        break;

                    default:

                        break;

                }
                log.Info("MainScreen ScreenTransferEvent End!----------------------------------");
            }
            catch (Exception ex)
            {
                MessageBoxWindow.ShowMessage(ex);
            }
            return true;
        }

        #endregion


        #region 创建子画面实例
        //创建子画面实例
        IBusinessScreen CreateBusinessScreenInstance(string menuId)
        {
            log.Info("MainScreen CreateBusinessScreenInstance Start!----------------------------------");
            
            Assembly assembly = Assembly.LoadFrom(menuScreenMap[menuId].AssemblyName);
            IBusinessScreen currentScreen = assembly.CreateInstance(menuScreenMap[menuId].ClassName) as IBusinessScreen;

            log.Info("MainScreen CreateBusinessScreenInstance End!----------------------------------");
            return currentScreen;
        }

        #endregion




    }
}
#endregion
