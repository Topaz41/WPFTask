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
    public partial class AddElementWindow : Window
    {
        public AddElementWindow()
        {
            InitializeComponent();
        }

        public ListView ListView { get; set; }

        private void btnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            Employees emp = new Employees();
            emp.Name = Name.Text;
            emp.Age = Convert.ToInt32(Age.Text);
            emp.Position = (Position)Enum.Parse(typeof(Position),Position.Text,true);
            emp.Experience = Convert.ToDouble(Experience.Text);
            emp.Retiree = Convert.ToBoolean(Retiree.Text);
            if (ListView.ItemsSource == null)
                ListView.ItemsSource = new ObservableCollection<Employees>();

            ((ObservableCollection<Employees>)ListView.ItemsSource).Add(emp);

            Close();
        }
    }
}
