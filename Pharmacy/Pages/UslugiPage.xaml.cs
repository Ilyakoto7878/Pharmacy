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

namespace Moon.Pages
{
    /// <summary>
    /// Логика взаимодействия для UslugiPage.xaml
    /// </summary>
    public partial class UslugiPage : Page
    {
        public UslugiPage()
        {
            InitializeComponent();
        }
        private void MenuPage_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }
        private void NaitiButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DobavitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObnovitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VigruzButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
