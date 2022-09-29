using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    
    [Serializable]
    
    class Korisnik
    {
        public string sifra;
        public string korisnicko;
        

        public Korisnik(string korisnicko, string sifra)
        {
            this.korisnicko = korisnicko;
            this.sifra = sifra;
        }

        protected string Korisnicko { get => korisnicko; set => korisnicko = value; }
        protected string Sifra { get => sifra; set => sifra = value; }

        //private void upisi(object o)
        //{
        //    FileStream fs = new FileStream("korisnik.bin", FileMode.OpenOrCreate);
        //    BinaryFormatter bf = new BinaryFormatter();
        //    bf.Serialize(fs, o);
        //    fs.Flush();
        //    fs.Close();
        //}

        //private void procitaj(object o)
        //{
        //    FileStream fs = new FileStream("korisnik.bin", FileMode.Open);
        //}
        public override string ToString()
        {
            return "Korisnicko ime: " + korisnicko + " " + ",sifra: " + sifra;
        }
    }
}
