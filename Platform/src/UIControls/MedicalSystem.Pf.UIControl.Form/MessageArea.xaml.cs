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
    /// MessageArea.xaml の相互作用ロジック
    /// </summary>
    public partial class MessageArea : UserControl,IArea
    {
        #region log4net　ログ部品の初期化
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        public MessageArea()
        {
            InitializeComponent();
        }

      

        public void UpdateArea(object obj)
        {
            log.Info("MessageArea UpdateArea Start!----------------------------------");
            MedicalSystemMessage message=(MedicalSystemMessage)obj;
            this.showMessageArea.Text = message.DetailMessage;
            log.Info("MessageArea UpdateArea End!----------------------------------");



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



        public void SendEvent(object sender,MedicalSystemEventArgs e)
        {
            throw new NotImplementedException();
        }





        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }





    }
}
