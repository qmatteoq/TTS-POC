﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardSample.Model
{
    public class Person
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public DateTimeOffset BirthDate { get; set; }
    }
}
