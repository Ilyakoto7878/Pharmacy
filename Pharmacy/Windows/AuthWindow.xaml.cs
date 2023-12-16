using Pharmacy.Infrastructure;
using Pharmacy.Infrastructure.Consts;
using Pharmacy.Infrastructure.Database;
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
using System.Windows.Shapes;

namespace Pharmacy.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            List<UserEntity> userEntities = new List<UserEntity>();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(Login.Text != "" && Password.Password != "")
            {
                UserRepository userRepository = new UserRepository();
                userRepository.Login(Login.Text, Password.Password);
                if (userRepository.Login(Login.Text, Password.Password) != null)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
        private void QuestLogin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[UserInfoConsts.RoleId] = 1;
            Application.Current.Resources[UserInfoConsts.RoleName] = "Гость";   
            Application.Current.Resources[UserInfoConsts.UserName] = "Гость";
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
