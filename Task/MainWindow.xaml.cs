using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            InitializeComponent();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Task.Properties.Settings.Default.Save();
            base.OnClosing(e);
        }

        private void btnDeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            if (ListView.SelectedItem != null)
            {
                if (MessageBox.Show(this, "Do you really want to Delete this Record",
                   "Attention", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    ((ObservableCollection<Employees>)ListView.ItemsSource).Remove((Employees)ListView.SelectedItem);
                }
            }
            else
                MessageBox.Show("Please select element");
        }

        private void btnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            AddElementWindow ew = new AddElementWindow();
            ew.ListView = ListView;
            ew.Owner = this;
            ew.Show();
        }

        private void btnEditRecord_Click(object sender, RoutedEventArgs e)
        {
            if (ListView.SelectedItem != null)
            {
                EditElementWindow ew = new EditElementWindow();
                ew.emp = (Employees)ListView.SelectedItem;
                ew.loadEmployees();
                ew.Owner = this;
                ew.Show();
            }
            else
                MessageBox.Show("Please select element");
        }

        private void btnSaveXML_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                XElement doc = new XElement("employees");
                foreach (Employees xnode in ListView.ItemsSource)
                    doc.Add(new XElement("employee", new XElement("name", xnode.Name), new XElement("age", xnode.Age), new XElement("position", xnode.Position),
                        new XElement("experience", xnode.Experience), new XElement("retiree", xnode.Retiree)));
                doc.Save(saveFileDialog.FileName);
            }
        }

        private void btnLoadXML_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Employees> empList = new ObservableCollection<Employees>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if (((ObservableCollection<Employees>)ListView.ItemsSource) != null)
                    ((ObservableCollection<Employees>)ListView.ItemsSource).Clear();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(openFileDialog.FileName);
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Name == "employee")
                    {
                        Employees emp = new Employees();
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "name")
                                emp.Name = childnode.InnerText;
                            if (childnode.Name == "age")
                                emp.Age = Convert.ToInt32(childnode.InnerText);
                            if (childnode.Name == "position")
                                emp.Position = (Position)Enum.Parse(typeof(Position), childnode.InnerText, true);
                            if (childnode.Name == "experience")
                                emp.Experience = Convert.ToDouble(childnode.InnerText);
                            if (childnode.Name == "retiree")
                                emp.Retiree = Convert.ToBoolean(childnode.InnerText);
                        }
                        empList.Add(emp);
                    }
                }
                ListView.ItemsSource = empList;
            }
        }
    }
}
