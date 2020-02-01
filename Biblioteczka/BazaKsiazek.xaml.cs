using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Biblioteczka
{
    /// <summary>
    /// Logika interakcji dla klasy BazaKsiazek.xaml
    /// </summary>
    public partial class BazaKsiazek : Window
    {
        List<string> nazwyKsiazek = new List<string>();
        
        Ksiazki ksiazki = new Ksiazki();


        public BazaKsiazek()
        {
            InitializeComponent();

            

            try
            {
                using (StreamReader r = File.OpenText("biblioteczka.json"))
                {
                    string sciezka = r.ReadToEnd();
                    ksiazki = JsonConvert.DeserializeObject<Ksiazki>(sciezka);
                    foreach (var ksiazka in ksiazki.Ksiazka)
                    {
                        if (!nazwyKsiazek.Contains(ksiazka.Gatunek)) nazwyKsiazek.Add(ksiazka.Gatunek);
                    }
                    ListaKsiazekListBox.ItemsSource = nazwyKsiazek;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ListaKsiazekListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

             ListaKsiazekPanel.Visibility = Visibility.Visible;
            ObservableCollection<string> ksiazkiWedlugGatunku = new ObservableCollection<string>();

            // nowa lista pusta petla przez wszystkie ksiazki, sprawdzasz czy ksiazka aktualna jest z gatunku ktorego wybrales, jesli tak to dodaj do nowej listy
            foreach (var ksiazka in ksiazki.Ksiazka)
            {
                if (ksiazka.Gatunek.Equals(ListaKsiazekListBox.SelectedValue))
                {
                    ksiazkiWedlugGatunku.Add(ksiazka.Tytul);
                }
                
            }
 
            ListaKsiazek.ItemsSource = ksiazkiWedlugGatunku;
        }

        private void ListaKsiazek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            PanelSrodkowyPrawaStrona.Visibility = Visibility.Visible;



            foreach (var ksiazka in ksiazki.Ksiazka)
            {
                if (ksiazka.Tytul.Equals(ListaKsiazek.SelectedValue))
                {
                    tytulKsiazkiLabel.Content = ksiazka.Tytul;
                    autorKsiazkiLabel.Content = ksiazka.Autor;
                    gatunekKsiazkiLabel.Content = ksiazka.Gatunek;
                    rokWydaniaKsiazkiLabel.Content = ksiazka.RokWydania;
                    dostepnoscKsiazkiLabel.Content = ksiazka.Dostepnosc;
                    opisKsiazkiTextBlock.Text = ksiazka.Opis;
                    
                    BitmapImage image = new BitmapImage(new Uri(ksiazka.Okladka, UriKind.Absolute));
                    okladkaKsiazkiIMG.Source = image;



                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
