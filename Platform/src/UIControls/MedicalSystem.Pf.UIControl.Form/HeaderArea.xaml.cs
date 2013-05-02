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
    /// HeaderArea.xaml の相互作用ロジック
    /// </summary>
    public partial class HeaderArea : UserControl,IArea
    {
        #region log4net　ログ部品の初期化
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion


        public HeaderArea()
        {
            InitializeComponent();
            this.labCurrentUser.Content = "当前用户:";
            this.labPosition.Content = "职位:";
            this.btnLogoff.Content = "退出";
        }




        public void UpdateArea(object obj)
        {
            log.Info("HeaderArea UpdateArea Start!----------------------------------");


            if (typeof(UserEntity).IsInstanceOfType(obj))
            {
                this.labName.Content = ((UserEntity)obj).UserName;
                this.labPositionName.Content = ((UserEntity)obj).RoleName;

            }
            else if (typeof(string).IsInstanceOfType(obj))
            {
                this.labScreenName.Content=(string)obj;
            
            
            }



            log.Info("HeaderArea UpdateArea Start!----------------------------------");


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

        private void btnLogoff_Click(object sender, RoutedEventArgs e)
        {
            HeaderEventArgs args = new HeaderEventArgs();
            SendEvent(this, args);
        }
    }
}
