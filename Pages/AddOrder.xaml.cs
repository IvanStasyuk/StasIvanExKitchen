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

            if (string.IsNullOrEmpty(NomerOrder.Text))
                errors.AppendLine("Номер заказа не может быть меньше 0");
            if (string.IsNullOrEmpty(SostavOrder.Text))
                errors.AppendLine("Укажите состав заказа");
            if (string.IsNullOrEmpty(DataofOrder.Text))
                errors.AppendLine("Укажите дату заказа");
            if (string.IsNullOrEmpty(DataDeliveryofOrder.Text))
                errors.AppendLine("Укажите дату доставки заказа");
            if (string.IsNullOrEmpty(PickUpOrder.Text))
                errors.AppendLine("Укажите пункт выдачи заказа");
            if (string.IsNullOrEmpty(FIOOrder.Text))
                errors.AppendLine("Укажите ФИО заказчика заказа");
            if (string.IsNullOrEmpty(EnterCodeOrder.Text))
                errors.AppendLine("Код выдачи не может быть меньше 0");
            if (string.IsNullOrEmpty(StatusOrder.Text))
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
