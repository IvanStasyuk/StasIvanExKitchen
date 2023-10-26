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
    /// Логика взаимодействия для ProductsKitchen.xaml
    /// </summary>
    public partial class ProductsKitchen : Page
    {
        public ProductsKitchen()
        {
            InitializeComponent();
        }

        private void btnEditTovar_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new Pages.AddTovarKitchen((sender as Button).DataContext as Product));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new Pages.AddTovarKitchen(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var tovarRemoving = DataGridKitchen.SelectedItems.Cast<Product>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {tovarRemoving.Count()} элементов",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TradeEntitiesKitchen.GetContext().Product.RemoveRange(tovarRemoving);
                    TradeEntitiesKitchen.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DataGridKitchen.ItemsSource = TradeEntitiesKitchen.GetContext().Product.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TradeEntitiesKitchen.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataGridKitchen.ItemsSource = TradeEntitiesKitchen.GetContext().Product.ToList();
            }
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new OrdersMain());
        }
    }
}
