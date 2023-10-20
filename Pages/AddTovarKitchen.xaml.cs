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
            var _currectProduct = AppConnect.modelTrade.Product.FirstOrDefault(q => q.ProductArticleNumber = byte.Parse(ArticleAddBox.Text) && q.ProductName == NameAddBox.Text && q.ProductDescription == DescriptionAddBox.Text && q.ProductCategory == CategoryAddBox.Text && q.ProductPhoto = bool.Parse(PhotoAddBox.Text) && q.ProductManufacturer == ManufacturerAddBox.Text && q.ProductCost == int.Parse(CostAddBox.Text) && q.ProductMaxDiscount == int.Parse(MaxDiscountAddBox.Text) && q.ProductDiscountAmount == int.Parse(DiscountAmountAddBox.Text) && q.ProductQuantityInStock == int.Parse(QuantityInStockAddBox.Text) && q.ProductProvider == ProviderAddBox.Text && q.ProductUnit == UnitAddBox.Text && q.ProductStatus == StatusAddBox.Text);

            if (string.IsNullOrEmpty(AddingTovar.ProductArticleNumber))
                errors.AppendLine("Укажите артикул товара");
            if (string.IsNullOrEmpty(AddingTovar.ProductName))
                errors.AppendLine("Укажите название товара");
            if (string.IsNullOrEmpty(AddingTovar.ProductDescription))
                errors.AppendLine("Укажите описание товара");
            if (string.IsNullOrEmpty(AddingTovar.ProductCategory))
                errors.AppendLine("Укажите категорию товара");
            if (AddingTovar.ProductPhoto == null)
                errors.AppendLine("Укажите фотографию товара");
            if (string.IsNullOrEmpty(AddingTovar.ProductManufacturer))
                errors.AppendLine("Укажите производителя товара");
            if (AddingTovar.ProductCost <= 0)
                errors.AppendLine("Цена не может быть меньше 0");
            if (AddingTovar.ProductMaxDiscount <= 0)
                errors.AppendLine("Максимальная скидка не может быть меньше 0");
            if (AddingTovar.ProductDiscountAmount <= 0)
                errors.AppendLine("Скидка не может быть меньше 0");
            if (AddingTovar.ProductQuantityInStock <= 0)
                errors.AppendLine("Должен храниться как минимум 1 товар");
            if (AddingTovar.ProductProvider == null)
                errors.AppendLine("Укажите заказчика");
            if (AddingTovar.ProductUnit == null)
                errors.AppendLine("Укажите единицу измерения");
            if (string.IsNullOrEmpty(AddingTovar.ProductStatus))
                errors.AppendLine("Укажите статус товара");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (AddingTovar == null)
            {
                MessageBox.Show("Информация сохранена");
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
