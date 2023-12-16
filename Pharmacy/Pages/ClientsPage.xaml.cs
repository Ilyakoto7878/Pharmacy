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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private ClientRepository _repository;

        public ClientsPage()
        {
            InitializeComponent();
            _repository = new ClientRepository();
            UpdateGrid();
        }
        private void MenuPage_Click(object sender, RoutedEventArgs e) // кнопка, которая при нажатии переходит в меню
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var item = ClientTextBox.Text.ToString();
            if (item != "" || item == null)
            {
                var search = _repository.Search(item);
                ClientGrid.ItemsSource = search;
            }
            else
            {
                UpdateGrid();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e) // кнопка, которая при нажатии открывает карточку для добавления записи клиента в бд
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Hide();
            var clientCard = new ClientCardWindow();
            clientCard.ShowDialog();
            UpdateGrid();
            mainWindow.Show();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) // кнопка, которая при нажатии удаляет запись клиента
        {
            var item = ClientGrid.SelectedItem as ClientViewModel;

            if (ClientGrid.SelectedItem == null || item == null)
            {
                MessageBox.Show("Удаление не было произведено");
            }
            else
            {
                _repository.Delete(item.id);
                UpdateGrid();
            }
        }

        private void DischargeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientGrid.SelectedItem == null)
            {
                var reportManager = new ReportManager();
                var data = reportManager.GenerateReport(ClientGrid.ItemsSource as List<ClientViewModel>);

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

        private void ClientGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) // двойной клик по DataGrid откроет карточку существующего клиента в бд
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var item = ClientGrid.SelectedItem as ClientViewModel;
            if (item == null)
            {
                MessageBox.Show("Не жмякайте просто так)");
            }
            else
            {
                mainWindow.Hide();
                var clientCard = new ClientCardWindow(ClientGrid.SelectedItem as ClientViewModel);
                clientCard.ShowDialog();
                UpdateGrid();
                mainWindow.Show();
            }
        }
       

        public void UpdateGrid() // обновление DataGrid в соответствии с бд
        {
            ClientGrid.ItemsSource = _repository.GetList();
        }

        private void QRButton_Click(object sender, RoutedEventArgs e)
        {
            var qrManager = new QRManager();
            QRCode.Source = qrManager.Generate(ClientGrid.SelectedItem);
        }

        private void ClientGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
