using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemperatureSimulation generator = new TemperatureSimulation();
       
        public MainWindow()
        {
            InitializeComponent();
            StatusBar.Items.Add("Ready");
        }
        public int? getNumberOfElements()
        {
            int el=0;
            int? val = null;
            var numElements= NumberOfElements.Text;
            if (numElements != "")
            {
                val = Int32.TryParse(numElements, out el) ? el : (int?)null;
                if (val!=null) { }
                else
                {
                    MessageBox.Show("Put proper number of elements!", "Error message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else { val = null; }

            return val;
        }
        public int? getRangeFrom()
        {
            int el = 0;
            int? val = null;
            var rangeFrom = RangeFrom.Text;
            if(rangeFrom!= "")
            {
                val = Int32.TryParse(rangeFrom, out el) ? el : (int?)null;
                if (val != null) {}
                else
                {
                    MessageBox.Show("Put proper range form!", "Error message", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else { val = null; }

            return val;
        }
        public int? getRangeTo()
        {
            int el = 0;
            int? val = null;
            var rangeTo = RangeTo.Text;
            if (rangeTo != "")
            {
                val = Int32.TryParse(rangeTo, out el) ? el : (int?)null;
                if (val != null) { }
                else
                {
                    MessageBox.Show("Put proper range to!", "Error message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else { val = null; }

            return val;
        }

        private void StartClicked(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "";
            ProgresText.Content = "0%";
            ProgressBar.Value = 0;
            int? numEle = null;
            int? ranFro = null;
            int? ranTo = null;
            numEle = getNumberOfElements();
            ranFro = getRangeFrom();
            ranTo = getRangeTo();
            if(numEle != null && ranFro !=null && ranTo !=null)
            {
                StatusBar.Items.Add("Wait generation number in progress!");
                var table= generator.GetData(numEle.Value,ranFro.Value,ranTo.Value);
                double procentage = 100/table.Count();
                foreach(var i in table)
                {
                    TextBox.Text += i.ToString()+"\n";
                    ProgressBar.Dispatcher.Invoke(() => ProgressBar.Value += procentage, DispatcherPriority.Background);
                    ProgresText.Content = ProgressBar.Value.ToString()+"%";
                    Thread.Sleep(500);
                }
               
                ProgressBar.Dispatcher.Invoke(() => ProgressBar.Value += procentage, DispatcherPriority.Background);
                ProgresText.Content = ProgressBar.Value.ToString() + "%";

            }
            else
            {
                MessageBox.Show("Some value is missing", "Error message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void about_clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Author: Dominik Romanow", "About");
        }

        private void exit_clicked(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Do you want close aplication?", "Exit", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                
            }
            else
            {
                App.Current.Shutdown();
            }
        }

        private void new_clicked(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "";
            ProgressBar.Value = 0;
            ProgresText.Content = "0%";
            RangeTo.Text = "";
            RangeFrom.Text = "";
            NumberOfElements.Text = "";
        }

        private void load_clicked(object sender, RoutedEventArgs e)
        {

        }

        private void save_cliced(object sender, RoutedEventArgs e)
        {

        }
    }
}
