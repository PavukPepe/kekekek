﻿#pragma checksum "..\..\Registration_win.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FC78470A37A7EC3E0FAA64591CE57271B8354109EE92EAA73D8F24DB73C446BE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PRACT_LAB_5;
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
using System.Windows.Shell;


namespace PRACT_LAB_5 {
    
    
    /// <summary>
    /// Registration_win
    /// </summary>
    public partial class Registration_win : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\Registration_win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Registration_win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox surname;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Registration_win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox middlename;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Registration_win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox pvz;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Registration_win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox login;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Registration_win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox password;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Registration_win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox password2;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Registration_win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox worker;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Registration_win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reg_but;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Registration_win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exit_but;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PRACT_LAB_5;component/registration_win.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Registration_win.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.name = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\Registration_win.xaml"
            this.name.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.name_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.surname = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\Registration_win.xaml"
            this.surname.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.surname_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.middlename = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\Registration_win.xaml"
            this.middlename.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.middlename_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pvz = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.password2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.worker = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.reg_but = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\Registration_win.xaml"
            this.reg_but.Click += new System.Windows.RoutedEventHandler(this.reg_but_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.exit_but = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\Registration_win.xaml"
            this.exit_but.Click += new System.Windows.RoutedEventHandler(this.exit_but_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

