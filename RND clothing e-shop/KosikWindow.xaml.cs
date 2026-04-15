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

namespace RND_clothing_e_shop
{
    /// <summary>
    /// Interaction logic for KosikWindow.xaml
    /// </summary>
    public partial class KosikWindow : Window
    {
        public KosikWindow()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e) 
        {
            ShopPage shopPage = new ShopPage();
            shopPage.Show();

            this.Close();
        }
        private void MinusButton_Click(object sender, RoutedEventArgs e) { }
        private void PlusButton_Click(object sender, RoutedEventArgs e) { }
        private void RemoveItem_Click(object sender, RoutedEventArgs e) { }
        private void OrderButton_Click(object sender, RoutedEventArgs e) { }
        private void ContinueShoppingButton_Click(object sender, RoutedEventArgs e) { }
    }
}
