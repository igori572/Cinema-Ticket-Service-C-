using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    [Serializable]
    class Projekcija
    {
        private int id_projekcija;
        private DateTime datum_proj, vreme_pocetka;
        Sala sala;
        private int cena;
        Film film;

        public Projekcija(int id_projekcija, DateTime datum_proj, DateTime vreme_pocetka, Sala sala, int cena, Film film)
        {
            this.id_projekcija = id_projekcija;
            this.datum_proj = datum_proj;
            this.vreme_pocetka = vreme_pocetka;
            this.sala = sala;
            this.cena = cena;
            this.film = film;
        }

        public int Id_projekcija { get => id_projekcija; set => id_projekcija = value; }
        public DateTime Datum_proj { get => datum_proj; set => datum_proj = value; }
        public DateTime Vreme_pocetka { get => vreme_pocetka; set => vreme_pocetka = value; }
        public int Cena { get => cena; set => cena = value; }
        internal Sala Sala { get => sala; set => sala = value; }
        internal Film Film { get => film; set => film = value; }

        public override string ToString()
        {
            return "ID projekcije: " + id_projekcija +",Cena karte: "+cena+ ",Datum i vreme: " + vreme_pocetka +
                ", Sala:" + sala.Broj_sale + "Broj dostupnih mesta: " + sala.Uk_sedista+ ",naziv filma: " + film.Naziv;
        }
    }
}
