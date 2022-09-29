using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class Form1 : Form
    {
        public delegate void prosledi(int kupac_id);
        prosledi prosledi_id;

        List<Kupac> kupci;
        List<Administrator> administratori;
        List<Korisnik> korisnici;

        BinaryFormatter bf;
        FileStream fs;

        Admin frmAdmin;
        FormKupac frmKupac;

        string putanjakupac = "registracija.bin";

        string putanjaadmin = "admin.bin";

        string putanjakorisnik = "korisnici.bin";
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnRegistracija_Click(object sender, EventArgs e)
        {
            int id_kupca,proveraI,proveraP;
            DateTime t = DateTime.Now;
            int TD = t.Year - dateTimePicker1.Value.Year;
            //Regex brojPattern = new Regex(@"\[0-9]{3}\-+[0-9]{3}\-+[0-9]{4}");
            string pol="";
            string br_tel = txtBroj.Text;
            if (rbMuski.Checked)
                pol = "M";
            else if (rbZenski.Checked)
                pol = "Z";

            if(txtKorisnicko.Text.Trim().Length!=0)
            {
                foreach (Korisnik k in korisnici)
                {
                    if(k.korisnicko==txtKorisnicko.Text)
                    {
                        MessageBox.Show("Ovo korisničko ime već postoji.");
                        return;
                    }
                }
            }

            if (txtIme.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli ime");
            else if (int.TryParse(txtIme.Text, out proveraI))
                MessageBox.Show("Ime ne može biti broj.");
            else if (txtPreyime.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli prezime");
            else if (int.TryParse(txtPreyime.Text, out proveraP))
                MessageBox.Show("Prezime ne moze biti broj");
            else if (txtKorisnicko.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli korisnicko ime");
            else if (txtSifra.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli šifru");
            else if (txtSifra.Text.Trim().Length < 5)
                MessageBox.Show("Šifra mora sadržati minimum 5 karaktera");
            else if (TD < 12)
                MessageBox.Show("Morate imati preko 12 godina ");
            else if (txtBroj.Text.Trim().Length == 0)
                MessageBox.Show("Unesite broj telefona.");
            else if (txtBroj.Text.Trim().Length < 9)
                MessageBox.Show("Broj mora sadržati minimum 9 cifara.");
            else if (!rbMuski.Checked && !rbZenski.Checked)
                MessageBox.Show("Nije čekiran pol");
            else
            {
                foreach (char c in br_tel)
                {
                    if (c < '0' || c > '9')
                    {
                        MessageBox.Show("Polje za broj telefona sadrži samo brojeve.");
                        return;
                    }
                }

                if (kupci.Count == 0)
                    id_kupca = 1;
                else
                {
                    int x = kupci.Max(tx => tx.Id_kupca);
                    id_kupca = x + 1;
                }
                kupci.Add(new Kupac(id_kupca, txtIme.Text, txtPreyime.Text, pol, txtBroj.Text, dateTimePicker1.Value, txtKorisnicko.Text, txtSifra.Text));
                korisnici.Add(new Korisnik(txtKorisnicko.Text, txtSifra.Text));
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjakupac);
                bf.Serialize(fs, kupci);
                fs.Flush();
                fs.Close();

                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjakorisnik);
                bf.Serialize(fs, korisnici);
                fs.Flush();
                fs.Close();
                MessageBox.Show("Uspešno ste se registrovali.");

                txtIme.Clear();
                txtPreyime.Clear();
                txtBroj.Clear();
                txtSifra.Clear();
                txtKorisnicko.Clear();
                dateTimePicker1.ResetText();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (File.Exists(putanjakupac))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjakupac);
                kupci = bf.Deserialize(fs) as List<Kupac>;
                fs.Flush();
                fs.Close();
            }
            else
            {
                kupci = new List<Kupac>();
            }

            if (File.Exists(putanjaadmin))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaadmin);
                administratori = bf.Deserialize(fs) as List<Administrator>;
                fs.Flush();
                fs.Close();
            }
            else
            {
                administratori = new List<Administrator>();
            }
            if (File.Exists(putanjakorisnik))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjakorisnik);
                korisnici = bf.Deserialize(fs) as List<Korisnik>;
                fs.Flush();
                fs.Close();
            }
            else
            {
                korisnici = new List<Korisnik>();
            }
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            int log = 0;
            //if (txtKorisnickoP.Text=="Igor" && txtSifraP.Text=="Kingor")
            //{
            //    frmAdmin = new Admin();
            //    frmAdmin.Show();
            //    txtKorisnickoP.Clear();
            //    txtSifraP.Clear();
            //    log++;
            //}

            if (File.Exists(putanjaadmin) && administratori.Count == 0)
                MessageBox.Show("Ne postoje administratori");
            else
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaadmin);
                administratori = bf.Deserialize(fs) as List<Administrator>;
                fs.Flush();
                fs.Close();

                foreach (Administrator adm in administratori)
                {
                    if(txtKorisnickoP.Text==adm.korisnicko && txtSifraP.Text==adm.sifra)
                    {
                        frmAdmin = new Admin();
                        frmAdmin.Show();
                        txtKorisnickoP.Clear();
                        txtSifraP.Clear();
                        log++;
                    }
                }
            }
            if (File.Exists(putanjakupac) && kupci.Count == 0)
                MessageBox.Show("Nema registrovanih");

            
            fs = File.OpenRead(putanjakupac);
            kupci = bf.Deserialize(fs) as List<Kupac>;
            fs.Close();
            
            if(kupci.Count>0)
            {
                foreach (Kupac k in kupci)
                {
                    if (txtKorisnickoP.Text == k.korisnicko && txtSifraP.Text == k.sifra)
                    {
                        frmKupac = new FormKupac();
                        prosledi_id = new prosledi(frmKupac.ispisi_id);
                        prosledi_id(k.Id_kupca);
                        
                        frmKupac.Show();
                        log++;
                        txtKorisnickoP.Clear();
                        txtSifraP.Clear();

                       
                    }

                }
                if (log == 0) MessageBox.Show("Niste pravilno uneli korisničko ime ili šifru.");

                log = 0;
                    
            }

        }
    }
}
