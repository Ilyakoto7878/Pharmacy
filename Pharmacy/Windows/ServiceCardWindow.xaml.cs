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
using System.Windows.Shapes;

namespace Pharmacy.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServiceCardWindow.xaml
    /// </summary>
    public partial class ServiceCardWindow : Window
    {
        private ProductViewModel _selectedItem = null;
        private ProductRepository _repository;
        public ServiceCardWindow()
        {
            InitializeComponent();
        }

        public ServiceCardWindow(ProductViewModel selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                FullName.Text = selectedItem.name;
                BirthDate.Text = Convert.ToString(selectedItem.cost);
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
                _repository = new ProductRepository();
                if (BirthDate.Text.Count() != 0)
                {
                    if (_selectedItem != null)
                    {
                        var entity = new ProductViewModel
                        {
                            id = _selectedItem.id,
                            name = FullName.Text,
                            cost = Convert.ToInt64(BirthDate.Text),
                            //cost = BirthDate.Text,
                        };
                        if (_repository != null)
                        {
                            _repository.Update(entity);
                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show("LOX");
                        }
                    }
                    else
                    {
                        var entity = new ProductViewModel
                        {
                            name = FullName.Text,
                            cost = Convert.ToInt64(BirthDate.Text),
                        };
                        if (_repository != null)
                        {
                            _repository.Add(entity);
                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show("Chmo");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Поле 'День рождения' должно содержать хоть 1 символ");
                }

            }
            catch
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
