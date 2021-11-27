﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FB5D2D7F875A58FF62E0167CA3A01CBE3EF2E6FB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ChatApp;
using ChatApp.ViewModel;
using Emoji.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WPFLocalizeExtension.Deprecated.Engine;
using WPFLocalizeExtension.Deprecated.Extensions;
using WPFLocalizeExtension.Deprecated.Providers;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Extensions;
using WPFLocalizeExtension.Providers;
using WPFLocalizeExtension.TypeConverters;
using WPFLocalizeExtension.ValueConverters;


namespace ChatApp {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseBtn;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DayNightbttn;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid navigationPanel;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush slidebarbckgrnd;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MenuTextblock;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton tgglBttn;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.Storyboard HideStackPanel;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.Storyboard ShowStackPanel;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView;
        
        #line default
        #line hidden
        
        
        #line 223 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock HomeTextBlock;
        
        #line default
        #line hidden
        
        
        #line 232 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip tooltip_home;
        
        #line default
        #line hidden
        
        
        #line 258 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessagesTextBlock;
        
        #line default
        #line hidden
        
        
        #line 266 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip tooltip_messages;
        
        #line default
        #line hidden
        
        
        #line 291 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GraphsTextBlock;
        
        #line default
        #line hidden
        
        
        #line 300 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip tooltip_graphs;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ChatApp;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\MainWindow.xaml"
            ((ChatApp.MainWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CloseBtn = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\MainWindow.xaml"
            this.CloseBtn.Click += new System.Windows.RoutedEventHandler(this.CloseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DayNightbttn = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\MainWindow.xaml"
            this.DayNightbttn.Click += new System.Windows.RoutedEventHandler(this.DayNightbttn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.navigationPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.slidebarbckgrnd = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 6:
            this.MenuTextblock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.tgglBttn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 158 "..\..\..\MainWindow.xaml"
            this.tgglBttn.Unchecked += new System.Windows.RoutedEventHandler(this.tgglBttn_Unchecked);
            
            #line default
            #line hidden
            
            #line 159 "..\..\..\MainWindow.xaml"
            this.tgglBttn.Checked += new System.Windows.RoutedEventHandler(this.tgglBttn_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.HideStackPanel = ((System.Windows.Media.Animation.Storyboard)(target));
            return;
            case 9:
            this.ShowStackPanel = ((System.Windows.Media.Animation.Storyboard)(target));
            return;
            case 10:
            this.listView = ((System.Windows.Controls.ListView)(target));
            return;
            case 11:
            
            #line 208 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ListViewItem_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 12:
            this.HomeTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.tooltip_home = ((System.Windows.Controls.ToolTip)(target));
            return;
            case 14:
            
            #line 243 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ListViewItem_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 15:
            this.MessagesTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 16:
            this.tooltip_messages = ((System.Windows.Controls.ToolTip)(target));
            return;
            case 17:
            
            #line 276 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ListViewItem_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 18:
            this.GraphsTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 19:
            this.tooltip_graphs = ((System.Windows.Controls.ToolTip)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

