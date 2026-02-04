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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int cislo;
        public Random r;
        public bool koniecHry;
        public int pocetPokusov;
        public int MaxPocetPokusov = 10;
        public int poslednaVzdialenost;
        private int aktualnavzdialenost;


        public MainWindow()
        {
            InitializeComponent();
            r = new Random();
            cislo = r.Next(0, 101);
            Cheat.Text = cislo.ToString();
            koniecHry = false;
            pocetPokusov = 0;
            poslednaVzdialenost = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (koniecHry) return;
            string text = Zadanie.Text;
            int zadaneCislo = int.Parse(text);
            int aktualnavzdialenost = Math.Abs(cislo - zadaneCislo);
            if (zadaneCislo == cislo)
            {
                koniecHry = true;
                Info.Text = "Uhadol si!";
            }
            else
            {
                if (pocetPokusov == 1)

                    if (pocetPokusov == MaxPocetPokusov)
                    {
                        koniecHry = true;
                        Info.Text = "Koniec hry. Cislo bolo: " + cislo;
                        return;

                    }
                if (pocetPokusov == 0 && zadaneCislo > cislo)
                {
                    Info.Text = "Nizsie";

                }
                if (pocetPokusov == 0 && zadaneCislo < cislo)
                {
                    Info.Text = "Vyssie";
                }

                poslednaVzdialenost = aktualnavzdialenost;
                return;
            }
            if (aktualnavzdialenost > poslednaVzdialenost)
            {
                Info.Text = "Chladnejsie.";
            }
            if (aktualnavzdialenost < poslednaVzdialenost)
            {
                Info.Text = "Teplejsie.";
            }
            if (aktualnavzdialenost == poslednaVzdialenost)
            {
                Info.Text = "Uhadol si.";
            }
            poslednaVzdialenost = aktualnavzdialenost;
        }

        private void Button_Click_reset(object sender, RoutedEventArgs e)
        {
            Info.Text = "Hra sa restartovala";

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
