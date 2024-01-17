using CourseWork.Class;
using CourseWork.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FontAwesome.Sharp;
using MessageBox = System.Windows.MessageBox;
using System.Collections.ObjectModel;

namespace CourseWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditDishPage.xaml
    /// </summary>
    public partial class AddOrEditDishPage : Page
    {
        DishesView _dishesView;
        public AddOrEditDishPage()
        {
            InitializeComponent();
            _dishesView = new DishesView();
            TypeDishesComboBox.ItemsSource = DataBaseClass.burgerHouseEntitis.DishTypes.ToList();
            UnitDishComboBox.ItemsSource = DataBaseClass.burgerHouseEntitis.UnitOfMeasurements.ToList();
            AddOrEditTextBlock.Text = "Добавление блюда";
            //DishListBox.ItemsSource = dish;
            ButtonAddDish.Content = "Добавить";
        }

        public AddOrEditDishPage(DishesView dishesView)
        {
            InitializeComponent();
            _dishesView = dishesView;
            TypeDishesComboBox.ItemsSource = DataBaseClass.burgerHouseEntitis.DishTypes.ToList();
            TypeDishesComboBox.SelectedItem = DataBaseClass.burgerHouseEntitis.DishTypes.First(x=>x.DishTypeName == _dishesView.DishTypeName);
            UnitDishComboBox.ItemsSource = DataBaseClass.burgerHouseEntitis.UnitOfMeasurements.ToList();
            UnitDishComboBox.SelectedItem = DataBaseClass.burgerHouseEntitis.UnitOfMeasurements.First(x => x.UnitOfMeasurementName == _dishesView.UnitOfMeasurementName);
            DishImage.DataContext = _dishesView.DishPhoto;
            AddOrEditTextBlock.Text = "Редактирование блюда";
            ButtonAddDish.Content = "Сохранить";
        }

        private void ButtonAddDish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DishType SelectedType = TypeDishesComboBox.SelectedItem as DishType;
                UnitOfMeasurement SelectedUnit = UnitDishComboBox.SelectedItem as UnitOfMeasurement;
                byte[] bytes = DishImage.DataContext as byte[];
                string productPrice = PriceDishTextBox.Text.Replace(".0000", "");
                if (string.IsNullOrWhiteSpace(NameDishTextBox.Text) || string.IsNullOrWhiteSpace(productPrice) || SelectedType == null || SelectedUnit == null)
                {
                    if (_dishesView.DishID == 0)
                    {
                        DataBaseClass.burgerHouseEntitis.AddDish(NameDishTextBox.Text, bytes, SelectedType.DishTypeID, SelectedUnit.UnitOfMeasurementID, decimal.Parse(productPrice));
                        MessageBox.Show("Блюдо успешно добавлено!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        //DataBaseClass.burgerHouseEntitis.(int.Parse(IDDishTextBox.Text), NameDishTextBox.Text, SelectedType.IDTypeDish, SelectedUnit.IDUnitOfMeasurement, bytes, decimal.Parse(ProductPrice));
                        MessageBox.Show("Изменение прошло успешно!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.GoBack();
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к разработчику", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NameDishTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameTextBlock.Text = NameDishTextBox.Text;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _dishesView;
        }


        private void DishImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                DishImage.DataContext = File.ReadAllBytes(openFileDialog.FileName);
        }

            //dish.Add(TypeDishesComboBox.Text);
            //dish.Add(UnitDishComboBox.Text);
        private void PriceDishTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PriceDishTextBox.Text = PriceDishTextBox.Text.Replace(" ", "");
            PriceTextBlock.Text = PriceDishTextBox.Text;  
        }

        private void UnitDishComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (UnitDishComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            UnitDishtextBloxk.Text = selectedItem;
        }

        private void PriceDishTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.Text, 0) && PriceDishTextBox.Text.Length < 5);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameDishTextBox.Text != null &&  PriceDishTextBox.Text != null && TypeDishesComboBox.SelectedItem != null && UnitDishComboBox.SelectedItem != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы не закончили работу, желаете вернуться?", "Системное уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(messageBoxResult == MessageBoxResult.Yes)
                {
                    NavigationService.GoBack();
                }
            }
            else
            {
                NavigationService.GoBack();
            }
        }

        private void CompositionTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void CompositionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CountTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void CountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
