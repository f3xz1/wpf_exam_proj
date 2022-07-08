using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace final_proj_wpf
{
    public class Product
    {
        public string name { get; set; }
        public double price { get; set; }
        public double quality { get; set; }
        public string description { get; set; }
        public static ObservableCollection<Product> products { get; set; }
        public Product(string name, double price, int quality, string description)
        {
            this.name = name;
            this.price = price;
            this.quality = quality;
            this.description = description;
        }
        static Product()
        {
            if (File.Exists(IFiled.products_path + "\\" + "products" + ".json"))
            {
                using (StreamReader reader = new(IFiled.products_path + "\\" + "products" + ".json"))
                {
                    products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(reader.ReadToEnd());
                }
            }
            else
            {

                File.Create(IFiled.products_path + "\\" + "products" + ".json").Close();
                products = new();
            }
        }
        public bool create_product()
        {
            products.Add(this);
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter wt = new StreamWriter(IFiled.products_path + "\\" + "products" + ".json", false))
            {
                serializer.Serialize(wt, products); 
            }
            return true;
        }
        static public ObservableCollection<Product> GetList()
        {
            if (products != null)
                return products;
            if (File.Exists(IFiled.products_path + "\\" + "products" + ".json"))
            {
                using (StreamReader reader = new(IFiled.products_path + "\\" + "products" + ".json"))
                {
                    return JsonConvert.DeserializeObject<ObservableCollection<Product>>(reader.ReadToEnd());
                }
            }
            else
            {
                File.Create(IFiled.products_path + "\\" + "products" + ".json").Close();
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter wt = new StreamWriter(IFiled.products_path + "\\" + "products" + ".json", false))
                {
                    serializer.Serialize(wt, new ObservableCollection<Product>());
                }
                return new();
            }
        }
    }
}