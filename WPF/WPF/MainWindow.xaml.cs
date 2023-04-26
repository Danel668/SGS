using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace WPF
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CityComboBox.ItemsSource = cities;
            BrigadeComboBox.ItemsSource = brigades;
        }

        // Seed Data
        private List<string> cities = new List<string> { "Москва", "Санкт-Петербург", "Новосибирск" };

        private Dictionary<string, List<string>> factories = new Dictionary<string, List<string>> {
            { "Москва", new List<string> { "Завод 1", "Завод 2" } },
            { "Санкт-Петербург", new List<string> { "Завод 3", "Завод 4" } },
            { "Новосибирск", new List<string> { "Завод 5", "Завод 6" } }
        };

        private Dictionary<string, List<string>> employees = new Dictionary<string, List<string>> {
            { "Завод 1", new List<string> { "Сотрудник 1", "Сотрудник 2" } },
            { "Завод 2", new List<string> { "Сотрудник 3", "Сотрудник 4" } },
            { "Завод 3", new List<string> { "Сотрудник 5", "Сотрудник 6" } },
            { "Завод 4", new List<string> { "Сотрудник 7", "Сотрудник 8" } },
            { "Завод 5", new List<string> { "Сотрудник 9", "Сотрудник 10" } },
            { "Завод 6", new List<string> { "Сотрудник 11", "Сотрудник 12" } }
        };

        private List<string> brigades = new List<string> { "Бригада 1", "Бригада 2", "Бригада 3" };

        // Events
        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCity = (string)CityComboBox.SelectedItem;
            FactoryComboBox.ItemsSource = factories[selectedCity];
            EmployeeComboBox.ItemsSource = null;
            FactoryComboBox.IsEnabled = true;
        }

        private void FactoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedFactory = (string)FactoryComboBox.SelectedItem;

            if (selectedFactory!= null)
                EmployeeComboBox.ItemsSource = employees[selectedFactory];
            
            EmployeeComboBox.IsEnabled = true;
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            var md = new SavedModel()
            {
                City = (string)CityComboBox.SelectedValue,
                Factory = (string)FactoryComboBox.SelectedValue,
                Employee = (string)EmployeeComboBox.SelectedValue,
                Brigade = (string)BrigadeComboBox.SelectedValue,
                Shift = ShiftTextBox.Text
            };

            var json = JsonConvert.SerializeObject(md);
            File.WriteAllText("appData.json", json);

            MessageBox.Show("Данные успешно сохранены!");
        }

    }
}
