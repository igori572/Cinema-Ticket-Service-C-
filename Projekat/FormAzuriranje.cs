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
    public partial class FormAzuriranje : Form
    {
        int id_kupac,cena,uk_cena,staro,id_sale;
        public delegate void podaci(int podaci);
        podaci poziv;

        FormKupac fk;

        FileStream fs;
        BinaryFormatter bf;

        string putanjaRez = "rezervacija.bin";
        List<Rezervacije> rezervacije;

        string putanjaKupca = "registracija.bin";
        List<Kupac> kupci;

        string putanjaProj = "projekcija.bin";
        List<Projekcija> projekcija;

        string putanjaSala = "sala.bin";
        List<Sala> sala;

        string putanjaFilm = "film.bin";
        List<Film> film;
        public FormAzuriranje()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public void ispisi_id(int podaci)
        {
            id_kupac = podaci;
            //lblID.Text = podaci.ToString();

        }
        private void FormAzuriranje_Load(object sender, EventArgs e)
        {
            
            if (File.Exists(putanjaFilm))
            {

                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaFilm);
                film = bf.Deserialize(fs) as List<Film>;
                fs.Flush();
                fs.Close();
                
            }
            else
            {
                film = new List<Film>();
            }

            if (File.Exists(putanjaSala))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaSala);
                sala = bf.Deserialize(fs) as List<Sala>;
                fs.Flush();
                fs.Close();
                
            }
            else
            {
                sala = new List<Sala>();
            }

            if (File.Exists(putanjaProj))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaProj);
                projekcija = bf.Deserialize(fs) as List<Projekcija>;
                fs.Flush();
                fs.Close();

                foreach (Projekcija p in projekcija)
                {
                    cmbIDProj.Items.Add(p.Id_projekcija);
                }
                
            }
            else
            {
                projekcija = new List<Projekcija>();
            }

            if (File.Exists(putanjaRez))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaRez);
                rezervacije = bf.Deserialize(fs) as List<Rezervacije>;
                fs.Flush();
                fs.Close();

                foreach (Rezervacije r in rezervacije)
                {
                    if(r.Id_kupca==id_kupac)
                    {
                        cmbRez.Items.Add(r.Id_rezervacija);
                    }
                }
            }
            else
                rezervacije = new List<Rezervacije>();

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
        }

        private void cmbIDProj_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Projekcija p in projekcija)
            {
                if (p.Id_projekcija.ToString() == cmbIDProj.Text)
                {
                    txtFilm.Text = p.Film.Naziv;
                    txtBrSale.Text = p.Sala.Broj_sale.ToString();
                    txtSlobMesta.Text = p.Sala.Uk_sedista.ToString();
                    txtDatum.Text = p.Vreme_pocetka.ToString();
                    id_sale = p.Sala.Id_sale;
               
                }
            }
        }

        private void btnAzuriraj_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbRez.Text))
                MessageBox.Show("Označite ID rezervacije koju želite da izmenite.");
            //else if (txtIDProj.Text.Trim().Length == 0 && int.Parse(txtIDProj.Text) == 0)
              //  MessageBox.Show("Unesite broj veći od 0");
            else
            {


                foreach (Rezervacije r in rezervacije)
                {
                    if (r.Id_rezervacija.ToString() == cmbRez.Text)
                    {
                        //r.Id_projekcija = int.Parse(txtIDProj.Text);
                        r.Id_projekcija = int.Parse(cmbIDProj.Text);
                        r.Id_kupca = id_kupac;
                        r.Id_rezervacija = int.Parse(cmbRez.Text);
                        r.Uk_cena = uk_cena;
                        r.Br_mesta = (int)numericUpDown1.Value;
                    }
                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaRez);
                bf.Serialize(fs, rezervacije);
                fs.Flush();
                fs.Close();
               // int id_proj = int.Parse(txtIDProj.Text);
                int id_proj = int.Parse(cmbIDProj.Text);

                foreach (Projekcija p in projekcija)
                {
                    if (p.Id_projekcija == id_proj)
                    {
                        foreach (Sala s in sala)
                        {
                            if (s.Id_sale == id_sale)
                            {
                                if (numericUpDown1.Value == 0)
                                {
                                    MessageBox.Show("Morate uneti broj karata za rezervaciju.");
                                    return;
                                }
                                else if (staro > (int)numericUpDown1.Value)
                                {
                                    p.Sala.Uk_sedista += (staro - (int)numericUpDown1.Value);
                                    s.Uk_sedista = p.Sala.Uk_sedista;

                                }
                                else if (staro < (int)numericUpDown1.Value)
                                {
                                    p.Sala.Uk_sedista -= ((int)numericUpDown1.Value - staro);
                                    s.Uk_sedista = p.Sala.Uk_sedista;
                                }

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
                MessageBox.Show("Uspešno ažurirana rezervacija.");

                cmbRez.ResetText();
                txtBrSale.Clear();
                txtDatum.Clear();
                txtFilm.Clear();
                txtSlobMesta.Clear();
                txtUkupno.Clear();
                numericUpDown1.Value=0;

                this.Close();
                fk = new FormKupac();
                this.poziv = new podaci(fk.ispisi_id);
                poziv(id_kupac);
                fk.Show();
                

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaRez);
            rezervacije = bf.Deserialize(fs) as List<Rezervacije>;
            fs.Flush();
            fs.Close();

            
            foreach (Rezervacije r in rezervacije)
            {
                if (cmbRez.Text == r.Id_rezervacija.ToString())
                {
                    cmbIDProj.Text = r.Id_projekcija.ToString();
                    numericUpDown1.Value = r.Br_mesta;
                    txtUkupno.Text = r.Uk_cena.ToString();
                    staro = r.Br_mesta;
                }
                
            }
        }



        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            foreach (Projekcija p in projekcija)
            {
                if (cmbIDProj.Text == p.Id_projekcija.ToString())
                {
                    cena = p.Cena;

                    if (p.Sala.Uk_sedista < (int)numericUpDown1.Value)
                    {
                        MessageBox.Show("Nema ovoliko dostupnih mesta.");
                        return;
                    }
                    else
                    {
                        uk_cena = cena * (int)numericUpDown1.Value;
                        txtUkupno.Text = uk_cena.ToString();
                    }

                }

            }
        }
    }
}
