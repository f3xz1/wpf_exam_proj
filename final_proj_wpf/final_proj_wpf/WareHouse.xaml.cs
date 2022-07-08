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
    /// Логика взаимодействия для WareHouse.xaml
    /// </summary>
    public partial class WareHouse : Window
    {
        public User user { get; set; }
        public ObservableCollection<Product> products { get; set; }
        public ObservableCollection<Customer> customers { get; set; }
        public ObservableCollection<Order> orders { get; set; }
        //public List<Product> products { get; set; }
        //public List<Customer> customers { get; set; }
        //public List<Order> orders { get; set; }
        public WareHouse(User user)
        {
            InitializeComponent();
            this.user = user;
            //products = Product.GetList();
            //customers = Customer.GetList();
            //orders = Order.GetList();

            products = new ObservableCollection<Product>(Product.GetList());
            customers = new ObservableCollection<Customer>(Customer.GetList());
            orders = new ObservableCollection<Order>(Order.GetList());
            this.Products_ListView.ItemsSource = products;
            this.Customers_ListView.ItemsSource = customers;
            this.Orders_ListView.ItemsSource = orders; 
            this.DataContext = new();
            
        }
        public WareHouse()
        {
            InitializeComponent();
            //products = Product.GetList();
            //customers = Customer.GetList();
            //orders = Order.GetList();

            products = new ObservableCollection<Product>(Product.GetList());
            customers = new ObservableCollection<Customer>(Customer.GetList());
            orders = new ObservableCollection<Order>(Order.GetList());
            this.Products_ListView.ItemsSource = products;
            this.Customers_ListView.ItemsSource = customers;
            this.Orders_ListView.ItemsSource = orders;
            this.DataContext = new();
        }

        private void LogoutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(user.login);
            Close();
            mainWindow.Show();
        }
        private void Add_Client_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Customer_reg customer_Reg = new();
            customer_Reg.ShowDialog();
            if (customer_Reg != null)
                customer_Reg.customer.create_Customer();
        }
        private void Order_Add_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Order_reg order_Reg = new(products, customers);
            order_Reg.ShowDialog();
            if (order_Reg.order != null)
                order_Reg.order.create_order();
        }
        private void Product_Add_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Product_reg product_Reg = new();
            product_Reg.ShowDialog();
            if (product_Reg.product != null)
                product_Reg.product.create_product();
        }
        private void Client_List_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Customers_ListView.Visibility = Visibility.Visible;
            this.Orders_ListView.Visibility = Visibility.Hidden;
            this.Products_ListView.Visibility = Visibility.Hidden;
        }
        private void Order_List_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Customers_ListView.Visibility = Visibility.Hidden;
            this.Orders_ListView.Visibility = Visibility.Visible;
            this.Products_ListView.Visibility = Visibility.Hidden;
        }
        private void Product_List_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Customers_ListView.Visibility = Visibility.Hidden;
            this.Orders_ListView.Visibility = Visibility.Hidden;
            this.Products_ListView.Visibility = Visibility.Visible;
        }

        
    }
}