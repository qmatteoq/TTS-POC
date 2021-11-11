using System;
using System.Collections.Generic;

namespace WizardSample.EventArguments
{
    public class FormSubmittedEventArgs : EventArgs
    {
        public FormSubmittedEventArgs(Dictionary<string, object> data)
        {
            Data = data;
        }

        public Dictionary<string, object> Data { get; set; }
    }
}
