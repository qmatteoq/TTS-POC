using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Diagnostics;
using WizardSample.Pages;

namespace WizardSample
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NavigationView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            var itemContainer = args.InvokedItemContainer;
            
            FrameNavigationOptions navOptions = new FrameNavigationOptions();
            navOptions.TransitionInfoOverride = args.RecommendedNavigationTransitionInfo;
            Type pageType = typeof(CustomersPage);
            
            if (itemContainer.Tag.ToString() == "Customers")
            {
                pageType = typeof(CustomersPage);
                ContentFrame.NavigateToType(pageType, null, navOptions);
            }
            else if (itemContainer.Tag.ToString() == "Orders")
            {
                pageType = typeof(OrdersPage);
                ContentFrame.NavigateToType(pageType, null, navOptions);
            }
            else if (itemContainer.Tag.ToString() == "3DModel")
            {
                string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                int index = location.LastIndexOf("\\WizardSample\\");
                string source = $"{location.Substring(0, index)}\\3dModelHelloWorld\\3dModelHelloWorld.exe";

                Process.Start(source);
            }
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            Type pageType = typeof(CustomersPage);
            ContentFrame.NavigateToType(pageType, null, null);
        }
    }
}
