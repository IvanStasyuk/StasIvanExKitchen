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
            if (AppFrame._currentUser == null)
            {
                btnAdd.IsEnabled = false;
                btnAdd.ToolTip = "У вас нет прав";
                btnDelete.IsEnabled = false;
                btnDelete.ToolTip = "У вас нет прав";
            }
                //
            else
            {
                try
                {
                    switch (AppFrame._currentUser.UserRole)
                    {
                        case 1:
                            btnAdd.IsEnabled = true;
                            btnDelete.IsEnabled = true;
                            break;
                        case 2:
                            btnAdd.IsEnabled = false;
                            btnAdd.ToolTip = "У вас нет прав";
                            btnDelete.IsEnabled = true;
                            break;
                        case 3:
                            btnAdd.IsEnabled = true;
                            btnDelete.IsEnabled = false;
                            btnDelete.ToolTip = "У вас нет прав";
                            break;
                        default:
                            btnAdd.IsEnabled = false;
                            btnAdd.ToolTip = "У вас нет прав";
                            btnDelete.IsEnabled = false;
                            btnDelete.ToolTip = "У вас нет прав";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + ex.Message.ToString() + "Критическая ошибка приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } 
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
