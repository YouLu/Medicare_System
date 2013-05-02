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


namespace MedicalSystem.Pf.Sample.Form
{
    /// <summary>
    /// HelpForm.xaml の相互作用ロジック
    /// </summary>
    /// </summary>
    public partial class HelpForm : MedicalSystemScreenBase, IBusinessScreen
    {

        private Object[] param;

        public Object[] Param
        {
            get { return param; }
            set { param = value; }
        }




        public HelpForm()
        {
            InitializeComponent();

        }



        public List<FunctionKeyEntity> GetFunctionAreaInfo()
        {

            List<FunctionKeyEntity> functionKeyList = new List<FunctionKeyEntity>();
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F1, "帮助", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F2, "F2", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F3, "F3", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F4, "F4", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F5, "最新显示", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F6, "F6", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F7, "F7", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F8, "F8", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F9, "F9", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F10, "打印", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F11, "采血预约录入", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F12, "F12", false, true));
            return functionKeyList;
        }

        public void FunctionBtnClick(FunctionKeyEntity functionKey)
        {


        }


        #region ISendEvent メンバ



        public void SendEvent(object sender, MedicalSystemEventArgs e)
        {
            eventHandler(sender, e);
        }



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











        #endregion

        private void MedicalSystemScreenBase_Loaded(object sender, RoutedEventArgs e)
        {
            this.label1.Content = (string)param[0];



        }



    }
}
