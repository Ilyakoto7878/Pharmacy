using Pharmacy.Infrastructure.Database;
using Pharmacy.Infrastructure.ViewModels;
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
using Pharmacy.Windows;
using Pharmacy.Infrastructure.Consts;
using Pharmacy.Infrastructure.QR;
using Pharmacy.Infrastructure.Report;
using System.IO;
using System.Reflection;

namespace Pharmacy.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        private ProductRepository _repository;
        public ServicePage()
        {
            InitializeComponent();
            _repository = new ProductRepository();
            UpdateGrid();
            if(Application.Current.Resources[UserInfoConsts.RoleName].ToString() == "Клиент")
            {
                DischargeButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
                AddButton.IsEnabled = false;
            }
        }
        private void MenuPage_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }
        public void UpdateGrid() // обновление DataGrid в соответствии с бд
        {
            ServiceGrid.ItemsSource = _repository.GetList();
        }

        private void QRButton_Click(object sender, RoutedEventArgs e)
        {
            var qrManager = new QRManager();
            QRCode.Source = qrManager.Generate(ServiceGrid.SelectedItem);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var item = ServiceTextBox.Text.ToString();
            if (item != "" || item == null)
            {
                var search = _repository.Search(item);
                ServiceGrid.ItemsSource = search;
            }
            else
            {
                UpdateGrid();
            }
        }

        private void DischargeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ServiceGrid.SelectedItem == null)
            {
                var reportManager = new ReportManager();
                var data = reportManager.GenerateReport(ServiceGrid.ItemsSource as List<ProductViewModel>);

                var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"report_{DateTime.Now.ToShortDateString()}.xlsx");
                using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для выгрузки");
            }
        }

        private void ServiceGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Application.Current.Resources[UserInfoConsts.RoleName].ToString() == "Клиент")
            {
                
            }
            else
            {
                MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
                var item = ServiceGrid.SelectedItem as ProductViewModel;
                if (item == null)
                {
                    MessageBox.Show("Не жмякайте просто так)");
                }
                else
                {
                    var id = item.id;
                    mainWindow.Hide();
                    var serviceCard = new ServiceCardWindow(ServiceGrid.SelectedItem as ProductViewModel);
                    serviceCard.ShowDialog();
                    UpdateGrid();
                    mainWindow.Show();
                }
                item = null;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Hide();
            var serviceCard = new ServiceCardWindow();
            serviceCard.ShowDialog();
            UpdateGrid();
            mainWindow.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var item = ServiceGrid.SelectedItem as ProductViewModel;

            if (ServiceGrid.SelectedItem == null || item == null)
            {
                MessageBox.Show("Удаление не было произведено");
            }
            else
            {
                _repository.Delete(item.id);
                UpdateGrid();
            }
        }
    }
}
