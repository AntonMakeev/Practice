﻿#pragma checksum "..\..\..\Pages\DishesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "73FA6A04AECC0A7835714A8CDE43A34098CE1C36D160BF607D405EBE88DD21EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseWork.Pages;
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


namespace CourseWork.Pages {
    
    
    /// <summary>
    /// DishesPage
    /// </summary>
    public partial class DishesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView DishesListView;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ButtonsDishes;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAddDish;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonEditDish;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonDeleteDish;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonInBasket;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchDishesTextBox;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FilterDishesComboBox;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseWork;component/pages/dishespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\DishesPage.xaml"
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
            
            #line 9 "..\..\..\Pages\DishesPage.xaml"
            ((CourseWork.Pages.DishesPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DishesListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.ButtonsDishes = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.ButtonAddDish = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\Pages\DishesPage.xaml"
            this.ButtonAddDish.Click += new System.Windows.RoutedEventHandler(this.ButtonAddDish_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonEditDish = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\Pages\DishesPage.xaml"
            this.ButtonEditDish.Click += new System.Windows.RoutedEventHandler(this.ButtonEditDish_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ButtonDeleteDish = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\..\Pages\DishesPage.xaml"
            this.ButtonDeleteDish.Click += new System.Windows.RoutedEventHandler(this.ButtonDeleteDish_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonInBasket = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\Pages\DishesPage.xaml"
            this.ButtonInBasket.Click += new System.Windows.RoutedEventHandler(this.ButtonInBasket_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SearchDishesTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 107 "..\..\..\Pages\DishesPage.xaml"
            this.SearchDishesTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchDishesTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.FilterDishesComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 111 "..\..\..\Pages\DishesPage.xaml"
            this.FilterDishesComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FilterDishesComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
