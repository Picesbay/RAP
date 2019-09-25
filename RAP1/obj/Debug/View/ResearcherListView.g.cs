﻿#pragma checksum "..\..\..\View\ResearcherListView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CBF6D2CE363706DF0CBFA8762231365150728E54"
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
    /// ResearcherListView
    /// </summary>
    public partial class ResearcherListView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\View\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ResearchersListPanel;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\View\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox filterNameBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\View\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox filterLevelBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\View\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox researchersListBox;
        
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
            System.Uri resourceLocater = new System.Uri("/RAP1;component/view/researcherlistview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ResearcherListView.xaml"
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
            this.ResearchersListPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.filterNameBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\View\ResearcherListView.xaml"
            this.filterNameBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterNameBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.filterLevelBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\View\ResearcherListView.xaml"
            this.filterLevelBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LevelComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.researchersListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 30 "..\..\..\View\ResearcherListView.xaml"
            this.researchersListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.researchersListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

