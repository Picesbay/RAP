﻿#pragma checksum "..\..\..\View\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EE0079051D4BB399038E10D6ED49F04AEDCA142154562E0BF2D9CC8E494C7C93"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RAP.View;
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


namespace RAP.View {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox researchersListBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ResearcherDetailsPanel;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView positionsListView;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cumulativeCount;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label threeYear;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label performance;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label supervisions;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label degree;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label supervisors;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView publicationsListView;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PublicationDetailsPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/RAP1;component/view/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.researchersListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 26 "..\..\..\View\MainWindow.xaml"
            this.researchersListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.researchersListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 31 "..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnPerfReports_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ResearcherDetailsPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.positionsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.cumulativeCount = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\View\MainWindow.xaml"
            this.cumulativeCount.Click += new System.Windows.RoutedEventHandler(this.btnCumulativeCount_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.threeYear = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.performance = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.supervisions = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            
            #line 119 "..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnShowNames_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.degree = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.supervisors = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.publicationsListView = ((System.Windows.Controls.ListView)(target));
            
            #line 136 "..\..\..\View\MainWindow.xaml"
            this.publicationsListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.publicationsListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.PublicationDetailsPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

