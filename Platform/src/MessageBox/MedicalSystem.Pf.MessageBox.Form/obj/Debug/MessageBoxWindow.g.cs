﻿#pragma checksum "..\..\MessageBoxWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FE27B0746EA98BB7079D317AF8B486E1"
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


namespace MedicalSystem.Pf.MessageBox.Form {
    
    
    /// <summary>
    /// MessageBoxWindow
    /// </summary>
    public partial class MessageBoxWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\MessageBoxWindow.xaml"
        internal System.Windows.Controls.Image backGroundImg;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\MessageBoxWindow.xaml"
        internal System.Windows.Controls.TextBox DETAIL;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\MessageBoxWindow.xaml"
        internal System.Windows.Controls.Image ICONERROR;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\MessageBoxWindow.xaml"
        internal System.Windows.Controls.Image ICONQUESTION;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MessageBoxWindow.xaml"
        internal System.Windows.Controls.Image ICONWARNING;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MessageBoxWindow.xaml"
        internal System.Windows.Controls.Image ICONINFORMATION;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MessageBoxWindow.xaml"
        internal System.Windows.Controls.Button BUTTON1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MessageBoxWindow.xaml"
        internal System.Windows.Controls.Button BUTTON2;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MessageBoxWindow.xaml"
        internal System.Windows.Controls.Button BUTTON3;
        
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
            System.Uri resourceLocater = new System.Uri("/MedicalSystem.Pf.MessageBox.Form;component/messageboxwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MessageBoxWindow.xaml"
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
            
            #line 5 "..\..\MessageBoxWindow.xaml"
            ((MedicalSystem.Pf.MessageBox.Form.MessageBoxWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.backGroundImg = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.DETAIL = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ICONERROR = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.ICONQUESTION = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.ICONWARNING = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.ICONINFORMATION = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.BUTTON1 = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\MessageBoxWindow.xaml"
            this.BUTTON1.Click += new System.Windows.RoutedEventHandler(this.Btn1_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BUTTON2 = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\MessageBoxWindow.xaml"
            this.BUTTON2.Click += new System.Windows.RoutedEventHandler(this.Btn2_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BUTTON3 = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\MessageBoxWindow.xaml"
            this.BUTTON3.Click += new System.Windows.RoutedEventHandler(this.Btn3_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
