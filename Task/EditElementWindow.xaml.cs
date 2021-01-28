using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Task
{
    /// <summary>
    /// Логика взаимодействия для EditElementWindow.xaml
    /// </summary>
    public partial class EditElementWindow : Window
    {
        public EditElementWindow()
        {
            InitializeComponent();            
        }

        public void loadEmployees()
        {
            Employees empl = (Employees)this.Resources["empl"];
            empl.Name = emp.Name;
            empl.Age = emp.Age;
            empl.Position = emp.Position;
            empl.Experience = emp.Experience;
            empl.Retiree = emp.Retiree;
        }

        public Employees emp { get; set; }

        private void btnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            Employees empl = (Employees)this.Resources["empl"];
            emp.Name = Name.Text;
            emp.Age = Convert.ToInt32(Age.Text);
            emp.Position = (Position)Enum.Parse(typeof(Position), Position.Text, true);
            emp.Experience = Convert.ToDouble(Experience.Text.Replace('.', ','));
            emp.Retiree = Convert.ToBoolean(Retiree.Text);
            Close();
        }


    }
}
