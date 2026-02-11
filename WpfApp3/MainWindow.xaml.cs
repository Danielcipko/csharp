using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DateTime startTime;
        DateTime stopTime;
        public bool start = true;
        public bool stop = false;
        double realnyCas;

        public MainWindow()
        {
            InitializeComponent();
            Start.IsEnabled = false;
            Stop.IsEnabled = true;
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            if (start = true)
            {
                startTime = DateTime.Now;
                ResultLabel.Content = "";
                Start.IsEnabled = false;
                Stop.IsEnabled = true;

            }
        }
        private void Stop_Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (stop = true)
            {
                TipBox.Text = "Sem napis svoj tip";
                stopTime = DateTime.Now;
                TimeSpan elapsed = stopTime - startTime;
                realnyCas = elapsed.TotalMilliseconds;
                realnyCas = Math.Round(realnyCas, 0);
                TipBox.IsEnabled = true;
                ResultLabel.Content = realnyCas.ToString() + " ms";
                Start.IsEnabled = true;
                Stop.IsEnabled = false;
            }
        }

        private void Check_Button_Click_2(object sender, RoutedEventArgs e)
        {

            string tipTxt = TipBox.Text;
            if (int.TryParse(tipTxt, out int tip))
            {
                ResultLabel.Content = ($"Tvoj tip je: {tipTxt}");
                double rozdiel = Math.Abs(realnyCas - tip);
                rozdiel = Math.Round(rozdiel, 0);
                ResultLabel.Content = "Tvoj tip bol o " + rozdiel.ToString() + " ms vedľa";
            }
            else
            {
                ResultLabel.Content = "Zadaj platny tip";
            }
        }

        private void TipBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}
