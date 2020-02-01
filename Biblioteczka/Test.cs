using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteczka
{
    class Test
    {

        public class Rootobject
        {
            public Gatunek Gatunek { get; set; }
        }

        public class Gatunek
        {
            public Fantastyka[] Fantastyka { get; set; }
            public Horror[] Horror { get; set; }
            public Biografia[] Biografia { get; set; }
            public Dramat[] Dramat { get; set; }
        }

        public class Fantastyka
        {
            public string Tytul { get; set; }
            public string Autor { get; set; }
            public int RokWydania { get; set; }
            public string Okladka { get; set; }
            public int Dostepnosc { get; set; }
            public string Opis { get; set; }
        }

        public class Horror
        {
            public string Tytul { get; set; }
            public string Autor { get; set; }
            public int RokWydania { get; set; }
            public string Okladka { get; set; }
            public int Dostepnosc { get; set; }
            public string Opis { get; set; }
        }

        public class Biografia
        {
            public string Tytul { get; set; }
            public string Autor { get; set; }
            public int RokWydania { get; set; }
            public string Okladka { get; set; }
            public int Dostepnosc { get; set; }
            public string Opis { get; set; }
        }

        public class Dramat
        {
            public string Tytul { get; set; }
            public string Autor { get; set; }
            public int RokWydania { get; set; }
            public string Okladka { get; set; }
            public int Dostepnosc { get; set; }
            public string Opis { get; set; }
        }

    }
}
