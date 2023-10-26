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
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Page
    {
        private Order AddingOrder = new Order();
        public AddOrder()
        {
            InitializeComponent();
            DataContext = AddingOrder;
        }

        private void SavebtnOrder_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (AddingOrder.NumberOrder <= 0)
                errors.AppendLine("Номер заказа не может быть меньше 0");
            if (string.IsNullOrEmpty(AddingOrder.SostavOrder))
                errors.AppendLine("Укажите состав заказа");
            //if (DateTime.Parse(AddingOrder.OrderDate != true))
                //errors.AppendLine("Укажите дату заказа");
            //if (DateTime.Parse(AddingOrder.OrderDeliveryDate.Year.ToString()) > DateTime.Now)
                //errors.AppendLine("Укажите дату доставки заказа");
            if (string.IsNullOrEmpty(AddingOrder.OrderPickupPoint))
                errors.AppendLine("Укажите пункт выдачи заказа");
            if (string.IsNullOrEmpty(AddingOrder.FioUser))
                errors.AppendLine("Укажите ФИО заказчика заказа");
            if (AddingOrder.CodeEnter <= 0)
                errors.AppendLine("Код выдачи не может быть меньше 0");
            if (string.IsNullOrEmpty(AddingOrder.OrderStatus))
                errors.AppendLine("Укажите статус заказа");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (AddingOrder.CodeEnter > 0)
            {
                TradeEntitiesKitchen.GetContext().Order.Add(AddingOrder);
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
