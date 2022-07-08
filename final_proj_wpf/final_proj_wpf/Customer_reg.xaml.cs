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
    /// Логика взаимодействия для Customer_reg.xaml
    /// </summary>
    public partial class Customer_reg : Window
    {
        public Customer customer { get; set; }
        public Customer_reg()
        {
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name_textbox.Text != string.Empty && Surname_textbox.Text != string.Empty && Email_textbox.Text != string.Empty
                && Phonenmbr_maskedtextbox.Text != string.Empty && Adress_textbox.Text != string.Empty)
            {
                this.customer = new(Name_textbox.Text, Surname_textbox.Text, Email_textbox.Text, 
                    Phonenmbr_maskedtextbox.Text, Adress_textbox.Text);
                this.customer.create_Customer();
                Close();
            }
            else
            {
                MessageBox.Show("Неверно заполнены или незаполнены поля для регистрации");
            }
        }
    }
}
