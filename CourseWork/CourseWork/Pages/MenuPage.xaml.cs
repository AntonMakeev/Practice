using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private System.Timers.Timer timer;
        Worker _worker; 
        public MenuPage(Worker worker)
        {
            InitializeComponent();
            timer = new System.Timers.Timer(1500);
            timer.Elapsed += HideTextBlock;
            timer.AutoReset = false;
            timer.Start();
            _worker = worker;
        }

        private void HideTextBlock(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() => WelcomeTextBlock.Visibility = Visibility.Collapsed);
        }

        private void DishesButton_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new Pages.DishesPage());
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new Pages.OrderPage());
        }

        private void ReportingButton_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new Pages.ReportingPage());
        }

        private void OutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите выйти из аккаунта?", "Системное уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(messageBoxResult == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new Pages.AuthPage());
            }
        }

        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void OutOrderButton_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new Pages.RecipePage());
        }
    }
}
