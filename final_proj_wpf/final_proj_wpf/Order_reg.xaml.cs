using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace final_proj_wpf
{
    /// <summary>
    /// Логика взаимодействия для Order_reg.xaml
    /// </summary>
    public partial class Order_reg : Window
    {
        public ObservableCollection<Customer> customers { get; set; }
        public ObservableCollection<Product> products { get; set;}
        public Order order { get; set; }

        private int _numValue = 0;
        public Order_reg()
        {
            InitializeComponent();
            this.Customer_ComboBox.ItemsSource = customers;
            this.Product_ComboBox.ItemsSource = products;
            this.DataContext = new();
        }
        public Order_reg(ObservableCollection<Product> products, ObservableCollection<Customer> customers)
        {
            InitializeComponent();
            this.Customer_ComboBox.ItemsSource = customers;
            this.Product_ComboBox.ItemsSource = products;
            this.DataContext = new();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.Product_ComboBox.SelectedItem.ToString() != string.Empty && this.Customer_ComboBox.SelectedItem.ToString() != string.Empty &&
               this.Datepicker.SelectedDate.HasValue && this.quality_textbox.Text != string.Empty)
            {
                order = new(this.Customer_ComboBox.SelectedItem as Customer, Product_ComboBox.SelectedItem as Product, double.Parse(this.quality_textbox.Text), this.Datepicker.SelectedDate.Value);
                this.Close();
            }
            else
                MessageBox.Show("Неверно заполнены или незаполнены поля для регистрации");
        }
        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                quality_textbox.Text = value.ToString();
            }
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (quality_textbox == null)
            {
                return;
            }

            if (!int.TryParse(quality_textbox.Text, out _numValue))
                quality_textbox.Text = _numValue.ToString();
        }
    }
}
