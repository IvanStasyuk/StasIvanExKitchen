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
    /// Логика взаимодействия для OrdersMain.xaml
    /// </summary>
    public partial class OrdersMain : Page
    {
        public OrdersMain()
        {
            InitializeComponent();
            if (AppFrame._currentUser == null)
            {
                btnAddOrder.IsEnabled = false;
                btnAddOrder.ToolTip = "У вас нет прав";
                btnDeleteOrder.IsEnabled = false;
                btnDeleteOrder.ToolTip = "У вас нет прав";
            }
            //
            else
            {
                try
                {
                    switch (AppFrame._currentUser.UserRole)
                    {
                        case 1:
                            btnAddOrder.IsEnabled = true;
                            btnAddOrder.ToolTip = "У вас нет прав";
                            btnDeleteOrder.IsEnabled = true;
                            btnDeleteOrder.ToolTip = "У вас нет прав";
                            break;
                        case 2:
                            btnAddOrder.IsEnabled = false;
                            btnAddOrder.ToolTip = "У вас нет прав";
                            btnDeleteOrder.IsEnabled = true;
                            btnDeleteOrder.ToolTip = "У вас нет прав";
                            break;
                        case 3:
                            btnAddOrder.IsEnabled = true;
                            btnAddOrder.ToolTip = "У вас нет прав";
                            btnDeleteOrder.IsEnabled = false;
                            btnDeleteOrder.ToolTip = "У вас нет прав";
                            break;
                        default:
                            btnAddOrder.IsEnabled = false;
                            btnAddOrder.ToolTip = "У вас нет прав";
                            btnDeleteOrder.IsEnabled = false;
                            btnDeleteOrder.ToolTip = "У вас нет прав";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + ex.Message.ToString() + "Критическая ошибка приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TradeEntitiesKitchen.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataGridOrders.ItemsSource = TradeEntitiesKitchen.GetContext().Order.ToList();
            }
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new AddOrder());
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var tovarRemoving = DataGridOrders.SelectedItems.Cast<Order>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {tovarRemoving.Count()} элементов",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TradeEntitiesKitchen.GetContext().Order.RemoveRange(tovarRemoving);
                    TradeEntitiesKitchen.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DataGridOrders.ItemsSource = TradeEntitiesKitchen.GetContext().Order.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
