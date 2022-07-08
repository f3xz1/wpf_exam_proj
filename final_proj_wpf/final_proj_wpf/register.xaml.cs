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
using System.Windows.Shapes;

namespace final_proj_wpf
{
    /// <summary>
    /// Логика взаимодействия для register.xaml
    /// </summary>
    /// 
    public partial class register : Window
    {
    public User user { get; set; }
        public register()
        {
            InitializeComponent();
        }
        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name_textbox.Text != string.Empty && Surname_textbox.Text != string.Empty 
                && Username_textbox.Text != string.Empty 
                && Password1_textbox.Password != string.Empty 
                && Password1_textbox.Password == Password2_textbox.Password)
            {
                this.user = new(Username_textbox.Text,Password1_textbox.Password, Name_textbox.Text,Surname_textbox.Text);

                if (user.create_user())
                    Close();
                else
                    MessageBox.Show("пользователь с таким логином уже существует");
            }
            else
            MessageBox.Show("Неверно заполнены или незаполнены поля для регистрации");
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
