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
    public partial class FormKupac : Form
    {
        public delegate void podaci(int podaci);
        podaci prosledi_id;

        FormAzuriranje frmAzur;
        FormaRezervacija frmRez;

        FileStream fs;
        BinaryFormatter bf;

        string putanjaRez = "rezervacija.bin";
        List<Rezervacije> rezervacije;

        int id_kupac;
        public FormKupac()
        {
            InitializeComponent();
            this.CenterToScreen();
            
        }

        private void btnRezervacija_Click(object sender, EventArgs e)
        {
            frmRez = new FormaRezervacija();
            this.prosledi_id = new podaci(frmRez.ispisi_id);
            prosledi_id(id_kupac);

            frmRez.Show();
            this.Close();
        }

        public void ispisi_id(int podaci)
        {
            id_kupac = podaci;
            lblID.Text = podaci.ToString();
            
        }

        private void FormKupac_Load(object sender, EventArgs e)
        {
          
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

            listBox1.Items.Clear();
            foreach (Rezervacije r in rezervacije)
            {
                if (id_kupac == r.Id_kupca)
                    listBox1.Items.Add(r);
            }
            
        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(id_kupac.ToString());
        }

        private void btnAzuriranje_Click(object sender, EventArgs e)
        {
            frmAzur = new FormAzuriranje();
            this.prosledi_id = new podaci(frmAzur.ispisi_id);
            prosledi_id(id_kupac);
            this.Close();
            frmAzur.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rezervacije.Count; i++)
            {
                if(rezervacije[i].Id_rezervacija==(listBox1.SelectedItem as Rezervacije).Id_rezervacija)
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
                if (id_kupac == r.Id_kupca)
                    listBox1.Items.Add(r);
            }
        }
    }
}
