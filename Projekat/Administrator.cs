using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    [Serializable]
    class Administrator:Korisnik
    {
        private int id_adm;
        private string ime, prezime;

        public Administrator(int idAdm, string ime, string prezime,string korisnicko,string sifra):base(korisnicko,sifra)
        {
            this.id_adm = idAdm;
            this.ime = ime;
            this.prezime = prezime;
        }

        public int Id_adm { get => id_adm; set => id_adm = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }

        public override string ToString()
        {
            return "ID: " + id_adm + " " + ",ime: " + ime + " " + ",prezime: " + prezime;
        }
    }
}
