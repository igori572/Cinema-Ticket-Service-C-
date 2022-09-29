using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class FormaRezervacija : Form
    {
        FormKupac fk;

        public delegate void prosledi_id(int podaci);
        prosledi_id poziv;

        FileStream fs;
        BinaryFormatter bf;

        string putanjaFilm = "film.bin";
        List<Film> film;

        string putanjaProj = "projekcija.bin";
        List<Projekcija> projekcija;

        string putanjaSala = "sala.bin";
        List<Sala> sala;

        string putanjaKupca = "registracija.bin";
        List<Kupac> kupci;

        string putanjaRez = "rezervacija.bin";
        List<Rezervacije> rezervacije;
        int cena,kupac_id,uk_cena,id_proj,id_sale;

        public FormaRezervacija()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        private void FormaRezervacija_Load(object sender, EventArgs e)
        {
            if (File.Exists(putanjaFilm))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaFilm);
                film = bf.Deserialize(fs) as List<Film>;
                fs.Flush();
                fs.Close();

                foreach (Film f in film)
                {
                    cbNaziv.Items.Add(f.Naziv);
                }
            }
            else
                film = new List<Film>();

            if (File.Exists(putanjaRez))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaRez);
                rezervacije = bf.Deserialize(fs) as List<Rezervacije>;
                fs.Flush();
                fs.Close();
            }
            else
                rezervacije = new List<Rezervacije>();

            if (File.Exists(putanjaSala))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaSala);
                sala = bf.Deserialize(fs) as List<Sala>;
                fs.Flush();
                fs.Close();

                foreach (Sala s in sala)
                {
                    cbSala.Items.Add(s.Broj_sale);
                }
            }
            else
                sala = new List<Sala>();

            if (File.Exists(putanjaKupca))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaKupca);
                kupci = bf.Deserialize(fs) as List<Kupac>;
                fs.Flush();
                fs.Close();
            }
            else
                kupci = new List<Kupac>();

            if (File.Exists(putanjaProj))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaProj);
                projekcija = bf.Deserialize(fs) as List<Projekcija>;
                fs.Flush();
                fs.Close();
            }
            else
                projekcija = new List<Projekcija>();

        }

        public void ispisi_id(int podaci)
        {
            kupac_id = podaci;
            lblIDKupca.Text = kupac_id.ToString();
        }
        private void datePocetni_ValueChanged(object sender, EventArgs e)
        {
            if (datePocetni.Value < DateTime.Today)
            {
                MessageBox.Show("Ne možeš izabrati ovaj datum.");
                datePocetni.ResetText();
            }
        }
        
        private void dateKrajnji_ValueChanged(object sender, EventArgs e)
        {
            if(dateKrajnji.Value<datePocetni.Value)
            {
                MessageBox.Show("Krajnji datum mora biti veći od početnog.");
                dateKrajnji.Value = datePocetni.Value;
            }
        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            int id_rezervacije;
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Izaberite broj mesta koliko želite.");
                return;
            }
                
            else
            {
                if (rezervacije.Count == 0)
                    id_rezervacije = 1;
                else
                {
                    int x = rezervacije.Max(t => t.Id_rezervacija);
                    id_rezervacije = x + 1;
                }
                rezervacije.Add(new Rezervacije(id_rezervacije,id_proj,kupac_id,(int)numericUpDown1.Value,uk_cena));

                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaRez);
                bf.Serialize(fs, rezervacije);
                fs.Flush();
                fs.Close();
                MessageBox.Show("Uspešno ste izvršili rezervaciju.");
            }
            

            foreach (Projekcija p in projekcija)
            {
                if(p.Id_projekcija==id_proj)
                {
                    foreach (Sala s in sala)
                    {
                        if(s.Id_sale== id_sale)
                        {
                            s.Uk_sedista -= (int)numericUpDown1.Value;
                            p.Sala.Uk_sedista = s.Uk_sedista;
                            
                        }
                    }
                }
            }

            bf = new BinaryFormatter();
            fs = File.OpenWrite(putanjaSala);
            bf.Serialize(fs, sala);
            fs.Flush();
            fs.Close();

            bf = new BinaryFormatter();
            fs = File.OpenWrite(putanjaProj);
            bf.Serialize(fs, projekcija);
            fs.Flush();
            fs.Close();

            listBox1.Items.Clear();
            this.Close();
            fk = new FormKupac();
            this.poziv = new prosledi_id(fk.ispisi_id);
            poziv(kupac_id);
            fk.Show();



        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Projekcija p in projekcija)
            {
                if ((listBox1.SelectedItem as Projekcija).Id_projekcija == p.Id_projekcija)
                {
                    cena = p.Cena;
                    id_proj = p.Id_projekcija;
                    id_sale = p.Sala.Broj_sale;
                    if(p.Sala.Uk_sedista<(int)numericUpDown1.Value)
                    {
                        MessageBox.Show("Nema ovoliko dostupnih mesta.");
                        return;
                    }
                    else
                    {
                        uk_cena = cena * (int)numericUpDown1.Value;
                        textBox1.Text = uk_cena.ToString();
                    }
                }

            }
           
        }

        private void btnPrikazi_Click(object sender, EventArgs e)
        {

            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaProj);
            projekcija = bf.Deserialize(fs) as List<Projekcija>;
            fs.Flush();
            fs.Close();

            listBox1.Items.Clear();
            foreach (Projekcija p in projekcija)
            {
                if ((p.Datum_proj>datePocetni.Value && p.Datum_proj<dateKrajnji.Value) && 
                    (p.Sala.Broj_sale.ToString()==cbSala.Text || cbSala.SelectedItem == null) && 
                    (p.Film.Naziv==cbNaziv.Text || cbNaziv.SelectedItem == null))
                {
                    listBox1.Items.Add(p);
                    
                }
            }
        }
    }
}
