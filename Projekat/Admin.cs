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
    public partial class Admin : Form
    {
        int id_sale2;
        int cena_k, ukupna_cena, staro;
        List<Administrator> administratori;
        string putanjaadmin = "admin.bin";

        List<Korisnik> korisnici;
        string putanjakorisnik = "korisnici.bin";

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

        
        public Admin()
        {
            InitializeComponent();


        }
        private void Admin_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            if (File.Exists(putanjaadmin))
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaadmin);
                administratori = bf.Deserialize(fs) as List<Administrator>;
                fs.Flush();
                fs.Close();
                foreach (Administrator adm in administratori)
                {
                    cmbAdministrator.Items.Add(adm);
                }
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
            if (File.Exists(putanjaFilm))
            {

                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaFilm);
                film = bf.Deserialize(fs) as List<Film>;
                fs.Flush();
                fs.Close();
                foreach (Film fi in film)
                {
                    cbNazivFilma.Items.Add(fi);
                    cmbIDfilm.Items.Add(fi.Id_filma);
                }
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
                foreach (Sala s in sala)
                {
                    cbBrSale.Items.Add(s);
                    cmbIDsala.Items.Add(s.Id_sale);
                }
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
                    cmbIDproj.Items.Add(p.Id_projekcija);
                    cmbIDRezProj.Items.Add(p.Id_projekcija);
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
                foreach (Kupac k in kupci)
                {
                    cbKupci.Items.Add(k);
                    cmbKupac.Items.Add(k);
                }
            }
            else
                kupci = new List<Kupac>();
        }
        //int id_filmova=0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            int duzina, godine,id_filma,proveraT,proveraZ;

            if (txtNazivFilma.Text.Trim().Length != 0)
            {
                foreach (Film f in film)
                {
                    if (f.Naziv == txtNazivFilma.Text)
                    {
                        MessageBox.Show("Film već postoji!");
                        return;
                    }

                }

            }
            if (txtNazivFilma.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli naziv filma.");
            else if (int.TryParse(txtNazivFilma.Text, out proveraT))
                MessageBox.Show("Uneli ste broj za naziv filma");
            else if (txtZanr.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli naziv žanra.");
            else if (int.TryParse(txtZanr.Text, out proveraZ))
                MessageBox.Show("Uneli ste broj za naziv žanra.");
            else if (!int.TryParse(txtDuzina.Text, out duzina))
                MessageBox.Show("Unesite broj minuta za dužinu filma.");
            else if (!int.TryParse(txtGodine.Text, out godine))
                MessageBox.Show("Unesite minimalan uzrast za ovaj film.");
            else
            {
                if (film.Count == 0)
                    id_filma = 1;
                else
                {
                    int x = film.Max(t => t.Id_filma);
                    id_filma = x + 1;
                }


                //id_filma = film.Count + 1;
                film.Add(new Film(id_filma, txtNazivFilma.Text.Trim(), txtZanr.Text.Trim(), godine, duzina));
                cmbIDfilm.Items.Clear();
                cbNazivFilma.Items.Clear();
                foreach (Film fi in film)
                {
                    cbNazivFilma.Items.Add(fi);
                    cmbIDfilm.Items.Add(fi.Id_filma);
                }

                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaFilm);
                bf.Serialize(fs, film);
                fs.Flush();
                fs.Close();




                MessageBox.Show("Uspešno ste dodali film.");
                txtDuzina.Clear();
                txtGodine.Clear();
                cmbIDfilm.ResetText();
                txtNazivFilma.Clear();
                txtZanr.Clear();
                tabPage2.Refresh();
                this.Refresh();

            }

        }

        private void btnDodajSalu_Click(object sender, EventArgs e)
        {
            int br_sale, uk_sed;
            int id_sale;

            if (txtBrojSale.Text.Trim().Length == 0)
                MessageBox.Show("Unesite broj sale");
            else if (!int.TryParse(txtBrojSale.Text, out br_sale))
                MessageBox.Show("Morate uneti broj za salu");
            else if (txtUkSedista.Text.Trim().Length == 0)
                MessageBox.Show("Unesite broj sedišta za salu.");
            else if (!int.TryParse(txtUkSedista.Text, out uk_sed))
                MessageBox.Show("Morate uneti broj za sedišta");
            else if (br_sale > 0)
            {
                foreach (Sala s in sala)
                {
                    if (s.Broj_sale == br_sale)
                        MessageBox.Show("Ovaj broj sale već postoji.");
                }
                if (sala.Count == 0)
                    id_sale = 1;
                else
                {
                    int x = sala.Max(t => t.Id_sale);
                    id_sale = x + 1;
                }
                sala.Add(new Sala(id_sale, br_sale, uk_sed));

                cbBrSale.Items.Clear();
                cmbIDsala.Items.Clear();
                foreach (Sala s in sala)
                {
                    cbBrSale.Items.Add(s);
                    cmbIDsala.Items.Add(s.Id_sale);
                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaSala);
                bf.Serialize(fs, sala);
                fs.Flush();
                fs.Close();

                txtBrojSale.Clear();
                cmbIDsala.ResetText();
                txtUkSedista.Clear();

                MessageBox.Show("Uspešno ste dodali salu.");


            }

        }



        private void btnDodajProj_Click(object sender, EventArgs e)
        {
            int cena_karte;
            int id_proj;

            if (cbBrSale.SelectedItem == null)
                MessageBox.Show("Niste izabrali salu.");
            else if (txtCenaProj.Text.Trim().Length == 0)
                MessageBox.Show("Unesite cenu karte.");
            else if (!int.TryParse(txtCenaProj.Text, out cena_karte))
                MessageBox.Show("Morate uneti brojeve za cenu karte.");
            else if (cbNazivFilma.SelectedItem == null)
                MessageBox.Show("Niste izabrali naziv filma.");
            else
            {
                if (projekcija.Count == 0)
                    id_proj = 1;
                else
                {
                    int x = projekcija.Max(t => t.Id_projekcija);
                    id_proj = x + 1;
                }
                projekcija.Add(new Projekcija(id_proj, dateProj.Value, dateTimePicker1.Value, (Sala)cbBrSale.SelectedItem, cena_karte, (Film)cbNazivFilma.SelectedItem));
                cmbIDproj.Items.Clear();
                foreach (Projekcija p in projekcija)
                {
                    cmbIDproj.Items.Add(p.Id_projekcija);
                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaProj);
                bf.Serialize(fs, projekcija);
                fs.Flush();
                fs.Close();

                MessageBox.Show("Uspešno ste dodali projekciju.");

                txtCenaProj.Clear();
                cbBrSale.ResetText();
                cbNazivFilma.ResetText();
                cmbIDproj.ResetText();

            }

        }

        private void btnDodajRez_Click(object sender, EventArgs e)
        {

        }

        private void cbKupci_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Rezervacije r in rezervacije)
            {
                if ((cbKupci.SelectedItem as Kupac).Id_kupca == r.Id_kupca)
                    listBox1.Items.Add(r);
            }
        }

        private void cmbIDfilm_SelectedIndexChanged(object sender, EventArgs e)
        {

            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaFilm);
            film = bf.Deserialize(fs) as List<Film>;
            fs.Flush();
            fs.Close();
            List<Film> f = new List<Film>();
            f = film;


            foreach (Film fil in f)
            {
                if (cmbIDfilm.Text == fil.Id_filma.ToString())
                {
                    txtNazivFilma.Text = fil.Naziv;
                    txtZanr.Text = fil.Zanr;
                    txtDuzina.Text = fil.Duzina.ToString();
                    txtGodine.Text = fil.Granica_god.ToString();
                }
            }



        }

        private void cmbIDproj_SelectedIndexChanged(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaProj);
            projekcija = bf.Deserialize(fs) as List<Projekcija>;
            fs.Flush();
            fs.Close();
            List<Projekcija> p = new List<Projekcija>();
            p = projekcija;


            foreach (Projekcija proj in p)
            {
                if (cmbIDproj.Text == proj.Id_projekcija.ToString())
                {
                    dateProj.Value = proj.Datum_proj;
                    dateTimePicker1.Value = proj.Vreme_pocetka;
                    txtCenaProj.Text = proj.Cena.ToString();
                    cbNazivFilma.Text = "ID filma: " + proj.Film.Id_filma + ",naziv filma: " + proj.Film.Naziv + ",zanr:" + proj.Film.Zanr + ",duzina: " + proj.Film.Duzina + ",granica godina: " + proj.Film.Granica_god;
                    cbBrSale.Text = "ID sale: " + proj.Sala.Id_sale + ",broj sale: " + proj.Sala.Broj_sale + ", ukupno sedista: " + proj.Sala.Uk_sedista;

                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Rezervacije r in rezervacije)
            {
                if((listBox1.SelectedItem as Rezervacije).Id_rezervacija==r.Id_rezervacija)
                {
                    cmbIDRezProj.Text = r.Id_projekcija.ToString();
                    staro = r.Br_mesta;
                    numericUpDown1.Value = r.Br_mesta;
                    
                }
            }
        }

        private void btnIzmeniFIlm_Click(object sender, EventArgs e)
        {
            int duzina, godine, id_filma,proveraT,proveraZ;
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaFilm);
            film = bf.Deserialize(fs) as List<Film>;
            fs.Flush();
            fs.Close();
            

            //foreach (Film f in film)
            //{
            //    if (txtNazivFilma.Text == f.Naziv)
            //        MessageBox.Show("Ovaj naziv filma već postoji");
            //}
            if (string.IsNullOrEmpty(cmbIDfilm.Text))
                MessageBox.Show("Selektujte ID filma koji želite da izmenite.");

            else if (txtNazivFilma.Text.Trim().Length == 0)
                MessageBox.Show("Unesi novi naziv filma");
            else if (int.TryParse(txtNazivFilma.Text, out proveraT))
                MessageBox.Show("Uneli ste broj za naziv filma");
            else if (txtZanr.Text.Trim().Length == 0)
                MessageBox.Show("Unesi novi naziv žanra.");
            else if (int.TryParse(txtZanr.Text, out proveraZ))
                MessageBox.Show("Uneli ste broj za naziv žanra.");
            else if (!int.TryParse(txtDuzina.Text, out duzina))
                MessageBox.Show("Unesite broj minuta za dužinu filma");
            else if (!int.TryParse(txtGodine.Text, out godine))
                MessageBox.Show("Unesite broj za novu granicu godina.");
            else
            {

                //Film f = new Film(id_filma, txtNazivFilma.Text.Trim(), txtZanr.Text.Trim(), godine, duzina);
                id_filma = int.Parse(cmbIDfilm.Text);
                foreach (Film f in film)
                {
                    if (f.Id_filma == id_filma)
                    {
                        f.Granica_god = godine;
                        f.Naziv = txtNazivFilma.Text;
                        f.Zanr = txtZanr.Text;
                        f.Duzina = duzina;
                    }
                }
                cmbIDfilm.Items.Clear();
                cbNazivFilma.Items.Clear();
                foreach (Film fi in film)
                {
                    cbNazivFilma.Items.Add(fi);
                    cmbIDfilm.Items.Add(fi.Id_filma);
                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaFilm);
                bf.Serialize(fs, film);
                fs.Flush();
                fs.Close();
                MessageBox.Show("Uspešno izmenjeno.");
                txtDuzina.Clear();
                txtGodine.Clear();
                cmbIDfilm.ResetText();
                txtNazivFilma.Clear();
                txtZanr.Clear();




            }
        }

        private void cmbIDsala_SelectedIndexChanged(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaSala);
            sala = bf.Deserialize(fs) as List<Sala>;
            fs.Flush();
            fs.Close();
            List<Sala> s = new List<Sala>();
            s = sala;


            foreach (Sala sale in sala)
            {
                if (cmbIDsala.Text == sale.Id_sale.ToString())
                {

                    txtBrojSale.Text = sale.Broj_sale.ToString();
                    txtUkSedista.Text = sale.Uk_sedista.ToString();
                }
            }
        }

        private void btnObrisiFilm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbIDfilm.Text))
                MessageBox.Show("Selektujte ID filma koji želite da obrišete.");

            else if (File.Exists(putanjaFilm) && film.Count == 0)
                MessageBox.Show("Ne postoje filmovi.");
            else
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaFilm);
                film = bf.Deserialize(fs) as List<Film>;
                fs.Flush();
                fs.Close();
                if (cmbIDfilm.Text == null)
                    MessageBox.Show("Selektujte ID filma koji želite da obrišete.");
                else
                {
                    for (int i = 0; i < film.Count; i++)
                    {

                        if (film[i].Id_filma.ToString() == cmbIDfilm.Text)
                        {
                            film.RemoveAt(i);
                            i--;
                            MessageBox.Show("Film je obrisan");
                        }

                    }
                }
                cmbIDfilm.Items.Clear();
                cbNazivFilma.Items.Clear();
                foreach (Film fi in film)
                {
                    cbNazivFilma.Items.Add(fi);
                    cmbIDfilm.Items.Add(fi.Id_filma);
                }


                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaFilm);
                bf.Serialize(fs, film);
                fs.Flush();
                fs.Close();

                txtDuzina.Clear();
                txtGodine.Clear();
                cmbIDfilm.ResetText();
                txtNazivFilma.Clear();
                txtZanr.Clear();
            }


        }

        private void btnIzmeniSalu_Click(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaSala);
            sala = bf.Deserialize(fs) as List<Sala>;
            fs.Flush();
            fs.Close();

            int br_sale, br_sed, id_sale ;
            //foreach (Sala s in sala)
            //{
            //    if (s.Broj_sale.ToString() == txtBrojSale.Text)
            //        MessageBox.Show("Već postoji ova sala");
            //}
            if (string.IsNullOrEmpty(cmbIDsala.Text))
                MessageBox.Show("Selektuje ID sale koju želite da izmenite.");
            else if (!int.TryParse(txtBrojSale.Text, out br_sale))
                MessageBox.Show("Unesite broj za izmenu broja sale.");
            else if (!int.TryParse(txtUkSedista.Text, out br_sed))
                MessageBox.Show("Unesite broj za izmenu ukupnog broja sedišta");

            else
            {
                id_sale = int.Parse(cmbIDsala.Text);
                foreach (Sala s in sala)
                {
                    if (s.Id_sale == id_sale)
                    {
                        s.Broj_sale = br_sale;
                        s.Uk_sedista = br_sed;
                    }
                }
                cbBrSale.Items.Clear();
                cmbIDsala.Items.Clear();
                foreach (Sala s in sala)
                {
                    cbBrSale.Items.Add(s);
                    cmbIDsala.Items.Add(s.Id_sale);
                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaSala);
                bf.Serialize(fs, sala);
                fs.Flush();
                fs.Close();
                MessageBox.Show("Uspešno izmenjeno");
                txtBrojSale.Clear();
                cmbIDsala.ResetText();
                txtUkSedista.Clear();

            }
        }

        private void btnObrisiSalu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbIDsala.Text))
                MessageBox.Show("Selektuje ID sale koju želite da obrišete.");
            else if (File.Exists(putanjaSala) && sala.Count == 0)
                MessageBox.Show("Nema unetih sala.");
            else
            {
                bf = new BinaryFormatter();
                fs = File.OpenRead(putanjaSala);
                sala = bf.Deserialize(fs) as List<Sala>;
                fs.Flush();
                fs.Close();
                if (cmbIDsala.Text == null)
                    MessageBox.Show("Selektuj ID sale");
                else
                {
                    for (int i = 0; i < sala.Count; i++)
                    {

                        if (sala[i].Id_sale.ToString() == cmbIDsala.Text)
                        {
                            sala.RemoveAt(i);
                            i--;
                            MessageBox.Show("Uspešno uklonjeno");
                        }
                    }
                }
                cbBrSale.Items.Clear();
                cmbIDsala.Items.Clear();
                foreach (Sala s in sala)
                {
                    cbBrSale.Items.Add(s);
                    cmbIDsala.Items.Add(s.Id_sale);
                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaSala);
                bf.Serialize(fs, sala);
                fs.Flush();
                fs.Close();
                txtBrojSale.Clear();
                cmbIDsala.ResetText();
                txtUkSedista.Clear();

            }
        }



        private void btnIzmeniProj_Click(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaProj);
            projekcija = bf.Deserialize(fs) as List<Projekcija>;
            fs.Flush();
            fs.Close();
            int cena;
            int id_proj;
            if (string.IsNullOrEmpty(cmbIDproj.Text))
                MessageBox.Show("Selektujte ID projekcije koju želite da izmenite.");
            else if (!int.TryParse(txtCenaProj.Text, out cena))
                MessageBox.Show("Unesite broj za novu cenu karte");
            else
            {
                id_proj= int.Parse(cmbIDproj.Text); 

                foreach (Projekcija proj in projekcija)
                {
                    if (proj.Id_projekcija == id_proj)
                    {
                        proj.Vreme_pocetka = dateTimePicker1.Value;
                        proj.Datum_proj = dateProj.Value;
                        proj.Cena = cena;
                        proj.Sala = (Sala)cbBrSale.SelectedItem;
                        proj.Film = (Film)cbNazivFilma.SelectedItem;
                    }
                }
                cmbIDproj.Items.Clear();
                foreach (Projekcija p in projekcija)
                {
                    cmbIDproj.Items.Add(p.Id_projekcija);
                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaProj);
                bf.Serialize(fs, projekcija);
                fs.Flush();
                fs.Close();
                MessageBox.Show("Uspešno izmenjeno.");
                txtCenaProj.Clear();
                cbBrSale.ResetText();
                cbNazivFilma.ResetText();
                cmbIDproj.ResetText();
            }
        }

        private void btnObrisiProj_Click(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaProj);
            projekcija = bf.Deserialize(fs) as List<Projekcija>;
            fs.Flush();
            fs.Close();

            if (string.IsNullOrEmpty(cmbIDproj.Text))
                MessageBox.Show("Selektujte ID projekcije koju želite da obrišete.");
            else
            {
                for (int i = 0; i < projekcija.Count; i++)
                {

                    if (projekcija[i].Id_projekcija.ToString() == cmbIDproj.Text)
                    {
                        projekcija.RemoveAt(i);
                        i--;
                        MessageBox.Show("Projekcija je obrisana");
                    }

                }
            }
            cmbIDproj.Items.Clear();
            foreach (Projekcija p in projekcija)
            {
                cmbIDproj.Items.Add(p.Id_projekcija);
            }
            bf = new BinaryFormatter();
            fs = File.OpenWrite(putanjaProj);
            bf.Serialize(fs, projekcija);
            fs.Flush();
            fs.Close();

            txtCenaProj.Clear();
            cbBrSale.ResetText();
            cbNazivFilma.ResetText();
            cmbIDproj.ResetText();
        }


        int br = 0;
        private void button7_Click(object sender, EventArgs e)
        {

            groupBox2.Show();
            br++;
            if (br == 2)
            {
                groupBox2.Hide();
                br = 0;
            }
        }
        int br2 = 0;
        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            br2++;
            if (br2 == 2)
            {
                groupBox1.Hide();
                br2 = 0;
            }
        }

        private void cmbAdministrator_SelectedIndexChanged(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaadmin);
            administratori = bf.Deserialize(fs) as List<Administrator>;
            fs.Flush();
            fs.Close();
            List<Administrator> adm = new List<Administrator>();
            adm = administratori;


            foreach (Administrator admin in adm)
            {
                if ((cmbAdministrator.SelectedItem as Administrator).Id_adm == admin.Id_adm)
                {
                    txtImeAdm.Text = admin.Ime;
                    txtPrezimeAdm.Text = admin.Prezime;
                    txtKorisnickoAdm.Text = admin.korisnicko;
                    txtSifraAdm.Text = admin.sifra;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaadmin);
            administratori = bf.Deserialize(fs) as List<Administrator>;
            fs.Flush();
            fs.Close();

            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjakorisnik);
            korisnici = bf.Deserialize(fs) as List<Korisnik>;
            fs.Flush();
            fs.Close();

            int id_admina,proveraI,proveraP;

            if (txtKorisnickoAdm.Text.Trim().Length != 0)
            {
                foreach (Korisnik k in korisnici)
                {
                    if (k.korisnicko == txtKorisnickoAdm.Text)
                    {
                        MessageBox.Show("Ovo korisničko ime već postoji.");
                        return;
                    }
                }
            }

            if (txtImeAdm.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli ime administratora.");
            else if (int.TryParse(txtImeAdm.Text, out proveraI))
                MessageBox.Show("Ime ne može biti broj.");
            else if (txtPrezimeAdm.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli prezime administratora.");
            else if (int.TryParse(txtPrezimeAdm.Text, out proveraP))
                MessageBox.Show("Prezime ne može biti broj.");
            else if (txtKorisnickoAdm.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli korisničko ime za administratora");
            else if (txtSifraAdm.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli šifru za administratora.");
            else if (txtSifraAdm.Text.Trim().Length < 5)
                MessageBox.Show("Šifra mora sadržati minimum 5 karaktera.");
            else
            {

                if (administratori.Count == 0)
                    id_admina = 1;
                else
                {
                    int x = administratori.Max(t => t.Id_adm);
                    id_admina = x + 1;
                }
                administratori.Add(new Administrator(id_admina, txtImeAdm.Text, txtPrezimeAdm.Text, txtKorisnickoAdm.Text, txtSifraAdm.Text));
                korisnici.Add(new Korisnik(txtKorisnickoAdm.Text, txtSifraAdm.Text));

                cmbAdministrator.Items.Clear();
                foreach (Administrator adm in administratori)
                {
                    cmbAdministrator.Items.Add(adm);
                }

                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaadmin);
                bf.Serialize(fs, administratori);
                fs.Flush();
                fs.Close();

                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjakorisnik);
                bf.Serialize(fs, korisnici);
                fs.Flush();
                fs.Close();

                MessageBox.Show("Uspešno ste uneli administratora");
                txtImeAdm.Clear();
                txtPrezimeAdm.Clear();
                txtKorisnickoAdm.Clear();
                txtSifraAdm.Clear();
                cmbAdministrator.ResetText();

            }
        }

        private void cmbKupac_SelectedIndexChanged(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaKupca);
            kupci = bf.Deserialize(fs) as List<Kupac>;
            fs.Flush();
            fs.Close();
            List<Kupac> kupac = new List<Kupac>();
            kupac = kupci;


            foreach (Kupac kup in kupac)
            {
                if ((cmbKupac.SelectedItem as Kupac).Id_kupca == kup.Id_kupca)
                {
                    string pol = kup.Pol;
                    txtImeKupac.Text = kup.Ime;
                    txtPrezimeKupac.Text = kup.Prezime;
                    txtKorisnickoKupac.Text = kup.korisnicko;
                    txtSifraKupac.Text = kup.sifra;
                    dateKupac.Value = kup.Datum_rodj;
                    txtBroj.Text = kup.Br_tel.ToString();
                    if (pol == "M")
                        rbMuski.Checked = true;
                    else if (pol == "Z")
                        rbZenski.Checked = true;
                }
            }
        }

        private void btnObrisiAdministratora_Click(object sender, EventArgs e)
        {
            int id_adm;
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaadmin);
            administratori = bf.Deserialize(fs) as List<Administrator>;
            fs.Flush();
            fs.Close();

            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjakorisnik);
            korisnici = bf.Deserialize(fs) as List<Korisnik>;
            fs.Flush();
            fs.Close();


            if (string.IsNullOrEmpty(cmbAdministrator.Text))
                MessageBox.Show("Selektujte ID administratora kog želite da obrišete.");
            else
            {
                id_adm=(cmbAdministrator.SelectedItem as Administrator).Id_adm;
                for (int i = 0; i < administratori.Count; i++)
                {

                    if (administratori[i].Id_adm == id_adm)
                    {
                        administratori.RemoveAt(i);
                        i--;
                        MessageBox.Show("Administrator je obrisan");
                    }

                }
                for (int i = 0; i < korisnici.Count; i++)
                {
                    if (korisnici[i].korisnicko == (cmbAdministrator.SelectedItem as Administrator).korisnicko)
                    {
                        korisnici.RemoveAt(i);
                        i--;
                    }
                }
            }
            cmbAdministrator.Items.Clear();
            foreach (Administrator adm in administratori)
            {
                cmbAdministrator.Items.Add(adm);
            }
            bf = new BinaryFormatter();
            fs = File.OpenWrite(putanjaadmin);
            bf.Serialize(fs, administratori);
            fs.Flush();
            fs.Close();

            bf = new BinaryFormatter();
            fs = File.OpenWrite(putanjakorisnik);
            bf.Serialize(fs, korisnici);
            fs.Flush();
            fs.Close();

            txtImeAdm.Clear();
            txtPrezimeAdm.Clear();
            txtSifraAdm.Clear();
            txtKorisnickoAdm.Clear();
            cmbAdministrator.ResetText();
        }

        private void btnIzmeniAdministratora_Click(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaadmin);
            administratori = bf.Deserialize(fs) as List<Administrator>;
            fs.Flush();
            fs.Close();

            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjakorisnik);
            korisnici = bf.Deserialize(fs) as List<Korisnik>;
            fs.Flush();
            fs.Close();

            if (txtKorisnickoAdm.Text.Trim().Length != 0)
            {
                foreach (Korisnik k in korisnici)
                {
                    if (k.korisnicko == txtKorisnickoAdm.Text)
                    {
                        if (txtKorisnickoAdm.Text == (cmbAdministrator.SelectedItem as Korisnik).korisnicko)
                            continue;
                        else
                        {
                            MessageBox.Show("Ovo korisničko ime već postoji.");
                            return;
                        }
                        
                    }
                }
            }
            int proveraI, proveraP;
            if (txtImeAdm.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli ime administratora.");
            else if (int.TryParse(txtImeAdm.Text, out proveraI))
                MessageBox.Show("Ime ne može biti broj.");
            else if (txtPrezimeAdm.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli prezime administratora.");
            else if (int.TryParse(txtPrezimeAdm.Text, out proveraP))
                MessageBox.Show("Prezime ne može biti broj.");
            else if (txtKorisnickoAdm.Text.Trim().Length == 0)
                MessageBox.Show("Unesite novo korisničko ime administratora.");
            else if (txtSifraAdm.Text.Trim().Length == 0)
                MessageBox.Show("Unesite novu šifru administratora.");
            else if (txtSifraAdm.Text.Trim().Length < 5)
                MessageBox.Show("Šifra mora da sadrži minimum 5 karaktera.");
            else
            {

                foreach (Administrator adm in administratori)
                {
                    if (adm.Id_adm == (cmbAdministrator.SelectedItem as Administrator).Id_adm)
                    {
                        adm.Ime = txtImeAdm.Text;
                        adm.Prezime = txtPrezimeAdm.Text;
                        adm.korisnicko = txtKorisnickoAdm.Text;
                        adm.sifra = txtSifraAdm.Text;
                    }
                }

                foreach (Korisnik k in korisnici)
                {
                    if(k.korisnicko==(cmbAdministrator.SelectedItem as Administrator).korisnicko)
                    {
                        k.korisnicko = txtKorisnickoAdm.Text;
                        k.sifra = txtSifraAdm.Text;
                    }
                }

                cmbAdministrator.Items.Clear();
                foreach (Administrator adm in administratori)
                {
                    cmbAdministrator.Items.Add(adm);
                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaadmin);
                bf.Serialize(fs, administratori);
                fs.Flush();
                fs.Close();

                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjakorisnik);
                bf.Serialize(fs, korisnici);
                fs.Flush();
                fs.Close();

                MessageBox.Show("Uspešno izmenjeno.");
                txtImeAdm.Clear();
                txtPrezimeAdm.Clear();
                txtSifraAdm.Clear();
                txtKorisnickoAdm.Clear();
                cmbAdministrator.ResetText();

            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaKupca);
            kupci = bf.Deserialize(fs) as List<Kupac>;
            fs.Flush();
            fs.Close();

            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjakorisnik);
            korisnici = bf.Deserialize(fs) as List<Korisnik>;
            fs.Flush();
            fs.Close();

            
            int kupacid,proveraI,proveraP;
            DateTime t = DateTime.Now;
            int TD = t.Year - dateKupac.Value.Year;
            //Regex brojPattern = new Regex(@"\[0-9]{3}\-+[0-9]{3}\-+[0-9]{4}");
            string pol = "";
            string br_tel = txtBroj.Text;
            if (rbMuski.Checked)
                pol = "M";
            else if (rbZenski.Checked)
                pol = "Z";

            if (txtKorisnickoKupac.Text.Trim().Length != 0)
            {
                foreach (Korisnik k in korisnici)
                {
                    if (k.korisnicko == txtKorisnickoKupac.Text)
                    {
                        MessageBox.Show("Ovo korisničko ime već postoji.");
                        return;
                    }
                }
            }
            if (txtImeKupac.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli ime kupca.");
            else if (int.TryParse(txtImeKupac.Text, out proveraI))
                MessageBox.Show("Ime ne može biti broj.");
            else if (txtPrezimeKupac.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli prezime kupca.");
            else if (int.TryParse(txtPrezimeKupac.Text, out proveraP))
                MessageBox.Show("Prezime ne može biti broj.");
            else if (txtKorisnickoKupac.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli korisnicko ime kupca.");
            else if (txtSifraKupac.Text.Trim().Length == 0)
                MessageBox.Show("Niste uneli šifru kupca.");
            else if (txtSifraKupac.Text.Trim().Length < 5)
                MessageBox.Show("Šifra mora sadržati minimum 5 karaktera.");
            else if (TD < 12)
                MessageBox.Show("Kupac mora imati preko 12 godina. ");
            else if (txtBroj.Text.Trim().Length == 0)
                MessageBox.Show("Unesite broj telefona kupca.");
            else if (txtBroj.Text.Trim().Length < 9)
                MessageBox.Show("Broj mora sadržati minimum 9 cifara.");
            else if (!rbMuski.Checked && !rbZenski.Checked)
                MessageBox.Show("Nije čekiran pol kupca.");
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
                    kupacid = 1;
                else
                {
                    int x = kupci.Max(tx => tx.Id_kupca);
                    kupacid = x + 1;
                }
                kupci.Add(new Kupac(kupacid, txtImeKupac.Text, txtPrezimeKupac.Text, pol, br_tel, dateKupac.Value, txtKorisnickoKupac.Text, txtSifraKupac.Text));
                korisnici.Add(new Korisnik(txtKorisnickoKupac.Text, txtSifraKupac.Text));

                cmbKupac.Items.Clear();
                cbKupci.Items.Clear();
                foreach (Kupac k in kupci)
                {
                    cmbKupac.Items.Add(k);
                    cbKupci.Items.Add(k);

                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaKupca);
                bf.Serialize(fs, kupci);
                fs.Flush();
                fs.Close();

                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjakorisnik);
                bf.Serialize(fs, korisnici);
                fs.Flush();
                fs.Close();
                MessageBox.Show("Uspešno ste se registrovali.");

                txtImeKupac.Clear();
                txtPrezimeKupac.Clear();
                txtBroj.Clear();
                txtKorisnickoKupac.Clear();
                txtSifraKupac.Clear();
                cmbKupac.ResetText();

            }
        }

        private void btnIzmeniKupca_Click(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaKupca);
            kupci = bf.Deserialize(fs) as List<Kupac>;
            fs.Flush();
            fs.Close();

            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjakorisnik);
            korisnici = bf.Deserialize(fs) as List<Korisnik>;
            fs.Flush();
            fs.Close();

            DateTime t = DateTime.Now;
            int TD = t.Year - dateKupac.Value.Year;


            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaKupca);
            kupci = bf.Deserialize(fs) as List<Kupac>;
            fs.Flush();
            fs.Close();
            string br_tel = txtBroj.Text;
            string pol = "";
            if (rbMuski.Checked)
                pol = "M";
            else if (rbZenski.Checked)
                pol = "Z";

            if (txtKorisnickoKupac.Text.Trim().Length != 0)
            {
                foreach (Korisnik k in korisnici)
                {
                    
                    if (k.korisnicko == txtKorisnickoKupac.Text)
                    {
                        if (txtKorisnickoKupac.Text == (cmbKupac.SelectedItem as Korisnik).korisnicko)
                            continue;
                        else
                        {
                            MessageBox.Show("Ovo korisničko ime već postoji.");
                            return;
                        }
                        
                    }
                }
            }

            if (txtImeKupac.Text.Trim().Length == 0)
                MessageBox.Show("Unesite novo ime kupca.");
            else if (txtPrezimeKupac.Text.Trim().Length == 0)
                MessageBox.Show("Unesite novo prezime kupca.");
            else if (txtKorisnickoKupac.Text.Trim().Length == 0)
                MessageBox.Show("Unesite novo korisničko ime kupca.");
            else if (txtSifraKupac.Text.Trim().Length == 0)
                MessageBox.Show("Unesite novu šifru kupca.");
            else if (txtSifraKupac.Text.Trim().Length < 5)
                MessageBox.Show("Šifra mora da sadrži minimum 5 karaktera.");
            else if (TD < 12)
                MessageBox.Show("Kupac mora imati preko 12 godina. ");
            else if (txtBroj.Text.Trim().Length==0)
                MessageBox.Show("Unesite broj telefona kupca.");
            else if (txtBroj.Text.Trim().Length < 9)
                MessageBox.Show("Broj mora sadržati minimum 9 cifara.");
            else if (!rbMuski.Checked && !rbZenski.Checked)
                MessageBox.Show("Nije čekiran pol kupca.");
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
                foreach (Kupac k in kupci)
                {
                    if (k.Id_kupca == (cmbKupac.SelectedItem as Kupac).Id_kupca)
                    {
                        k.Ime = txtImeKupac.Text;
                        k.Prezime = txtPrezimeKupac.Text;
                        k.korisnicko = txtKorisnickoKupac.Text;
                        k.sifra = txtSifraKupac.Text;
                        k.Br_tel = txtBroj.Text;
                        k.Pol = pol;
                    }
                }

                foreach (Korisnik k in korisnici)
                {
                    if(k.korisnicko==(cmbKupac.SelectedItem as Korisnik).korisnicko)
                    {
                        k.korisnicko = txtKorisnickoKupac.Text;
                        k.sifra = txtSifraKupac.Text;
                    }
                }
                cmbKupac.Items.Clear();
                cbKupci.Items.Clear();
                foreach (Kupac k in kupci)
                {
                    cmbKupac.Items.Add(k);
                    cbKupci.Items.Add(k);

                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjakorisnik);
                bf.Serialize(fs, korisnici);
                fs.Flush();
                fs.Close();

                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaKupca);
                bf.Serialize(fs, kupci);
                fs.Flush();
                fs.Close();
                MessageBox.Show("Uspešno izmenjeno.");

                txtImeKupac.Clear();
                txtPrezimeKupac.Clear();
                txtBroj.Clear();
                txtKorisnickoKupac.Clear();
                txtSifraKupac.Clear();
                cmbKupac.ResetText();
            }
        }

        private void btnObrisiKupca_Click(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaKupca);
            kupci = bf.Deserialize(fs) as List<Kupac>;
            fs.Flush();
            fs.Close();

            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjakorisnik);
            korisnici = bf.Deserialize(fs) as List<Korisnik>;
            fs.Flush();
            fs.Close();

            int id_kupca;

            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaKupca);
            kupci = bf.Deserialize(fs) as List<Kupac>;
            fs.Flush();
            fs.Close();

            if (string.IsNullOrEmpty(cmbKupac.Text))
                MessageBox.Show("Selektujte kupca kog želite da obrišete.");
            else
            {
                id_kupca = (cmbKupac.SelectedItem as Kupac).Id_kupca;
                for (int i = 0; i < kupci.Count; i++)
                {

                    if (kupci[i].Id_kupca == id_kupca)
                    {
                        kupci.RemoveAt(i);
                        i--;
                        MessageBox.Show("Kupac je obrisan.");
                    }

                }
                for (int i = 0; i < korisnici.Count; i++)
                {
                    if(korisnici[i].korisnicko==(cmbKupac.SelectedItem as Korisnik).korisnicko)
                    {
                        korisnici.RemoveAt(i);
                        i--;
                    }
                }
                
            }
            cmbKupac.Items.Clear();
            foreach (Kupac k in kupci)
            {
                cmbKupac.Items.Add(k);
            }
            bf = new BinaryFormatter();
            fs = File.OpenWrite(putanjaKupca);
            bf.Serialize(fs, kupci);
            fs.Flush();
            fs.Close();

            bf = new BinaryFormatter();
            fs = File.OpenWrite(putanjakorisnik);
            bf.Serialize(fs, korisnici);
            fs.Flush();
            fs.Close();

            txtImeKupac.Clear();
            txtPrezimeKupac.Clear();
            txtBroj.Clear();
            txtKorisnickoKupac.Clear();
            txtSifraKupac.Clear();
            cmbKupac.ResetText();
        }

        private void cbBrSale_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtIDProj_TextChanged(object sender, EventArgs e)
        {
            foreach (Projekcija p in projekcija)
            {
                if (p.Id_projekcija.ToString() == cmbIDRezProj.Text)
                {
                    txtFilm.Text = p.Film.Naziv;
                    txtBrSale.Text = p.Sala.Broj_sale.ToString();
                    txtSlobMesta.Text = p.Sala.Uk_sedista.ToString();
                    txtDatum.Text = p.Vreme_pocetka.ToString();
                    id_sale2 = int.Parse(txtBrSale.Text);
                }
            }
        }
        

        private void btnDodajRez_Click_1(object sender, EventArgs e)
        {

            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaRez);
            rezervacije = bf.Deserialize(fs) as List<Rezervacije>;
            fs.Flush();
            fs.Close();


            int id_rez,id_proj,id_kupca;
            

            if (string.IsNullOrEmpty(cbKupci.Text))
                MessageBox.Show("Niste izabrali kupca.");
            else if (string.IsNullOrEmpty(cmbIDRezProj.Text))
                MessageBox.Show("Označite rezervaciju iz liste koju želite da izmenite.");
            else if (numericUpDown1.Value == 0)
                MessageBox.Show("Odaberite broj karata koliko želite za kupca.");
            else
            {
                id_proj = int.Parse(cmbIDRezProj.Text);
                id_kupca = (cbKupci.SelectedItem as Kupac).Id_kupca;
                if (rezervacije.Count == 0)
                    id_rez = 1;
                else
                {
                    int x = rezervacije.Max(t => t.Id_rezervacija);
                    id_rez = x + 1;
                }

                rezervacije.Add(new Rezervacije(id_rez, id_proj, id_kupca, (int)numericUpDown1.Value, ukupna_cena));
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaRez);
                bf.Serialize(fs, rezervacije);
                fs.Flush();
                fs.Close();
                MessageBox.Show("Uspešno ste izvršili rezervaciju.");

                foreach (Projekcija p in projekcija)
                {
                    if (p.Id_projekcija == id_proj)
                    {
                        foreach (Sala s in sala)
                        {
                            if (s.Id_sale == id_sale2)
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

                foreach (Rezervacije r in rezervacije)
                {
                    if ((cbKupci.SelectedItem as Kupac).Id_kupca == r.Id_kupca)
                        listBox1.Items.Add(r);
                }
            }
        }

        private void cmbIDRezProj_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Projekcija p in projekcija)
            {
                if (p.Id_projekcija.ToString() == cmbIDRezProj.Text)
                {
                    txtFilm.Text = p.Film.Naziv;
                    txtBrSale.Text = p.Sala.Broj_sale.ToString();
                    txtSlobMesta.Text = p.Sala.Uk_sedista.ToString();
                    txtDatum.Text = p.Vreme_pocetka.ToString();
                    id_sale2 = p.Sala.Id_sale;
                   // numericUpDown1.Value = staro;

                }
            }
        }

        private void btnObrisiRez_Click(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaRez);
            rezervacije = bf.Deserialize(fs) as List<Rezervacije>;
            fs.Flush();
            fs.Close();

            if (listBox1.SelectedIndex == -1)
                MessageBox.Show("Selektujte rezervaciju iz liste koju želite da obrišete.");
            else
            {
                for (int i = 0; i < rezervacije.Count; i++)
                {
                    if (rezervacije[i].Id_rezervacija == (listBox1.SelectedItem as Rezervacije).Id_rezervacija)
                    {
                        rezervacije.RemoveAt(i);
                        i--;
                        MessageBox.Show("Uspešno obrisana rezervacija.");
                    }
                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaRez);
                bf.Serialize(fs, rezervacije);
                fs.Flush();
                fs.Close();

                listBox1.Items.Clear();

                foreach (Rezervacije r in rezervacije)
                {
                    if ((cbKupci.SelectedItem as Kupac).Id_kupca == r.Id_kupca)
                        listBox1.Items.Add(r);
                }
                cmbIDRezProj.ResetText();
                txtFilm.Clear();
                txtBrSale.Clear();
                txtSlobMesta.Clear();
                txtDatum.Clear();
                numericUpDown1.Value = 0;
                txtUkupno.Clear();
            }
        }



        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Projekcija p in projekcija)
            {
                if (cmbIDRezProj.Text == p.Id_projekcija.ToString())
                {
                    cena_k = p.Cena;

                    if (p.Sala.Uk_sedista < (int)numericUpDown1.Value)
                    {
                        MessageBox.Show("Nema ovoliko dostupnih mesta.");
                        return;
                    }
                    else
                    {
                        ukupna_cena = cena_k * (int)numericUpDown1.Value;
                        txtUkupno.Text = ukupna_cena.ToString();
                    }

                }

            }
        }

        private void btnIzmeniRez_Click(object sender, EventArgs e)
        {
            bf = new BinaryFormatter();
            fs = File.OpenRead(putanjaRez);
            rezervacije = bf.Deserialize(fs) as List<Rezervacije>;
            fs.Flush();
            fs.Close();

            if (string.IsNullOrEmpty(cbKupci.Text))
                MessageBox.Show("Niste izabrali kupca.");
            else if (string.IsNullOrEmpty(cmbIDRezProj.Text))
                MessageBox.Show("Označite ID projekciju koju želite.");

            else
            {
                foreach (Rezervacije r in rezervacije)
                {
                    if (r.Id_rezervacija == (listBox1.SelectedItem as Rezervacije).Id_rezervacija)
                    {

                        r.Id_projekcija = int.Parse(cmbIDRezProj.Text);
                        r.Id_kupca = (cbKupci.SelectedItem as Kupac).Id_kupca;
                        r.Id_rezervacija = (listBox1.SelectedItem as Rezervacije).Id_rezervacija;
                        r.Uk_cena = ukupna_cena;
                        r.Br_mesta = (int)numericUpDown1.Value;
                    }
                }
                bf = new BinaryFormatter();
                fs = File.OpenWrite(putanjaRez);
                bf.Serialize(fs, rezervacije);
                fs.Flush();
                fs.Close();
                // int id_proj = int.Parse(txtIDProj.Text);
                int id_proj = int.Parse(cmbIDRezProj.Text);

                foreach (Projekcija p in projekcija)
                {
                    if (p.Id_projekcija == id_proj)
                    {
                        foreach (Sala s in sala)
                        {
                            if (s.Id_sale == p.Sala.Id_sale)
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

                listBox1.Items.Clear();

                foreach (Rezervacije r in rezervacije)
                {
                    if ((cbKupci.SelectedItem as Kupac).Id_kupca == r.Id_kupca)
                        listBox1.Items.Add(r);
                }
                cmbIDRezProj.ResetText();
                txtFilm.Clear();
                txtBrSale.Clear();
                txtSlobMesta.Clear();
                txtDatum.Clear();
                numericUpDown1.Value = 0;
                txtUkupno.Clear();

            }
        }
    }
}
