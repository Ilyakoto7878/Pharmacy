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
using Pharmacy.Infrastructure;
using Pharmacy;
using Pharmacy.Infrastructure.ViewModels;
using Pharmacy.Pages;
using Pharmacy.Infrastructure.Mappers;
using Pharmacy.Infrastructure.Database;
using Pharmacy.Windows;

namespace Pharmacy.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientCardWindow.xaml
    /// </summary>



    public partial class ClientCardWindow : Window
    {
        private ClientViewModel _selectedItem = null;
        private ClientRepository _repository;
        public ClientCardWindow()
        {
            InitializeComponent();
        }

        public ClientCardWindow(ClientViewModel selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                FullName.Text = selectedItem.fio;
                BirthDate.Text = selectedItem.dataRozd;
            }
            else
            {
                _selectedItem = selectedItem;
                FullName.Text = null;
                BirthDate.Text = null;
            }
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                _repository = new ClientRepository();
                if (BirthDate.Text.Count() == 10)
                {
                    if (_selectedItem != null)
                    {
                        var entity = new ClientViewModel
                        {
                            id = _selectedItem.id,
                            fio = FullName.Text,
                            dataRozd = BirthDate.Text,
                        };
                        if (_repository != null)
                        {
                            _repository.Update(entity);
                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show("Пусто");
                        }
                    }
                    else
                    {
                        var entity = new ClientViewModel
                        {
                            fio = FullName.Text,
                            dataRozd = BirthDate.Text,
                        };
                        if (_repository != null)
                        {
                            _repository.Add(entity);
                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show("Пусто");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Поле 'День рождения' должно содержать 10 символов");
                }
                
            }
            catch
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }   
}
