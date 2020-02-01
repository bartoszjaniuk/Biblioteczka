using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy BazaKsiazekWyszukiwanie.xaml
    /// </summary>
    public partial class BazaKsiazekWyszukiwanie : Window
    {
        ObservableCollection<Ksiazka> bibliotekaKsiazek = new ObservableCollection<Ksiazka>();

        Ksiazki ksiazki = new Ksiazki();
  
        public BazaKsiazekWyszukiwanie()
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
                        bibliotekaKsiazek.Add(ksiazka);
                    }
                    ListaKsiazek.ItemsSource = bibliotekaKsiazek;
                    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(bibliotekaKsiazek);
                    view.Filter = Filter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





       // Here are my "Filter Methods"

        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Ksiazka).Tytul.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                || ((item as Ksiazka).Autor.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                || ((item as Ksiazka).Gatunek.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                || ((item as Ksiazka).RokWydania.ToString().IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                || ((item as Ksiazka).Dostepnosc.ToString().IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void tytulColHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = (sender as GridViewColumnHeader);
            string columnNameToSort = header.Content.ToString();
            CollectionView view =  (CollectionView)CollectionViewSource.GetDefaultView(ListaKsiazek.ItemsSource);
            ListSortDirection howToSort = ListSortDirection.Ascending;
            

            if(view.SortDescriptions.Any())
            {
                SortDescription item =  view.SortDescriptions.ElementAt(0);

                if (columnNameToSort == item.PropertyName.ToString())
                    if (item.Direction == ListSortDirection.Ascending)
                        howToSort = ListSortDirection.Descending;
                else
                        howToSort = ListSortDirection.Ascending;
                    
            }
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(columnNameToSort, howToSort)); 
        }


        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListaKsiazek.ItemsSource).Refresh();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
