using CourseWork.Class;
using CourseWork.Models;
using System;
using System.Collections.Generic;
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

namespace CourseWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecipePage.xaml
    /// </summary>
    public partial class RecipePage : Page
    {
        List<AllOrder> allOrders;
        public RecipePage()
        {
            InitializeComponent();
            allOrders = new List<AllOrder>();
            allOrders = DataBaseClass.burgerHouseEntitis.AllOrders.Where(x => x.OrderStatusName == "Ожидает").ToList();
            OutOrderListView.ItemsSource = allOrders;
        }

        private void SearchOrderByISTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OutOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OutOrderListView.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали заказ!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Номер заказа совпадает?", "Системное уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        var it = OutOrderListView.SelectedItem as AllOrder;
                        DataBaseClass.burgerHouseEntitis.EditOrder(4, it.ChequeID, 1);
                        MessageBox.Show("Заказ успешно выдан", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к разработчику!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OutOrderListView.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали заказ!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Клиент не забрал заказ?", "Системное уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        var it = OutOrderListView.SelectedItem as AllOrder;
                        DataBaseClass.burgerHouseEntitis.EditOrder(6, it.ChequeID, 1);
                        MessageBox.Show("Выдача заказа отменена", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к разработчику!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = allOrders.ToList();
        }

        private void ChequeButton_Click()
        {

        }
    }
}
