using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Task
{
    public class Employees
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Enum Position { get; set; }
        public double Experience { get; set; }
        public bool Retiree { get; set; }
    }
}
