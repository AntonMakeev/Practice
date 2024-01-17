    using CourseWork.Class;
using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Net;
using System.Net.Mail;
using System.Windows.Shapes;
using System.IO;

namespace CourseWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        List<DishesView> dishes;
        public BasketPage(List<DishesView> items)
        {
            InitializeComponent();
            //sessionData = items;
            BasketListView.ItemsSource = items.ToList();
            dishes = items;
            string email=
            EmailTextBox.Text;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddChequeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dishes.Count == 0)
                {
                    MessageBox.Show("Список блюд пустой!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    for (int i = 0; i < dishes.Count; i++)
                    {
                        int c = DataBaseClass.burgerHouseEntitis.Cheques.Max(x => x.ChequeID);
                        DataBaseClass.burgerHouseEntitis.AddProductInOrder(c, dishes[i].DishID,1);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к разработчику!", "Системное уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void ClearBasketButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public void SendEmail()
        {
            // Создаем StringBuilder для хранения текста чека
            StringBuilder checkText = new StringBuilder();
            foreach (var item in BasketListView.Items)
            {
                DishesView dishesView = (DishesView)item;
                //checkText.AppendLine(dishesView.DishName+ " - " + dishesView.ProductCount+ " " + dishesView.DishTypeName + " шт. - " + dishesView.PriceMeaning + "руб.");
            }
            //string emailBody = checkText.ToString();
            

            // Заполняем основную информацию письма
            

            //// Создаем объект SmtpClient для отправки письма
            //SmtpClient smtpClient = new SmtpClient("mpirotekhniki@mail.ru", 587);
            //smtpClient.UseDefaultCredentials = false;

            // Заполняем информацию для аутентификации на SMTP-сервере
            //smtpClient.Credentials = new NetworkCredential("mpirotekhniki@mail.ru", "JJV0K1QPfTadqifi8Wcr");
            //smtpClient.EnableSsl = true;
            //// Отправляем письмо
            //smtpClient.Send(mail);

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            SmtpClient mySmtpClient = new SmtpClient("smtp.mail.ru");
            mySmtpClient.Port = 587;
            mySmtpClient.UseDefaultCredentials = true;
            mySmtpClient.EnableSsl = true;
            System.Net.NetworkCredential basicAuthenticationInfo = new
            System.Net.NetworkCredential("mpirotekhniki@mail.ru", "JJV0K1QPfTadqifi8Wcr");
            mySmtpClient.Credentials = basicAuthenticationInfo;

            MailAddress from = new MailAddress("mpirotekhniki@mail.ru", "Бургерная");
            MailAddress to = new MailAddress("mtgh272@gmail.com");
            MailMessage myMail = new MailMessage(from, to);
            myMail.Subject = "Чек";
            //myMail.Body = emailBody;
            //myMail.Body = $"<p>Здравствуйте! Ваш чек заказа</p>{emailBody}<p></p><p><b>График работы бургерной:</b></p><p>Пн.-Пт.:     09:00-18:00</p><p>Сб.-Вс.:     10:00-15:00</p>";
            myMail.BodyEncoding = Encoding.UTF8;
            // text or html 
            myMail.IsBodyHtml = true;
            mySmtpClient.Send(myMail);
            
            ////myMail.IsBodyHtml = true;
            mySmtpClient.Send(myMail);
            //MessageBox.Show("Сообщение отправлено", "Систменое уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
