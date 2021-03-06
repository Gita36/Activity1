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

namespace Activity3
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
		private void Button1_Click(object sender, RoutedEventArgs e)
		{
			Process();
		}
		//Create a Delegate that matches the Signature of the ProgressBar's SetValue method
		private delegate void UpdateProgressBarDelegate(System.Windows.DependencyProperty dp, Object value);


		private void Process()
		{
			//Configure the ProgressBar
			ProgressBar1.Minimum = 0;
			ProgressBar1.Maximum = short.MaxValue;
			ProgressBar1.Value = 0;

			//Stores the value of the ProgressBar
			double value = 0;

			
			UpdateProgressBarDelegate updatePbDelegate = new UpdateProgressBarDelegate(ProgressBar1.SetValue);

			//Tight Loop:  Loop until the ProgressBar.Value reaches the max
			do
			{
				value += 1;

				
				Dispatcher.Invoke(updatePbDelegate,
					System.Windows.Threading.DispatcherPriority.Background,
					new object[] { ProgressBar.ValueProperty, value });

			}
			while (ProgressBar1.Value != ProgressBar1.Maximum);

		}
	}
}
