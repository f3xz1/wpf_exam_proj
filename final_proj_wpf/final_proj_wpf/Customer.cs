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
   public class Customer
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string adress { get; set; }
        public static ObservableCollection<Customer> customers { get; set; }

        static Customer()
        {
            if (File.Exists(IFiled.customers_path + "\\" + "Customers" + ".json"))
            {
                using (StreamReader reader = new(IFiled.customers_path + "\\" + "Customers" + ".json"))
                {
                    customers = JsonConvert.DeserializeObject<ObservableCollection<Customer>>(reader.ReadToEnd());
                }
            }
            else
            {
                customers = new();
                File.Create(IFiled.customers_path + "\\" + "Customers.json").Close();
            }
        }
        public Customer(string name, string surname, string email, string phone_number, string adress)
        {
                this.name = name;
                this.surname = surname;
                this.email = email;
                this.phone_number = phone_number;
                this.adress = adress;
        }
        public bool create_Customer()
        {
            //if (customers.Contains(this))////////////////////////////////////////////////////////
            //{
            //    MessageBox.Show("Пользователь с таким номером уже существует");
            //    return false;
            //}
            customers.Add(this);
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter wt = new StreamWriter(IFiled.customers_path + "\\" + "Customers" + ".json", false))
            {
                serializer.Serialize(wt, customers);
            }
            return true;
        }

        static public ObservableCollection<Customer> GetList()
        {
            if (customers != null)
                return customers;
            if (File.Exists(IFiled.customers_path + "\\" + "Customers" + ".json"))
            {
                using (StreamReader reader = new(IFiled.customers_path + "\\" + "Customers" + ".json"))
                {
                    return JsonConvert.DeserializeObject<ObservableCollection<Customer>>(reader.ReadToEnd());
                }
            }
            else
            {
                File.Create(IFiled.customers_path + "\\" + "Customers.json").Close();
                return new();
            }
        }
    }
}