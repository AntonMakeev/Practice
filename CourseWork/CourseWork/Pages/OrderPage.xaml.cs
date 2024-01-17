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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        List<AllOrder> allOrders = new List<AllOrder>();
        public OrderPage()
        {
            InitializeComponent();
            allOrders = DataBaseClass.burgerHouseEntitis.AllOrders.ToList();
            OrderListView.ItemsSource = allOrders;
        }

        private void GetOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrderListView.SelectedItem == null)
                {
                    MessageBox.Show("Список блюд пуст!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var it = OrderListView.SelectedItem as AllOrder;
                    DataBaseClass.burgerHouseEntitis.EditOrder(2, it.ChequeID, 1);
                    NavigationService.Navigate(new Pages.OrderPageForCook(it));
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к разработчику", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PriceCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            allOrders = allOrders.OrderByDescending(x=>x.Summ).ToList();
            OrderListView.ItemsSource = allOrders.ToList();
        }

        private void PriceCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            allOrders = allOrders.OrderBy(x => x.Summ).ToList();
            OrderListView.ItemsSource = allOrders.ToList();
        }
    }
}
