using Microsoft.UI.Xaml;
using System.Diagnostics;
using WizardSample.EventArguments;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

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

        private void WizardComponent_FormSubmitted(object sender, FormSubmittedEventArgs e)
        {
            foreach (var item in e.Data)
            {
                Debug.WriteLine($"Key: {item.Key} - Value: {item.Value}");
            }
        }
    }
}
