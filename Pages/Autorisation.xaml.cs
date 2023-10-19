using StasIvanExKitchen.Classes;
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

namespace StasIvanExKitchen.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Page
    {
        public Autorisation()
        {
            InitializeComponent();
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(Login.Text))
                sb.AppendLine("Логин не заполнен");
            if (string.IsNullOrEmpty(Password.Text))
                sb.AppendLine("Пароль не заполнен");
            MessageBox.Show(sb.ToString());
            try
            {
                var _currectUser = AppConnect.modelTrade.User.FirstOrDefault(q => q.UserLogin == Login.Text || q.UserPassword = Password.Text);
                if (_currectUser == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (_currectUser.UserRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуй, Администратор " + _currectUser.UserLogin + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 2:
                            MessageBox.Show("Здравствуй, Менеджер " + _currectUser.UserLogin + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 3:
                            MessageBox.Show("Здравствуй, Клиент " + _currectUser.UserLogin + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены " + _currectUser.UserLogin + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        private void Regbtn_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new Pages.Registration());
        }
    }
}
