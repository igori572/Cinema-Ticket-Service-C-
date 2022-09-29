using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    [Serializable]
    class Rezervacije
    {
        private int id_rezervacija,id_projekcija, id_kupca, br_mesta, uk_cena;

        public Rezervacije(int id_rezervacija,int id_projekcija, int id_kupca, int br_mesta, int uk_cena)
        {
            this.id_rezervacija = id_rezervacija;
            this.id_projekcija = id_projekcija;
            this.id_kupca = id_kupca;
            this.br_mesta = br_mesta;
            this.uk_cena = uk_cena;
        }

        public int Id_projekcija { get => id_projekcija; set => id_projekcija = value; }
        public int Id_kupca { get => id_kupca; set => id_kupca = value; }
        public int Br_mesta { get => br_mesta; set => br_mesta = value; }
        public int Uk_cena { get => uk_cena; set => uk_cena = value; }
        public int Id_rezervacija { get => id_rezervacija; set => id_rezervacija = value; }

        public override string ToString()
        {
            return "ID rezervacije: "+id_rezervacija+",ID_projekcije: " + id_projekcija + ",ID_kupca: " + id_kupca + ",broj mesta: " + br_mesta + ",ukupna cena: " + uk_cena;
        }
    }
}
