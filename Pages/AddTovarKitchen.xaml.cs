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
    /// Логика взаимодействия для AddTovarKitchen.xaml
    /// </summary>
    public partial class AddTovarKitchen : Page
    {
        private Product AddingTovar = new Product();
        public AddTovarKitchen(Classes.Product product)
        {
            InitializeComponent();
            DataContext = AddingTovar;
        }

        private void SavebtnTovar_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(ArticleAddBox.Text))
                errors.AppendLine("Укажите артикул товара");
            if (string.IsNullOrEmpty(NameAddBox.Text))
                errors.AppendLine("Укажите название товара");
            if (string.IsNullOrEmpty(DescriptionAddBox.Text))
                errors.AppendLine("Укажите описание товара");
            if (string.IsNullOrEmpty(CategoryAddBox.Text))
                errors.AppendLine("Укажите категорию товара");
            if (PhotoAddBox.Text == null)
                errors.AppendLine("Укажите фотографию товара");
            if (string.IsNullOrEmpty(ManufacturerAddBox.Text))
                errors.AppendLine("Укажите производителя товара");
            if (int.Parse(CostAddBox.Text) <= 0)
                errors.AppendLine("Цена не может быть меньше 0");
            if (int.Parse(MaxDiscountAddBox.Text) <= 0)
                errors.AppendLine("Максимальная скидка не может быть меньше 0");
            if (int.Parse(DiscountAmountAddBox.Text) <= 0)
                errors.AppendLine("Скидка не может быть меньше 0");
            if (int.Parse(QuantityInStockAddBox.Text) <= 0)
                errors.AppendLine("Должен храниться как минимум 1 товар");
            if (string.IsNullOrEmpty(ProviderAddBox.Text))
                errors.AppendLine("Укажите заказчика");
            if (string.IsNullOrEmpty(UnitAddBox.Text))
                errors.AppendLine("Укажите единицу измерения");
            if (string.IsNullOrEmpty(StatusAddBox.Text))
                errors.AppendLine("Укажите статус товара");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (AddingTovar.ProductCost > 0)
            {
                TradeEntitiesKitchen.GetContext().Product.Add(AddingTovar);
            }
            try
            {
                TradeEntitiesKitchen.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                AppFrame.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
