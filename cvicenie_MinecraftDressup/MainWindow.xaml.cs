using System.ComponentModel;
using System.IO;
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

namespace cvicenie_MinecraftDressup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ImagePath { get; set; } = "C:\\Users\\cipkod25\\Source\\Repos\\csharp\\cvicenie_MinecraftDressup\\images\\minecraft_armour_sheet_by_dragonshadow3_d8ebr67-414w-2x.png";
        List<ArmorPart> Armor_Helm = new List<ArmorPart>();
        List<ArmorPart> ArmorPart_Body = new List<ArmorPart>();
        List<ArmorPart> ArmorPart_Pants = new List<ArmorPart>();
        List<ArmorPart> ArmorPart_Leg = new List<ArmorPart>();

        public ArmorPart Head { get; set; }
        public ArmorPart Body { get; set; }
        public ArmorPart Pants { get; set; }
        public ArmorPart Leg { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Armor_Helm.Add(new ArmorPart("Plesinka", 0, EArmorType.None, EArmorPartName.Head, 28, 29, 100, 90));
            Armor_Helm.Add(new ArmorPart("Helma bronzova", 1, EArmorType.Bronze, EArmorPartName.Head, 28, 29, 100, 90));
            Armor_Helm.Add(new ArmorPart("Helma retiazkova", 2, EArmorType.Chain, EArmorPartName.Head, 177, 29, 100, 90));
            Armor_Helm.Add(new ArmorPart("Helma zelezna", 5, EArmorType.Iron, EArmorPartName.Head, 338, 29, 100, 90));
            Armor_Helm.Add(new ArmorPart("Helma zlata", 10, EArmorType.Gold, EArmorPartName.Head, 505, 29, 100, 90));
            Armor_Helm.Add(new ArmorPart("Helma diamantova", 20, EArmorType.Diamond, EArmorPartName.Head, 659, 29, 100, 90));
            Combox_HelmPicker.ItemsSource = Armor_Helm;

            ArmorPart_Body.Add(new ArmorPart("Hola hrud", 0, EArmorType.None, EArmorPartName.Head, 0, 0, 0, 0));
            ArmorPart_Body.Add(new ArmorPart("Body bronzove", 5, EArmorType.Bronze, EArmorPartName.Head, 7, 136, 139, 130));
            ArmorPart_Body.Add(new ArmorPart("Body retiazkove", 10, EArmorType.Chain, EArmorPartName.Head, 159, 136, 139, 130));
            ArmorPart_Body.Add(new ArmorPart("Body zelezne", 15, EArmorType.Iron, EArmorPartName.Head, 321, 136, 139, 130));
            ArmorPart_Body.Add(new ArmorPart("Body zlate", 30, EArmorType.Gold, EArmorPartName.Head, 486, 136, 139, 130));
            ArmorPart_Body.Add(new ArmorPart("Body diamantove", 50, EArmorType.Diamond, EArmorPartName.Head, 639, 136, 139, 130));
            Combox_BodyPicker.ItemsSource = ArmorPart_Body;

            ArmorPart_Pants.Add(new ArmorPart("Trenky", 0, EArmorType.None, EArmorPartName.Pants, 0, 0, 0, 0));
            ArmorPart_Pants.Add(new ArmorPart("Nohavice bronzove", 2, EArmorType.Bronze, EArmorPartName.Pants, 26, 279, 100, 131));
            ArmorPart_Pants.Add(new ArmorPart("Nohavice retiazkove", 4, EArmorType.Chain, EArmorPartName.Pants, 179, 279, 100, 131));
            ArmorPart_Pants.Add(new ArmorPart("Nohavice zelezne", 8, EArmorType.Iron, EArmorPartName.Pants, 339, 279, 100, 131));
            ArmorPart_Pants.Add(new ArmorPart("Nohavice zlate", 15, EArmorType.Gold, EArmorPartName.Pants, 506, 279, 100, 131));
            ArmorPart_Pants.Add(new ArmorPart("Nohavice diamantove", 22, EArmorType.Diamond, EArmorPartName.Pants, 657, 279, 100, 131));
            Combox_PantsPicker.ItemsSource = ArmorPart_Pants;

            ArmorPart_Leg.Add(new ArmorPart("Sandale", 0, EArmorType.None, EArmorPartName.Leg, 0, 0, 0, 0));
            ArmorPart_Leg.Add(new ArmorPart("Topanky bronzove", 2, EArmorType.Bronze, EArmorPartName.Leg, 2, 425, 140, 100));
            ArmorPart_Leg.Add(new ArmorPart("Topanky retiazkove", 4, EArmorType.Chain, EArmorPartName.Leg, 159, 425, 140, 100));
            ArmorPart_Leg.Add(new ArmorPart("Topanky zelezne", 8, EArmorType.Iron, EArmorPartName.Leg, 319, 425, 140, 100));
            ArmorPart_Leg.Add(new ArmorPart("Topanky zlate", 15, EArmorType.Gold, EArmorPartName.Leg, 484, 425, 140, 100));
            ArmorPart_Leg.Add(new ArmorPart("Topanky diamantove", 22, EArmorType.Diamond, EArmorPartName.Leg, 636, 425, 140, 100));
            Combox_LegPicker.ItemsSource = ArmorPart_Leg;
        }
        private void UpdateLabels()
        {
            var playerSet = new List<ArmorPart>();

            if (Head != null)
                playerSet.Add(Head);
            if (Body != null)
                playerSet.Add(Body);
            if (Pants != null)
                playerSet.Add(Pants);
            if (Leg != null)
                playerSet.Add(Leg);

            //PRepocitavanie a zapousivabnie do lablu
            double total = playerSet.Sum(ArmorPart => ArmorPart.ArmorPower);

            // Zápis do labelu
            Label_ActualArmor.Content = total.ToString();
        }

        private void Combox_HelmPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArmorPart armorPartH = Combox_HelmPicker.SelectedItem as ArmorPart;
            Head = armorPartH;

            if (armorPartH.ArmorType != EArmorType.None) 
            {
               var bitmap = new BitmapImage();
               bitmap.BeginInit();
               bitmap.UriSource = new Uri(ImagePath, UriKind.Absolute);
               bitmap.CacheOption = BitmapCacheOption.OnLoad; // aby sa súbor neu lockol
               bitmap.EndInit();
               bitmap.Freeze();
               var cropped = new CroppedBitmap(bitmap, new Int32Rect(armorPartH.Xleft, armorPartH.YTop, armorPartH.Width, armorPartH.Height));
               cropped.Freeze();
               Image_HelmetPlaceHolder.Source = cropped;
               Image_HelmetPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {

                Image_HelmetPlaceHolder.Visibility = Visibility.Hidden;

            }
            UpdateLabels();
        }

        private void Combox_BodyPlaceHolder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArmorPart armorPartB = Combox_BodyPicker.SelectedItem as ArmorPart;
            if (armorPartB.ArmorType != EArmorType.None)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ImagePath, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad; // aby sa súbor neu lockol
                bitmap.EndInit();
                bitmap.Freeze();
                var cropped = new CroppedBitmap(bitmap, new Int32Rect(armorPartB.Xleft, armorPartB.YTop, armorPartB.Width, armorPartB.Height));
                cropped.Freeze();
                Image_BodyPlaceHolder.Source = cropped;
                Image_BodyPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {

                Image_HelmetPlaceHolder.Visibility = Visibility.Hidden;

            }
            UpdateLabels();
        }

        private void Combox_PantsPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArmorPart armorPartP = Combox_PantsPicker.SelectedItem as ArmorPart;
            if (armorPartP.ArmorType != EArmorType.None)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ImagePath, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad; // aby sa súbor neu lockol
                bitmap.EndInit();
                bitmap.Freeze();
                var cropped = new CroppedBitmap(bitmap, new Int32Rect(armorPartP.Xleft, armorPartP.YTop, armorPartP.Width, armorPartP.Height));
                cropped.Freeze();
                Image_PantsPlaceHolder.Source = cropped;
                Image_PantsPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {

                Image_PantsPlaceHolder.Visibility = Visibility.Hidden;

            }
            UpdateLabels();
        }

        private void Combox_LegPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArmorPart armorPartL = Combox_LegPicker.SelectedItem as ArmorPart;
            if (armorPartL.ArmorType != EArmorType.None)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ImagePath, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad; // aby sa súbor neu lockol
                bitmap.EndInit();
                bitmap.Freeze();
                var cropped = new CroppedBitmap(bitmap, new Int32Rect(armorPartL.Xleft, armorPartL.YTop, armorPartL.Width, armorPartL.Height));
                cropped.Freeze();
                Image_LegPlaceHolder.Source = cropped;
                Image_LegPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {

                Image_LegPlaceHolder.Visibility = Visibility.Hidden;

            }
            UpdateLabels();

        }
    }
}