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
using System.Windows.Shapes;

namespace MedicalSystem.Pf.MessageBox.Form
{
    /// <summary>
    /// MedicalSystemErrorMessageBox.xaml の相互作用ロジック
    /// </summary>
    public partial class MedicalSystemErrorMessageBox : Window
    {
     
        private string briefMessage;

   
        private string detailMessage;

  


     
        public MessageBoxResult result;




        public MedicalSystemErrorMessageBox(Exception exp)
        {

            this.briefMessage = "EXCEPTION";    
            this.detailMessage = exp.Message;  
       

            InitializeComponent();

        }




        public void Window_Loaded(object sender, RoutedEventArgs e)
        {

         

            // 概要メッセージ
            if (this.briefMessage != null)
            {
                this.BRIEF.Text = this.briefMessage;
            }

            // 詳細メッセージ
            if (this.detailMessage != null)
            {
                this.DETAIL.Text=this.detailMessage;
            }


            // ボタン表示
            this.BUTTON.Content = "OK";
            this.BUTTON.Focus();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            // 結果を設定
            result = MessageBoxResult.OK;

            // メッセージボックスを閉じる
            this.Close();
        }

        private void DETAIL_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

      



    }
}
