using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
namespace final_proj_wpf
{
    public class User
    {
        public string login { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }

        public User(string login, string password, string name, string surname)
        {
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
        }
        public User()
        {

        }
        public bool create_user()
        {
            if (File.Exists(IFiled.user_path + "\\" + login + $"\\{login}.json"))
            {
                return false;
            }
            try
            {
                Directory.CreateDirectory(IFiled.user_path + "\\" + login);
                JsonSerializer serializer = new JsonSerializer();

                using (StreamWriter file = new StreamWriter(IFiled.user_path + "\\" + login + $"\\{login}.json", false))
                {
                    serializer.Serialize(file, this);
                }
                return true;
            }
            catch (Exception)
            {
                throw new Exception("register break");
            }
        }
        public override string ToString()
        {
            return "\n" + this.login + "\n" + this.password[0..2] + "...\n" + this.name + "\n";
        }
    }
}
