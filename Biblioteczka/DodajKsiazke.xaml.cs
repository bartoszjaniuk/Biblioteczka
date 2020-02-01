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
using System.Windows.Shapes;
using Microsoft.Win32;


namespace Biblioteczka
{
    /// <summary>
    /// Logika interakcji dla klasy DodajKsiazke.xaml
    /// </summary>
    /// 
    
    public partial class DodajKsiazke : Window
    {
        public DodajKsiazke()
        {
            InitializeComponent();

        }

        private void buttonDodajKsiazke_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var filePath = "biblioteczka.json";
                var jsonData = File.ReadAllText(filePath);
                Ksiazki ksiazkiSerializacja = JsonConvert.DeserializeObject<Ksiazki>(jsonData);
                Ksiazka nowaKsiazka = new Ksiazka();
                nowaKsiazka.Tytul = titleTextBox.Text;
                nowaKsiazka.Autor = authorTextBox.Text;
                nowaKsiazka.Gatunek = gatunekTextBox.Text;
                nowaKsiazka.RokWydania = int.Parse(rokWydaniaTextBox.Text);
                nowaKsiazka.Okladka = okladkaTextBox.Text;
                nowaKsiazka.Dostepnosc = int.Parse(dostepnoscTextBox.Text);
                nowaKsiazka.Opis = opisTextBox.Text;
                ksiazkiSerializacja.Ksiazka.Add(nowaKsiazka);
                jsonData = JsonConvert.SerializeObject(ksiazkiSerializacja, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
                DataContext = nowaKsiazka;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\Asus\source\Studia\Projekt -Library\Biblioteczka\okladki";
            openFileDialog.Filter = "Obrazy(*.jpg;)|*.jpg";
            openFileDialog.DefaultExt = ".jpg";


            if (openFileDialog.ShowDialog() == true)
            {
                var temp = openFileDialog.FileName;
                //string flag = @"okladki\";
                //var replacment = temp.Substring(temp.IndexOf(flag), temp.Length - temp.IndexOf(flag));
                //var replacement2 = replacment.Replace(@"\","/");
                okladkaTextBox.Text = temp;
            } 

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
