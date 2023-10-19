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

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TradeEntitiesKitchen.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataGridKitchen.ItemsSource = TradeEntitiesKitchen.GetContext().Product.ToList();
            }
        }
    }
}
