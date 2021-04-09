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

            // current button
            Button btn = sender as Button;

            // Get the button name by using substring
            string buttonOperator = btn.Name.Substring(3).ToLower();

            // Get the result
            double finalResult = 0;
            switch (buttonOperator)
            {
                case "add":
                    finalResult = n1 + n2;
                    break;
                case "subtract":
                    finalResult = n1 - n2;
                    break;
                case "multiply":
                    finalResult = n1 * n2;
                    break;
                case "divide":
                    finalResult = n1 / n2;
                    break;
            }

            lblResult.Content = "The answer is " + finalResult.ToString("#,##0.00");
            lblResult.Visibility = Visibility.Visible;
        }

        private double GetNumber(TextBox txt)
        {
            double currentNumber;
            if (txt.Text.Trim().Length == 0)
            { 
                currentNumber = 0; 
            }
            try
            {
                return Convert.ToDouble(txt.Text);
            }
            catch
            {
                currentNumber = 0;
            }
            if (currentNumber == 0)
            {
                MessageBox.Show("You haven't entered a valid number in this text box!", "Error");
                return 0;
            }
            else
            {
                return currentNumber;
            }

        }
    }
}
