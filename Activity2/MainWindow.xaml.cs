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

namespace Activity2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnOperator(object sender, RoutedEventArgs e)
        {

            // get the two numbers
            double n1 = GetNumber(this.txtNumber1);
            if (n1 == 0) { return; }

            double n2 = GetNumber(this.txtNumber2);
            if (n2 == 0) { return; }

            // now get the button which made this happen
            Button btn = sender as Button;

            // button names are btnAdd, btnSubtract, etc.
            string buttonOperator = btn.Name.Substring(3).ToLower();

            // calculate appropriate value
            double answer = 0;
            switch (buttonOperator)
            {
                case "add":
                    answer = n1 + n2;
                    break;
                case "subtract":
                    answer = n1 - n2;
                    break;
                case "multiply":
                    answer = n1 * n2;
                    break;
                case "divide":
                    answer = n1 / n2;
                    break;
            }

            lblAnswer.Content = "The answer is " + answer.ToString("#,##0.00");
            lblAnswer.Visibility = Visibility.Visible;
        }

        private double GetNumber(TextBox txt)
        {
            double thisNumber;
            if (txt.Text.Trim().Length == 0) { thisNumber = 0; }
            try
            {
                return Convert.ToDouble(txt.Text);
            }
            catch
            {
                thisNumber = 0;
            }
            if (thisNumber == 0)
            {
                MessageBox.Show("You haven't entered a valid number in this text box!", "Error");
                txt.Focus();
                return 0;
            }
            else
            {
                return thisNumber;
            }

        }
    }
}
