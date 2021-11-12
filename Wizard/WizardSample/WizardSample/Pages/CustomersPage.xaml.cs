using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using WizardSample.EventArguments;
using WizardSample.Model;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WizardSample.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomersPage : Page
    {
        private ObservableCollection<Person> people = new();

        public CustomersPage()
        {
            this.InitializeComponent();
            lstPeople.ItemsSource = people;
        }

        private void WizardComponent_FormSubmitted(object sender, FormSubmittedEventArgs e)
        {
            Person person = new Person
            {
                Name = e.Data["Name"].ToString(),
                Surname = e.Data["Surname"].ToString(),
                Age = int.Parse(e.Data["Age"].ToString()),
                BirthDate = DateTimeOffset.Parse(e.Data["BirthDate"].ToString())
            };

            people.Add(person);
        }
    }
}
