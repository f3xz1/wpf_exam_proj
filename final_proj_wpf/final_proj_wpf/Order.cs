using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows;
using System.Collections.ObjectModel;

namespace final_proj_wpf
{
    public class Order
    {
        public Customer customer { get; set; }
        public Product product { get; set; }
        public double quality { get; set; }
        public DateTime arrive_date{ get; set; }
        public static ObservableCollection<Order> orders { get; set; }
        static Order()
        {
            if (File.Exists(IFiled.orders_path + "\\" + "orders" + ".json"))
            {
                using (StreamReader reader = new(IFiled.orders_path + "\\" + "orders" + ".json"))
                {
                    orders = JsonConvert.DeserializeObject<ObservableCollection<Order>>(reader.ReadToEnd());
                }
            }
            else
            {
                orders = new();
                File.Create(IFiled.orders_path + "\\" + "orders.json").Close();
            }
        }
        public Order(Customer customer, Product product, double quality,DateTime arrive_date)
        {
            this.customer = customer;
            this.product = product;
            this.quality = quality;
            this.arrive_date = arrive_date;
        }
        public bool create_order()
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                orders.Add(this);
                using (StreamWriter file = new StreamWriter(IFiled.orders_path + $"\\orders.json", false))
                {
                    serializer.Serialize(file, orders);
                }
                this.product.quality -= this.quality;
                return true;
            }
            catch (Exception)
            {
                throw new Exception("register break");
            }
        }
        static public ObservableCollection<Order> GetList()
        {
            if (orders != null)
                return orders;
            if (File.Exists(IFiled.orders_path + "\\" + "orders" + ".json"))
            {
                using (StreamReader reader = new(IFiled.orders_path + "\\" + "orders" + ".json"))
                {
                    ObservableCollection<Order> ts = JsonConvert.DeserializeObject<ObservableCollection<Order>>(reader.ReadToEnd());
                    if (ts != null)
                        return ts;
                    return new();
                }
            }
            else
            {
                File.Create(IFiled.orders_path + "\\" + "orders.json").Close();
                return new();
            }
        }
    }
}