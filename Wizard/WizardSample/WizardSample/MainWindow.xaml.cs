using Microsoft.UI.Xaml;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WizardSample.EventArguments;
using WizardSample.Model;

namespace WizardSample
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private ObservableCollection<Person> people = new();

        public MainWindow()
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
                Age = int.Parse(e.Data["Age"].ToString())
            };

            people.Add(person);
        }
    }
}
