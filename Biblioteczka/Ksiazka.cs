using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteczka
{
    public class Ksiazka
    {
        // 1) ATRYBUT TYTUŁ //
        private string _TytułKsiazki = "Tytuł";
        public string Tytul
        {
            get
            {
                return _TytułKsiazki;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    _TytułKsiazki = value;
                }
               
                else
                    throw new Exception("Błąd danych! Proszę podać tytuł książki !");
            }
        }


        // 1) KONIEC ATRYBUT TYTUŁ //


        // 2) ATRYBUT AUTOR //
        private string _autor = "Autor";
        public string Autor
        {
            get
            {
                return _autor;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    _autor = value;
                }

                else
                    throw new Exception("Błąd danych! Proszę podać autora książki !");
            }
        }

        // 2) KONIEC ATRYBUT AUTOR //

        // 3) ATRYBUT GATUNEK //
        private string _gatunek = "Gatunek";
        public string Gatunek
        {
            get
            {
                return _gatunek;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    _gatunek = value;
                }

                else
                    throw new Exception("Błąd danych! Proszę podać gatunek książki !");
            }
        }
        // 3) KONIEC ATRYBUT GATUNEK //

        // 4) ATRYBUT ROK WYDANIA //
        private int _rokWydania = 0;
        public int RokWydania
        {
            get
            {
                return _rokWydania;
            }
            set
            {
                if ((value > 0) && (value <= 2019))
                {
                    _rokWydania = value;
                }
                else
                    throw new Exception("Musisz podać roku z przedziału 0 - 2019");
            }
        }
        // 4) KONIEC ATRYBUT ROK WYDANIA //

        // 5) ATRYBUT OKLADKA //
        private string _okladka = "Okladka";
        public string Okladka
        {
            get
            {
                return _okladka;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    _okladka = value;
                }
                else
                    throw new Exception("Proszę wskazać scieżkę do obrazka");
            }
        }
        // 5) KONIEC ATRYBUT OKLADKA //

        // 6) ATRYBUT DOSTEPNOSC //
        public int Dostepnosc { get; set; }
        // 6) KONIEC ATRYBUT DOSTEPNOSC //

        // 7) ATRYBUT OPIS KSIAZKI //
        private string _opis = "Opis";
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    _opis = value;
                }
                else
                    throw new Exception("Proszę podać opis ksiązki.");
            }
        }

        // 7)  KONIEC ATRYBUT OPIS KSIAZKI //
    }

    public class Ksiazki
    {
        public List<Ksiazka> Ksiazka { get; set; }

        // Konstruktor
        public Ksiazki()
        {
            Ksiazka = new List<Ksiazka>();
        }
    }
}
