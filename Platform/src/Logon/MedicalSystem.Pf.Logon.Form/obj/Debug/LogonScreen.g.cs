﻿#pragma checksum "..\..\LogonScreen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "61AB7E49CA36951D548DD7B6FC8A5E96"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:2.0.50727.3082
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MedicalSystem.Pf.Logon.Form {
    
    
    /// <summary>
    /// LogonScreen
    /// </summary>
    public partial class LogonScreen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\LogonScreen.xaml"
        internal System.Windows.Controls.Image image1;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\LogonScreen.xaml"
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\LogonScreen.xaml"
        internal System.Windows.Controls.Label labName;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\LogonScreen.xaml"
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\LogonScreen.xaml"
        internal System.Windows.Controls.Label labPassword;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\LogonScreen.xaml"
        internal System.Windows.Controls.Button btnLogon;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\LogonScreen.xaml"
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\LogonScreen.xaml"
        internal System.Windows.Controls.Button btnClear;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\LogonScreen.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\LogonScreen.xaml"
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MedicalSystem.Pf.Logon.Form;component/logonscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LogonScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\LogonScreen.xaml"
            ((MedicalSystem.Pf.Logon.Form.LogonScreen)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.image1 = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.labName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.labPassword = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btnLogon = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\LogonScreen.xaml"
            this.btnLogon.Click += new System.Windows.RoutedEventHandler(this.btnLogon_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.btnClear = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\LogonScreen.xaml"
            this.btnClear.Click += new System.Windows.RoutedEventHandler(this.btnClear_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\LogonScreen.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
