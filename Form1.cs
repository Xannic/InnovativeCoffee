using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InovativeCoffeeGUI
{
    public partial class Form1 : Form
    {
        private List<Koffie> KoffieLijst = new List<Koffie>();
        public Form1()
        {
            InitializeComponent();
            InitClickEvents();
            VulKoffieLijst();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(36,27,18);
        }

        private void VulKoffieLijst()
        {
            KoffieLijst.Add(new Koffie { Naam = "Cappucinno", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Ristretto", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Espresso", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Variatie Koffie", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Dubble Espresso", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Café Creme", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Warme Chocomelk", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Thee", Image = ".\\Images\\Koffie\\koffie1.png" });
            //set images
            pictureBox1.BackgroundImage = Image.FromFile(KoffieLijst[0].Image);
            pictureBox2.BackgroundImage = Image.FromFile(KoffieLijst[1].Image);
            pictureBox3.BackgroundImage = Image.FromFile(KoffieLijst[2].Image);
            pictureBox4.BackgroundImage = Image.FromFile(KoffieLijst[3].Image);
            pictureBox5.BackgroundImage = Image.FromFile(KoffieLijst[4].Image);
            pictureBox6.BackgroundImage = Image.FromFile(KoffieLijst[5].Image);
            pictureBox7.BackgroundImage = Image.FromFile(KoffieLijst[6].Image);
            pictureBox8.BackgroundImage = Image.FromFile(KoffieLijst[7].Image);
        }

        private void InitClickEvents()
        {
            pictureBox1.Click += KoffieKeus;
            pictureBox2.Click += KoffieKeus;
            pictureBox3.Click += KoffieKeus;
            pictureBox4.Click += KoffieKeus;
            pictureBox5.Click += KoffieKeus;
            pictureBox6.Click += KoffieKeus;
            pictureBox7.Click += KoffieKeus;
            pictureBox8.Click += KoffieKeus;
        }

        private void KoffieKeus(object sender, EventArgs e)
        {
            String naam = ((PictureBox)sender).Name;
            
        }

        private void OkeKnopKlik(object sender, EventArgs e)
        {

        }
    }
}
