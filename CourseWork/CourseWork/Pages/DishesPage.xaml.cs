using CourseWork.Class;
using CourseWork.Models;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace CourseWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для DishesPage.xaml
    /// </summary>
    public partial class DishesPage : Page
    {
        List<DishesView> dishesViews = new List<DishesView>();
        public DishesPage()
        {
            InitializeComponent();
            dishesViews = DataBaseClass.burgerHouseEntitis.DishesViews.ToList();
            DishesListView.ItemsSource = dishesViews;
            FilterDishesComboBox.ItemsSource = DataBaseClass.burgerHouseEntitis.DishTypes.ToList();

            //DishType typeDish = new DishType();
            //typeDish.DishTypeName = "Вся продукция";
            //FilterDishesComboBox.Items.Add(typeDish);
            //foreach (var dish in DataBaseClass.burgerHouseEntitis.DishTypes.ToList())
            //{
            //    FilterDishesComboBox.Items.Add(dish);
            //}
            //FilterDishesComboBox.SelectedIndex = 0;
        }

        private void ButtonAddDish_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddOrEditDishPage());
        }

        private void ButtonEditDish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(DishesListView.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали блюдо!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var it = DishesListView.SelectedItem as DishesView;
                    NavigationService.Navigate(new Pages.AddOrEditDishPage(it));
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к разработчику", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonDeleteDish_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                if (DishesListView.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали блюдо!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    var it = DishesListView.SelectedItem as DishesView;
                    DataBaseClass.burgerHouseEntitis.DishesViews.Remove(it);
                    //DataBaseClass.burgerHouseEntitis.SaveChanges();
                    MessageBox.Show("Удаление прошло успешно", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                DishesListView.ItemsSource = DataBaseClass.burgerHouseEntitis.DishesViews.ToList();
            //}
            //catch
            //{
            //    MessageBox.Show("Обратитесь к разработчику", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void ButtonInBasket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                List<DishesView> selectedItems = new List<DishesView>();
                foreach (DishesView item in DishesListView.SelectedItems)
                {
                    selectedItems.Add(item);
                }
                BasketPage basketPage = new BasketPage(selectedItems);
                if (DishesListView.SelectedItem != null)
                {
                    DataBaseClass.burgerHouseEntitis.AddInOrderOffline(1, 1);
                    MessageBox.Show("Заказ сформирован!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(basketPage);
                }
                else
                {
                    MessageBox.Show("Вы не выбрали блюдо!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к разработчику", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //private void ButtonRecipe_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if(DishesListView.SelectedItem == null)
        //        {
        //            MessageBox.Show("Вы не выбрали блюдо!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //        else
        //        {
        //            var it = DishesListView.SelectedItem as DishesView;
        //            NavigationService.Navigate(new Pages.RecipePage(it));
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Обратитесь к разработчику", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = DataBaseClass.burgerHouseEntitis.DishesViews.ToList();
        }

        private void SearchDishesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DishType selectedCategory = FilterDishesComboBox.SelectedItem as DishType;
                if (selectedCategory != null)
                {
                    string searchText = SearchDishesTextBox.Text;
                    List<DishesView> items = DataBaseClass.burgerHouseEntitis.DishesViews.Where(item => item.DishTypeName == selectedCategory.DishTypeName && item.DishName.Contains(searchText)).ToList();
                    DishesListView.ItemsSource = items;
                }
                else
                {
                    DishesListView.ItemsSource = DataBaseClass.burgerHouseEntitis.DishesViews.Where(x => x.DishName.Contains(SearchDishesTextBox.Text.ToLower())).ToList();
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к разработчику", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilterDishesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DishType dishType = FilterDishesComboBox.SelectedItem as DishType;
                if (dishType != null)
                {
                    List<DishesView> dishesViews = DataBaseClass.burgerHouseEntitis.DishesViews.Where(x => x.DishTypeName == dishType.DishTypeName).ToList();
                    DishesListView.ItemsSource = dishesViews;
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к разработчику", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

       
    }
}
