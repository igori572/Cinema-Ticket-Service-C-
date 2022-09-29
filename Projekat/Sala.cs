using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    [Serializable]
    class Sala
    {
        private int id_sale,broj_sale,uk_sedista;

        public Sala(int id_sale, int broj_sale, int uk_sedista)
        {
            this.id_sale = id_sale;
            this.broj_sale = broj_sale;
            this.uk_sedista = uk_sedista;
        }

        public int Id_sale { get => id_sale; set => id_sale = value; }
        public int Broj_sale { get => broj_sale; set => broj_sale = value; }
        public int Uk_sedista { get => uk_sedista; set => uk_sedista = value; }

        public override string ToString()
        {
            return "ID sale: " + id_sale + ",broj sale: " + broj_sale + ", ukupno sedista: " + uk_sedista;
        }
    }
}
