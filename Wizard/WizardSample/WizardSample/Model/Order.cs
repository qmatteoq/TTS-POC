using System;

namespace WizardSample.Model
{
    public class Order
    {
        public string Name { get; set; }
        public double TotalPrice { get; set; }

        public DateTimeOffset OrderDate { get; set; }
    }
}
