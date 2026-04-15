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

using System;
using System.Collections.Generic;
using System.Windows;

namespace RND_clothing_e_shop
{
    public partial class ShopPage : Window
    {
        
        public static List<Produkt> KosikList = new List<Produkt>();

        public ShopPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            KosikWindow kosikWindow = new KosikWindow();
            kosikWindow.Show();
            this.Close();
        }

        private void AddToCart(string name, decimal price)
        {
            
            Produkt novyProdukt = new Produkt
            {
                Name = name,
                Price = price
            };

           
            KosikList.Add(novyProdukt);

            MessageBox.Show($"{name} bol pridaný do košíka!");
        }

       
        private void AddWhiteShirt_Click(object sender, RoutedEventArgs e) => AddToCart("Biele Tričko", 19.99m);
        private void AddBlackHoodie_Click(object sender, RoutedEventArgs e) => AddToCart("Čierna Mikina", 39.99m);
        private void AddJeans_Click(object sender, RoutedEventArgs e) => AddToCart("Rifle", 49.99m);
        private void AddJacket_Click(object sender, RoutedEventArgs e) => AddToCart("Bunda", 89.99m);

        
        private void AllCategory_Click(object sender, RoutedEventArgs e) { }
        private void TrickaCategory_Click(object sender, RoutedEventArgs e) { }
        private void MikinyCategory_Click(object sender, RoutedEventArgs e) { }
        private void NohaviceCategory_Click(object sender, RoutedEventArgs e) { }
        private void BundyCategory_Click(object sender, RoutedEventArgs e) { }
        private void TopankyCategory_Click(object sender, RoutedEventArgs e) { }
        private void DoplnkyCategory_Click(object sender, RoutedEventArgs e) { }
    }
}