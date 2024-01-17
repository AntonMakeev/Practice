using CourseWork.Class;
using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using System.Windows.Threading;
using MessageBox = System.Windows.MessageBox;

namespace CourseWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPageForCook.xaml
    /// </summary>
    public partial class OrderPageForCook : Page
    {
        private DispatcherTimer _timer;
        private TimeSpan _time;
        AllOrder order;
        public OrderPageForCook(AllOrder it)
        {
            InitializeComponent();
            order = it;
            IDChecq.Text = $"Номер заказа: {order.ChequeID}";
            LoadData(order.ChequeID);
            Loaded += Page_Loaded;
        }

        private void LoadData(int id)
        {
            using (var context = new BurgerHouseDBEntities())
            {
                var data = context.InfoOrderWhereIDs.Where(x => x.ChequeID == id).ToList();
                OrderDataGrid.ItemsSource = data;
            }

        }

        private void OutOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно приготовили заказ?", "Системное уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    DataBaseClass.burgerHouseEntitis.EditOrder(3, order.ChequeID, 1);
                    MessageBox.Show("Заказ готов к выдаче", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к разработчику", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _time = _time.Subtract(TimeSpan.FromSeconds(1));
            if (_time.TotalSeconds <= 0)
            {
                _timer.Stop();
                MessageBox.Show("Время истекло!");
            }
            else
            {
                TimerTextBlock.Text = $"{_time.Minutes:00}:{_time.Seconds:00}";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _time = TimeSpan.FromMinutes(10);
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
    }
}
