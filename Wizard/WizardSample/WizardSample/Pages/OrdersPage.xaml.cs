using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using WizardSample.Model;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WizardSample.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrdersPage : Page
    {
        private ObservableCollection<Order> orders = new();

        public OrdersPage()
        {
            this.InitializeComponent();
            lstOrders.ItemsSource = orders;
        }

        private void WizardComponent_FormSubmitted(object sender, EventArguments.FormSubmittedEventArgs e)
        {
            Order order = new Order
            {
                Name = e.Data["Product"].ToString(),
                TotalPrice = double.Parse(e.Data["Total"].ToString()),
                OrderDate = DateTimeOffset.Parse(e.Data["OrderDate"].ToString())
            };

            orders.Add(order);
        }
    }
}
