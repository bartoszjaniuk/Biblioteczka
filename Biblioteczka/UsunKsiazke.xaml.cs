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
    /// Logika interakcji dla klasy UsunKsiazke.xaml
    /// </summary>
    public partial class UsunKsiazke : Window
    {
        ObservableCollection<string> nazwyKsiazek = new ObservableCollection<string>();

        Ksiazki ksiazki = new Ksiazki();


        public UsunKsiazke()
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
                        nazwyKsiazek.Add(ksiazka.Tytul);
                    }
                    listaKsiazekDoUsuniecia.ItemsSource = nazwyKsiazek;

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void usunKsiazkeButton_Click(object sender, RoutedEventArgs e)
        {

            string selectedValue = listaKsiazekDoUsuniecia.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedValue))
            {
                //remove from ObservableCollection:
                string bookToDelete = nazwyKsiazek.FirstOrDefault(x => x == selectedValue);
                if (bookToDelete != null)
                    nazwyKsiazek.Remove(bookToDelete);

                //remove from books
                for (int i = ksiazki.Ksiazka.Count - 1; i >= 0; i--)
                {
                    if (ksiazki.Ksiazka[i].Tytul == selectedValue)
                    {
                        ksiazki.Ksiazka.RemoveAt(i);
                    }
                }
            }

                var filePath = "biblioteczka.json";
            var jsonData = JsonConvert.SerializeObject(ksiazki, Formatting.Indented);
            File.WriteAllText(filePath,jsonData);
            

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
