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
        private List<Gebied> GebiedenLijst = new List<Gebied>();
        private PictureBox[] Pictures = new PictureBox[8];
        private PictureBox[] Gebieden = new PictureBox[6];
        private PictureBox CenterPicture;
        private int XMiddle = 683;
        private int YMiddle = 350;
        private Koffie SelectedKoffie;
        private bool OkClikced = false;

        public Form1()
        {
            InitializeComponent();
            
            InitPictureboxes();
            VulEnviormentLijst();
            VulKoffieLijst();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(36,27,18);
        }

        private void InitPictureboxes() {
            //Eerste state van de GUI
            //Koffie Pictures
            CenterPicture = pictureBox9;
            Pictures[0] = pictureBox1;
            Pictures[1] = pictureBox2;
            Pictures[2] = pictureBox3;
            Pictures[3] = pictureBox4;
            Pictures[4] = pictureBox5;
            Pictures[5] = pictureBox6;
            Pictures[6] = pictureBox7;
            Pictures[7] = pictureBox8;

            //Tweede state van de GUI
            //Gebieden Pictures
            for (int i = 0; i < Gebieden.Length; i++) { 
                Gebieden[i] = new PictureBox();
                Gebieden[i].Size = new System.Drawing.Size(150, 150);
                Gebieden[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
        }

        private void VulEnviormentLijst() {
            GebiedenLijst.Add(new Gebied { Naam = "Bos", Image = ".\\Images\\Koffie\\koffie1.png" });
            GebiedenLijst.Add(new Gebied { Naam = "Strand", Image = ".\\Images\\Koffie\\koffie1.png" });
            GebiedenLijst.Add(new Gebied { Naam = "Bos", Image = ".\\Images\\Koffie\\koffie1.png" });
            GebiedenLijst.Add(new Gebied { Naam = "Strand", Image = ".\\Images\\Koffie\\koffie1.png" });
            GebiedenLijst.Add(new Gebied { Naam = "Bos", Image = ".\\Images\\Koffie\\koffie1.png" });
            GebiedenLijst.Add(new Gebied { Naam = "Strand", Image = ".\\Images\\Koffie\\koffie1.png" });
            //set images
            for (int i = 0; i < GebiedenLijst.Count;i++ )
            {
                Gebieden[i].BackgroundImage = Image.FromFile(GebiedenLijst[i].Image);
                Gebieden[i].Left = XMiddle;
                Gebieden[i].Top = YMiddle;
                Gebieden[i].Visible = false;
                this.Controls.Add(Gebieden[i]);
            }
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
            for (int i = 0; i < Pictures.Length; i++) {
                Pictures[i].BackgroundImage = Image.FromFile(KoffieLijst[i].Image);
                Pictures[i].Name = KoffieLijst[i].Naam;
            }
        }

        private void KoffieKeus(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            CenterPicture.BackgroundImage = TempPicture.BackgroundImage;
            SelectedKoffie = KoffieLijst.Find(x => x.Naam.Contains(TempPicture.Name));
        }

        private void OkeKnopKlik(object sender, EventArgs e)
        {
            if (!OkClikced)
            {
                if (SelectedKoffie != null)
                {
                    MoveControls move = new MoveControls();
                    move.MovePicturesToMiddle(Pictures, XMiddle, YMiddle);
                    move.MovePicturesToSide(Gebieden, XMiddle, YMiddle);
                }
                else
                {
                    //TODO
                    //Pls Select Coffee Message
                }
            }
            else { 
                //Post to server
                HttpController http = new HttpController();
                http.PostKoffie();
                }
            }
        }    
    }
}
