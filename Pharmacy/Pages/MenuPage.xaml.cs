using Pharmacy.Infrastructure.Consts;
using Pharmacy.Windows;
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
using Pharmacy.Infrastructure.QR;
using Pharmacy.Infrastructure.Database;

namespace Pharmacy.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            IDRoleBlock.Text = Application.Current.Resources[UserInfoConsts.RoleId].ToString();
            UserNameBlock.Text = Application.Current.Resources[UserInfoConsts.UserName].ToString();
            UserRoleBlock.Text = Application.Current.Resources[UserInfoConsts.RoleName].ToString();
            if (Application.Current.Resources[UserInfoConsts.RoleName].ToString() == "Клиент")
            {
               ClientsButton.IsEnabled = false;
            }
            if (Application.Current.Resources[UserInfoConsts.RoleName].ToString() == "Гость")
            {

                ClientsButton.IsEnabled = false;
                ServiceButton.IsEnabled = false;
            }
        }
        private void Vixod_Click(object sender, RoutedEventArgs e)
        {
            UserInfoConstas();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void Client_Click(object sender, RoutedEventArgs e)
        {
            ClientsPage clientsPage = new ClientsPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = clientsPage.Title;
            mainWindow.MainFrame.Navigate(clientsPage);
        }
        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            EmployeePage employeePage = new EmployeePage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = employeePage.Title;
            mainWindow.MainFrame.Navigate(employeePage);
        }
        private void Service_Click(object sender, RoutedEventArgs e)
        {
            ServicePage servicePage = new ServicePage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = servicePage.Title;
            mainWindow.MainFrame.Navigate(servicePage);
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            OrdersPage ordersPage = new OrdersPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = ordersPage.Title;
            mainWindow.MainFrame.Navigate(ordersPage);
        }
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            InfoPage infoPage = new InfoPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = infoPage.Title;
            mainWindow.MainFrame.Navigate(infoPage);
        }
        private UserInfoConsts UserInfoConstas()
        {
            Application.Current.Resources[UserInfoConsts.RoleId] = null;
            Application.Current.Resources[UserInfoConsts.UserName] = null;
            Application.Current.Resources[UserInfoConsts.RoleName] = null;
            return new UserInfoConsts();
        }
    }
}
