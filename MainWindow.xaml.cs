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

namespace StasIvanExKitchen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Classes.AppFrame.MainFrame = MainFrame;
            Classes.AppFrame.MainFrame.Navigate(new Pages.Autorisation());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Classes.AppFrame.MainFrame.GoBack();
        }

        private void btnVhodGost_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добро пожаловать, гость!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Classes.AppFrame.MainFrame.Navigate(new Pages.ProductsKitchen());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Classes.AppFrame.MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}
