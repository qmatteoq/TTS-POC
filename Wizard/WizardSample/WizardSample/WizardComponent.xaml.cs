using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Net.Http;
using Wizard.Library.Model;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WizardSample
{
    public sealed partial class WizardComponent : UserControl
    {
        public WizardComponent()
        {
            this.InitializeComponent();
        }

        public string ConfigurationFile
        {
            get { return (string)GetValue(ConfigurationFileProperty); }
            set { SetValue(ConfigurationFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConfigurationFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConfigurationFileProperty =
            DependencyProperty.Register("ConfigurationFile", typeof(string), typeof(WizardComponent), new PropertyMetadata(string.Empty));

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(ConfigurationFile);
            var form = WizardFormSerializer.Deserialize<WizardForm>(json);

            RenderHeader(form);
            RenderComponents(form);
        }

        private void RenderHeader(WizardForm form)
        {
            TextBlock header = new TextBlock
            {
                Text = form.Title,
                FontSize = 24,
                FontWeight = FontWeights.Bold
            };

            WizardPanel.Children.Add(header);
        }

        private void RenderComponents(WizardForm form)
        {
            foreach (var component in form.Components)
            {
                switch (component.Type)
                {
                    case WizardComponentType.TextBlock:
                        break;
                    case WizardComponentType.TextBox:
                        break;
                    case WizardComponentType.Button:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
