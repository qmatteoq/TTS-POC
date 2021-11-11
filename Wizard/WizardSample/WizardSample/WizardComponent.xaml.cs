using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
            var form = JsonSerializer.Deserialize<WizardForm>(json);

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
                    default:
                }
            }
        }
    }
}
