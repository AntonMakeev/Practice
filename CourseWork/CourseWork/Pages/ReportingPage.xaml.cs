using CourseWork.Class;
using CourseWork.Models;
using FontAwesome.Sharp;
using LiveCharts.Wpf;
using LiveCharts;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.Remoting.Contexts;

namespace CourseWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReportingPage.xaml
    /// </summary>
    public partial class ReportingPage : Page
    {
        List<getCountOfTypeDish> countOfTypeDish = new List<getCountOfTypeDish>();
        public ReportingPage()
        {
            InitializeComponent();
            countOfTypeDish = DataBaseClass.burgerHouseEntitis.getCountOfTypeDishes.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SeriesCollection piechartData = new SeriesCollection();
            foreach (var type in countOfTypeDish)
            {
                piechartData.Add(new PieSeries
                {
                    Title = type.DishTypeName,
                    Values = new ChartValues<int> { (int)type.Summ },
                    DataLabels = true,
                });
            }
            ReportingChart.Series = piechartData;
            ReportingChart.LegendLocation = LegendLocation.Right;
            ReportingChart.FontSize = 20;
            ReportingChart.FontFamily = new FontFamily("Montserrat");
            SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.DarkGray);
            ReportingChart.Foreground = solidColorBrush;
        }

        private void ReportingExcelButton_Click(object sender, RoutedEventArgs e)
        {
            var data = DataBaseClass.burgerHouseEntitis.TableInfoes.ToList();

            // Создание нового документа Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();

            // Создание нового листа
            Excel.Worksheet worksheet = workbook.Sheets[1];
            worksheet.Name = "Информация о чеках";

            // Заполнение заголовков
            worksheet.Cells[1, 1] = "ID чека";
            worksheet.Cells[1, 2] = "Дата чека";
            worksheet.Cells[1, 3] = "Количество";
            worksheet.Cells[1, 4] = "Наименование блюда";
            worksheet.Cells[1, 5] = "Стоимость блюда";
            worksheet.Cells[1, 6] = "Итого";
            worksheet.Cells[1, 7] = "Фамилия работника";
            worksheet.Cells[1, 8] = "Имя работника";
            worksheet.Cells[1, 9] = "Отчество работника";
            worksheet.Cells[1, 10] = "Должность";
            worksheet.Cells[1, 11] = "Email клиента";

            // Заполнение данных
            int row = 2;
            foreach (var item in data)
            {
                worksheet.Cells[row, 1] = item.ChequeID;
                worksheet.Cells[row, 2] = item.ChequeDate;
                worksheet.Cells[row, 3] = item.ProductCount;
                worksheet.Cells[row, 4] = item.DishName;
                worksheet.Cells[row, 5] = item.PriceMeaning;
                worksheet.Cells[row, 6] = item.TotalPrice;
                worksheet.Cells[row, 7] = item.WorkerSurname;
                worksheet.Cells[row, 8] = item.WorkerName;
                worksheet.Cells[row, 9] = item.WorkerPatronymic;
                worksheet.Cells[row, 10] = item.WorkerPositionName;
                worksheet.Cells[row, 11] = item.ClientEmal;
                row++;
            }

            workbook.SaveAs("C:/Users/User/Desktop/Книга1.xlsx");
            workbook.Close();
            //excelApp.Quit();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        
    }
}
