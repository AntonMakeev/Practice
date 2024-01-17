using CourseWork.Class;
using CourseWork.Models;
using FontAwesome.Sharp;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WorkerAuthorizationData authorizationDataWorker = DataBaseClass.burgerHouseEntitis.WorkerAuthorizationDatas.FirstOrDefault(x => x.WorkerLogin == txtUser.Text && x.WorkerPassword == txtPass.Password);
                if (authorizationDataWorker == null)
                {
                    MessageBox.Show("Введеные неверные данные для авторизации", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    Worker worker = DataBaseClass.burgerHouseEntitis.Workers.FirstOrDefault(x => x.WorkerID == authorizationDataWorker.WorkerID);
                    NavigationService.Navigate(new Pages.MenuPage(worker));
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к разработчику", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
