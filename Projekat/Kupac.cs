using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    [Serializable]
    class Kupac:Korisnik
    {
        private int id_kupca;
        private string ime, prezime;
        private string pol;
        private string br_tel;
        DateTime datum_rodj;

        public Kupac(int id_kupca, string ime, string prezime, string pol, string br_tel, DateTime datum_rodj,string korisnicko, string sifra) : base(korisnicko, sifra)
        {
            this.id_kupca = id_kupca;
            this.ime = ime;
            this.prezime = prezime;
            this.pol = pol;
            this.br_tel = br_tel;
            this.datum_rodj = datum_rodj;
        }

        public int Id_kupca { get => id_kupca; set => id_kupca = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Pol { get => pol; set => pol = value; }
        public DateTime Datum_rodj { get => datum_rodj; set => datum_rodj = value; }
        public string Br_tel { get => br_tel; set => br_tel = value; }

        public override string ToString()
        {
            return "ID kupca: " + id_kupca + " " + " ,ime: " + ime + " ,prezime" + prezime + " ,datum rodjenja: " + datum_rodj + " ,pol" + pol;
        }
    }
}
