using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    [Serializable]
    class Film
    {
        private int id_filma;
        private string naziv, zanr;
        private int granica_god, duzina;

        public Film(int id_filma, string naziv, string zanr, int granica_god, int duzina)
        {
            this.id_filma = id_filma;
            this.naziv = naziv;
            this.zanr = zanr;
            this.granica_god = granica_god;
            this.duzina = duzina;
        }

        public int Id_filma { get => id_filma; set => id_filma = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Zanr { get => zanr; set => zanr = value; }
        public int Granica_god { get => granica_god; set => granica_god = value; }
        public int Duzina { get => duzina; set => duzina = value; }

        public override string ToString()
        {
            return "ID filma: " + id_filma + ",naziv filma: " + naziv + ",zanr:" + zanr + ",duzina: " + duzina + ",granica godina: " + granica_god;
        }
    }
}
