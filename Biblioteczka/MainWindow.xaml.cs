using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biblioteczka
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> nazwyKsiazekIAutorow = new List<string>();

        Ksiazki ksiazki = new Ksiazki();
        

        public MainWindow()
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
                        nazwyKsiazekIAutorow.Add(ksiazka.Tytul);
                        nazwyKsiazekIAutorow.Add(ksiazka.Autor);
                    }
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajKsiazke dodajKsiazke = new DodajKsiazke();
            dodajKsiazke.ShowDialog();
        }

        private void buttonBazaKsiazek_Click(object sender, RoutedEventArgs e)
        {
            BazaKsiazek bazaKsiazek = new BazaKsiazek();
            bazaKsiazek.ShowDialog();
        }

        private void deleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            UsunKsiazke usunKsiazke = new UsunKsiazke();
            usunKsiazke.ShowDialog();
        }

        private void deleteBookButton_Click_1(object sender, RoutedEventArgs e)
        {
            UsunKsiazke usunKsiazke = new UsunKsiazke();
            usunKsiazke.ShowDialog();
        }
      
      
        
        private void bazaKsiazekButton_Click(object sender, RoutedEventArgs e)
        {
            BazaKsiazekWyszukiwanie bazaKsiazekWyszukiwanie = new BazaKsiazekWyszukiwanie();
            bazaKsiazekWyszukiwanie.ShowDialog();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
