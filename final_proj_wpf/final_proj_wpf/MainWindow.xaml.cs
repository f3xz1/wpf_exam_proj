using System;
using System.Collections.Generic;
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

using System.IO;
using Newtonsoft.Json;

namespace final_proj_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Directory.CreateDirectory("WareHouse");
                Directory.CreateDirectory(IFiled.user_path);
                Directory.CreateDirectory(IFiled.customers_path);
                Directory.CreateDirectory(IFiled.orders_path);
                Directory.CreateDirectory(IFiled.products_path);

            }
            catch (Exception)
            {
                MessageBox.Show("неудалось создать папки");
                throw;
            }
        }
        public MainWindow(string log)
        {
            InitializeComponent();
            try
            {
                Directory.CreateDirectory("WareHouse");
                Directory.CreateDirectory(IFiled.user_path);
                Directory.CreateDirectory(IFiled.customers_path);
                Directory.CreateDirectory(IFiled.orders_path);
                Directory.CreateDirectory(IFiled.products_path);

            }
            catch (Exception)
            {
                MessageBox.Show("неудалось создать папки");
                throw;
            }
            this.Login_textbox.Text = log;
        }
        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            register register = new();
            register.ShowDialog();
            if(register.user != null)
            {
            this.Login_textbox.Text = register.user.login;
            this.Password_textbox.Password= register.user.password;
            }
        }

        private void Log_Button_Click(object sender, RoutedEventArgs e)
        {
            User myuser = new();
            if (!File.Exists(IFiled.user_path + "\\" + this.Login_textbox.Text + $"\\{ this.Login_textbox.Text}.json"))
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
            User temp = null;
            using (StreamReader reader = new StreamReader(IFiled.user_path + "\\" + this.Login_textbox.Text + $"\\{this.Login_textbox.Text}.json", true))
            {
                temp = JsonConvert.DeserializeObject<User>(reader.ReadLine());
            }
            if (temp.login == this.Login_textbox.Text && temp.password == this.Password_textbox.Password)
            {
                myuser.login = temp.login;
                myuser.password = temp.password;
                myuser.name = temp.name;
                myuser.surname = temp.surname;
                WareHouse wareHouse = new(myuser);
                this.Close();
                wareHouse.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
