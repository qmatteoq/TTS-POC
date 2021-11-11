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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WizardSample.Model;

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
            var json = await File.ReadAllTextAsync(ConfigurationFile);
            var form = JsonSerializer.Deserialize<Form>(json);
        }
    }
}
