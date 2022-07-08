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
    /// Interaction logic for Product_reg.xaml
    /// </summary>
    public partial class Product_reg : Window
    {
        public Product product { get; set; }
        private int _numValue = 0;
        public Product_reg()
        {
            InitializeComponent();
            quality_textbox.Text = _numValue.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(name_textbox.Text != string.Empty && price_textbox.Text != string.Empty && quality_textbox.Text != string.Empty)
            {
                product = new Product(name_textbox.Text, double.Parse(price_textbox.Text),
                    int.Parse(quality_textbox.Text), (new TextRange(description_richtextbox.Document.ContentStart, description_richtextbox.Document.ContentEnd)).Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверно заполнены или незаполнены поля для регистрации");
            }
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