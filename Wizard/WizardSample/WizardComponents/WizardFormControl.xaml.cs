using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Wizard.Library.Model;
using WizardComponents.EventArguments;

namespace WizardComponents
{
    public partial class WizardFormControl : UserControl
    {
        private Dictionary<string, object> _data = new Dictionary<string, object>();

        public WizardFormControl()
        {
            this.InitializeComponent();
        }

        #region Properties and events

        public string ConfigurationFile
        {
            get { return (string)GetValue(ConfigurationFileProperty); }
            set { SetValue(ConfigurationFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConfigurationFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConfigurationFileProperty =
            DependencyProperty.Register("ConfigurationFile", typeof(string), typeof(WizardComponent), new PropertyMetadata(string.Empty));


        public string SaveButtonText
        {
            get { return (string)GetValue(SaveButtonTextProperty); }
            set { SetValue(SaveButtonTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SaveButtonText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaveButtonTextProperty =
            DependencyProperty.Register("SaveButtonText", typeof(string), typeof(WizardComponent), new PropertyMetadata("Save"));


        public event EventHandler<FormSubmittedEventArgs> FormSubmitted;

        protected virtual void OnFormSubmitted(FormSubmittedEventArgs e)
        {
            EventHandler<FormSubmittedEventArgs> handler = FormSubmitted;
            handler?.Invoke(this, e);
        }

        #endregion

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(ConfigurationFile);
            var form = WizardFormSerializer.Deserialize<WizardForm>(json);

            RenderHeader(form);
            //RenderComponents(form);
        }

        private void RenderHeader(WizardForm form)
        {
            TextBlock header = new TextBlock
            {
                Text = form.Title,
                FontSize = 24,
                FontWeight = FontWeights.Bold
            };

            Container.Children.Add(header);
        }

        private void RenderComponents(WizardForm form)
        {
            foreach (var component in form.Components)
            {
                switch (component.Type)
                {
                    case WizardComponentType.Text:
                        TextBlock textBlock = new TextBlock
                        {
                            Name = $"tbl{component.Label}",
                            Text = component.FieldName
                        };

                        TextBox textBox = new TextBox
                        {
                            Name = $"txt{component.Label}",
                            PlaceholderText = component.Label,
                            Tag = component.FieldName
                        };

                        Container.Children.Add(textBlock);
                        Container.Children.Add(textBox);

                        break;
                    case WizardComponentType.Number:
                        TextBlock numberBlock = new TextBlock
                        {
                            Name = $"tbl{component.Label}",
                            Text = component.FieldName
                        };

                        NumberBox numberBox = new NumberBox
                        {
                            Text = component.Label,
                            SmallChange = 1,
                            LargeChange = 1,
                            SpinButtonPlacementMode = NumberBoxSpinButtonPlacementMode.Inline,
                            Tag = component.FieldName
                        };

                        Container.Children.Add(numberBlock);
                        Container.Children.Add(numberBox);

                        break;
                    default:
                        break;
                }
            }

            Button button = new Button
            {
                Name = "btnSubmit",
                Content = SaveButtonText
            };

            button.Click += (obj, args) =>
            {
                PopulateInfo();
                OnFormSubmitted(new FormSubmittedEventArgs(_data));
            };

            Container.Children.Add(button);
        }

        private void PopulateInfo()
        {
            _data.Clear();
            foreach (var control in Container.Children)
            {
                if (control is TextBox textBox)
                {
                    _data.Add(textBox.Tag.ToString(), textBox.Text);
                }
                if (control is NumberBox numberBox)
                {
                    _data.Add(numberBox.Tag.ToString(), numberBox.Text);
                }
            }
        }
    }
}
