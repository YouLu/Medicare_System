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
using Medical.Framework.Exception;
using MedicalSystem.Pf.MessageBox.Form;
using System.Globalization;
using Medical.Framework.Util;
using MedicalSystem.Pf.Common.Proxy;
using Entity;
using MedicalSystem.Pf.Common.Context;
using System.Collections.ObjectModel;
using System.Collections;

namespace MedicalSystem.Pf.Sample.Form
{
    /// <summary>
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class ReservationsLogin : MedicalSystemScreenBase, IBusinessScreen
    {
        private Dictionary<int, int> dic = new Dictionary<int, int>();
        private Object[] param;

        public Object[] Param
        {
            get { return param; }
            set { param = value; }
        }


        public ReservationsLogin()
        {
            InitializeComponent();
            InitDictionary();
        }

        public List<FunctionKeyEntity> GetFunctionAreaInfo()
        {


            List<FunctionKeyEntity> functionKeyList = new List<FunctionKeyEntity>();
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F1, "帮助", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F2, "F2", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F3, "F3", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F4, "F4", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F5, "F5", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F6, "F6", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F7, "F7", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F8, "F8", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F9, "F9", false, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F10, "显示信息", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F11, "受付删除", true, true));
            functionKeyList.Add(new FunctionKeyEntity(FunctionKeyEntity.FncType.F12, "登录", true, true));
            return functionKeyList;
        }

        public void FunctionBtnClick(FunctionKeyEntity functionKey)
        {
            ScreenEventArgs args;
            ProxyService proxy = new ProxyService();
            try
            {
                switch (functionKey.FunctionKeyType)
                {
                    case FunctionKeyEntity.FncType.F10:
                        AppParam appParam = new AppParam();
                        appParam.RequestClass = "GetReserveInfo";
                        appParam.Add("patientId", PatientID.Text);
                        AppParam retParam = proxy.Execute(appParam);
                        PatientEntity patient = (PatientEntity)retParam.Get("patient");
                        MstOrderEntity mstOrder = (MstOrderEntity)retParam.Get("MstOrderEntity");
                        //患者基本信息
                        commonInfo.DataContext = patient;
                        LabAge.Content = WorkOutAge(patient.PatientBirthDate);
                        //身体信息
                        bodyInfo.DataContext = patient;
                        LabBondCount.Content = WorkOutBloodCirculation(patient.Weight);
                        //受付信息
                        BloodTypeABO.Content = MedicalSystemContext.GetInstance().MstCodeMap[mstOrder.BloodTypeABO];
                        //BloodTypeRH.Content = MedicalSystemContext.GetInstance().MstCodeMap[mstOrder.BloodTypeRH];
                        orderInfo.DataContext = mstOrder;
                        LabDoctorCD.SelectedValue = mstOrder.DoctorCD;
                        LabDiagnosisDeptCD.SelectedValue = mstOrder.DiagnosisDeptCD;
                        LabWardCD.SelectedValue = mstOrder.WardCD;
                        break;

                    case FunctionKeyEntity.FncType.F11:


                        break;

                    case FunctionKeyEntity.FncType.F2:

                        break;

                    default:

                        break;

                }
            }
            catch (AppException ex)
            {
                MessageBoxWindow.ShowMessage(ex);
            }
            catch (Exception ex)
            {
                MessageBoxWindow.ShowMessage(ex);
            }
        }

        #region 根据出生日期计算年龄

        private string WorkOutAge(string birthDate)
        {
            string[] str = birthDate.Split('/');
            DateTime currentDate = DateTime.Now;
            int currentYear = currentDate.Year;
            int birthYear = Convert.ToInt32(str[0]);
            int age = currentYear - birthYear;
            return Convert.ToString(age);
        }

        #endregion

        #region 根据体重计算血液循环量

        private string WorkOutBloodCirculation(string weight)
        { 
            int iWeight = Convert.ToInt32(weight);
            return Convert.ToString(iWeight * 70);
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
            eventHandler(sender, e);
        }

        #endregion

        private void lastMonth_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = (DateTime)LabCurrentDate.Content;
            int year = dateTime.Year;
            int month = dateTime.Month;
            int day = dateTime.Day;
            if (month == 1)
            {
                month = 12;
                year = year - 1;
            }
            else
            {
                month = month - 1;
            }
            DateTime SubDate = new DateTime(year, month, day);
            LabCurrentDate.Content = SubDate.Date;
            BuildCalender(SubDate);
        }

        private void nextMonth_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = (DateTime)LabCurrentDate.Content;
            int year = dateTime.Year;
            int month = dateTime.Month;
            int day = dateTime.Day;
            if (month == 12)
            {
                month = 1;
                year = year + 1;
            }
            else
            {
                month = month + 1;
            }
            DateTime SubDate = new DateTime(year, month, day);
            LabCurrentDate.Content = SubDate.Date;
            BuildCalender(SubDate);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            LabCurrentDate.Content = dateTime.Date;
            BuildCalender(dateTime);

            AppParam appParam = new AppParam();
            ProxyService proxy = new ProxyService();
            appParam.RequestClass = "Init";
            AppParam retParam = proxy.Execute(appParam);
            IList mstDoctorList = (IList)retParam.Get("doctorList");
            IList mstWardList = (IList)retParam.Get("mstWardList");
            IList mstDiagnosisDeptList = (IList)retParam.Get("mstDiagnosisDeptList");
            LabDoctorCD.ItemsSource = mstDoctorList;
            LabWardCD.ItemsSource = mstWardList;
            LabDiagnosisDeptCD.ItemsSource = mstDiagnosisDeptList;
        }

        private void BuildCalender(DateTime currentDate)
        {
            System.Windows.Style myLabelStyle = (Style)this.Resources["myLabel"];   //获取xaml中定义的名字为myLabel的样式
            System.Windows.Style LabCurrentDateStyle = (Style)this.Resources["LabCurrentDateStyle"];
            int year = currentDate.Year;
            int month = currentDate.Month;
            int day = currentDate.Day;
            int firstDayOfMonth = ConvertFirstDayOfMonthToInt(year, month);
            int totalDays = CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(year, month);
            int SubDay = 1;
            Label myLabel = null;
            Data data = null;
            UIElementCollection calenderChildren = calenderGrid.Children;
            int flag = 0;
            for (int row = 1; row <= 6; row++)
            {
                for (int column = 0; column <= 6; column++)
                {
                    //设置日历的第一行，将每月1号之前的单元格全部置空
                    if (firstDayOfMonth == column && row == 1 && flag == 0)
                    {
                        for (int i = 0; i < column; i++)
                        {
                            myLabel = new Label();
                            myLabel.Style = myLabelStyle;
                            data = new Data();
                            myLabel.Content = data;
                            Grid.SetColumn(myLabel, i);
                            Grid.SetRow(myLabel, row);
                            calenderChildren.Add(myLabel);
                        }
                        flag = 1;
                    }
                    //设置日历主体
                    if (flag == 1 && SubDay <= totalDays)
                    {
                        myLabel = new Label();
                        if (day == SubDay)   //特殊显示今日
                        {
                            myLabel.Style = LabCurrentDateStyle;
                        }
                        else
                        {
                            myLabel.Style = myLabelStyle;
                        }
                        data = new Data();
                        data.Day = Convert.ToString(SubDay);
                        data.People = GetPeople(SubDay++);
                        myLabel.Content = data;
                        Grid.SetColumn(myLabel, column);
                        Grid.SetRow(myLabel, row);
                        calenderChildren.Add(myLabel);

                    }
                    //设置日历结束部分
                    if (flag == 1 && (SubDay - 1) == totalDays)
                    {
                        flag = 2;
                        if (column < 6)
                        {
                            column = column + 1;
                        }
                        else
                        {
                            column = 0;
                            row = row + 1;
                        }
                    }

                    if (flag == 2)
                    {
                        myLabel = new Label();
                        myLabel.Style = myLabelStyle;
                        data = new Data();
                        myLabel.Content = data;
                        Grid.SetColumn(myLabel, column);
                        Grid.SetRow(myLabel, row);
                        calenderChildren.Add(myLabel);
                    }


                }
            }
            calenderGrid.UpdateLayout();
        }

        private int ConvertFirstDayOfMonthToInt(int year, int month)
        {
            DateTime date = new DateTime(year, month, 1);
            DayOfWeek day = CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            if (day.ToString().Equals("Monday"))
            {
                return 0;
            }
            else if (day.ToString().Equals("Tuesday"))
            {
                return 1;
            }
            else if (day.ToString().Equals("Wednesday"))
            {
                return 2;
            }
            else if (day.ToString().Equals("Thursday"))
            {
                return 3;
            }
            else if (day.ToString().Equals("Friday"))
            {
                return 4;
            }
            else if (day.ToString().Equals("Saturday"))
            {
                return 5;
            }
            else if (day.ToString().Equals("Sunday"))
            {
                return 6;
            }
            else
            {
                return -1;
            }
        }

        private void InitDictionary()
        {
            dic.Add(1, 5);
            dic.Add(13, 3);
            dic.Add(24, 7);
        }

        private string GetPeople(int day)
        {
            if (dic.ContainsKey(day))
            {
                return Convert.ToString(dic[day]);
            }
            return "";
        }
    }
    
}
