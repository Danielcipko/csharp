using System.Security.RightsManagement;
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
using cvicenie_pokemonov;
using cvicenie_pokemonov.Cvicenie_Pokemon;

namespace Cvicenie_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
         
        public MainWindow()
        {
            InitializeComponent();

            Hero hero = new Hero(50, 100, 10);
            Enemy enemy = new Enemy(200, 1);


            Window_Fight fight_window = new Window_Fight(hero,enemy);
            fight_window.Show();
        }
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string myTextBoxValue = TextBox_MyValue.Text;

            Window_Fight window = new Window_Fight(myTextBoxValue);
            window.ShowDialog();


        }*/
    }
}