#pragma checksum "..\..\..\..\Views\AddMeals.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3A05445EA92C8FA6DD19DD3221D0566F909845E7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Prism.DryIoc;
using Prism.Interactivity;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Services.Dialogs;
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


namespace ReserveModule.Views {
    
    
    /// <summary>
    /// AddMeals
    /// </summary>
    public partial class AddMeals : System.Windows.Controls.TabItem, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\Views\AddMeals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid BrakfastList;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Views\AddMeals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DinnerList;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Views\AddMeals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SupperList;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\Views\AddMeals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid BrakfastListChosen;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\Views\AddMeals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DinnerListChosen;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\..\Views\AddMeals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SupperListChosen;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ReserveModule;V1.0.0.0;component/views/addmeals.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\AddMeals.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BrakfastList = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.DinnerList = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.SupperList = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.BrakfastListChosen = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.DinnerListChosen = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.SupperListChosen = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

