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
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Windows.Interop;
using System.Windows.Media.Animation;
using CourseWork.Class;
using CourseWork.Models;

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BurgerHouseDBEntities entities = new BurgerHouseDBEntities();
        public MainWindow()
        {
            InitializeComponent();
            if(entities.Database.Connection.State != System.Data.ConnectionState.Closed)
            {
                MessageBox.Show("Сбой работы сервера, обратитесь к разработчику");
            }
            MainFrame.Navigate(new Pages.AuthPage());
        }

        private void ButtonMinimaze_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите покинуть программу?", "Системное увеломление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0;
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1.5,
                Duration = new Duration(TimeSpan.FromSeconds(1.5))
            };
            await Task.Delay(fadeInAnimation.Duration.TimeSpan);
            this.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
        }
    }
}
