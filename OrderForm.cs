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
    public partial class OrderForm : Form
    {
        public static int TotalCoffees = 8;
        public static int TotalLandscapes = 6;

        private Gebied SelectedLandscape;
        private bool LandscapeChoice = false;
        private Koffie SelectedKoffie;
        
        private List<Koffie> KoffieLijst = new List<Koffie>();
        private List<Gebied> GebiedenLijst = new List<Gebied>();
        private PictureBox[] pictures = new PictureBox[8];
        PictureBox[] SterkteOptions = new PictureBox[5];
        PictureBox[] MelkOptions = new PictureBox[5];
        PictureBox[] SuikerOptions = new PictureBox[5];

        private PictureBox CenterPicture;
        private PictureBox SuikerPicture;
        private PictureBox SterktePicture;
        private PictureBox MelkPicture;

        private int XMiddle = 683;
        private int YMiddle = 350;
        private int Sterkte = 0, Melk = 0, Suiker = 0;

        public OrderForm()
        {
            InitializeComponent();
            
            InitPictureboxes();
            VulKoffieLijst();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(36,27,18);
        }

        private void InitPictureboxes() {
            //Eerste state van de GUI
            //Koffie Pictures
            CenterPicture = this.pictureBox9;
            CenterPicture.BackColor = Color.Transparent;

            pictures[0] = pictureBox1;
            pictures[1] = pictureBox2;
            pictures[2] = pictureBox3;
            pictures[3] = pictureBox4;
            pictures[4] = pictureBox5;
            pictures[5] = pictureBox6;
            pictures[6] = pictureBox7;
            pictures[7] = pictureBox8;

            SuikerPicture = pictureBox11;
            SuikerPicture.BackColor = Color.Transparent;
            SuikerPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\Suiker.png");
            

            SterktePicture = pictureBox10;
            SterktePicture.BackColor = Color.Transparent;
            SterktePicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\Sterkte.png");

            MelkPicture = pictureBox12;
            MelkPicture.BackColor = Color.Transparent;
            MelkPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\Melk.png");
            
            SterkteOptions = SetOptionsImages(SterkteOptions, 483, Sterkte);
            SuikerOptions = SetOptionsImages(SuikerOptions, 758, Suiker);
            MelkOptions = SetOptionsImages(MelkOptions, 621, Melk);
            for (int i = 0; i < SterkteOptions.Length; i++ )
            {
                SterkteOptions[i].Click += SetStrenghtValue;
                SuikerOptions[i].Click += SetSugarValue;
                MelkOptions[i].Click += SetMilkValue;
            }
        }

        private PictureBox[] SetOptionsImages(PictureBox[] pics, int LocX,int StartValue) {
            int LocY = 670;
            for (int i = 0; i < pics.Length; i++) {
                PictureBox p = new PictureBox();
                p.Visible = true;
                p.Size = new Size(125,20);
                p.Left = LocX;
                p.Top = LocY;
                p.BackColor = Color.Transparent;
                p.Name = i.ToString();
                if (i == (StartValue))
                {
                    p.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
                }else{
                    p.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
                }
                pics[i] = p;
                LocY -= 25;
                Controls.Add(pics[i]);
            }
            return pics;
        }

        private void VulEnviormentLijst() {
            GebiedenLijst.Add(new Gebied { Naam = "Alps", Image = ".\\Images\\Alps.png" });
            GebiedenLijst.Add(new Gebied { Naam = "BamboForest", Image = ".\\Images\\BamboForest.png" });
            GebiedenLijst.Add(new Gebied { Naam = "Hitachi", Image = ".\\Images\\Hitachi.png" });
            GebiedenLijst.Add(new Gebied { Naam = "ParisNights", Image = ".\\Images\\ParisNights.png" });
            GebiedenLijst.Add(new Gebied { Naam = "Bos", Image = ".\\Images\\Koffie\\koffie1.png" });
            GebiedenLijst.Add(new Gebied { Naam = "Strand", Image = ".\\Images\\Koffie\\koffie1.png" });
            
            //set images
            for (int i = 0; i < GebiedenLijst.Count; i++)
            {
                pictures[i].BackgroundImage = Image.FromFile(GebiedenLijst[i].Image);
                pictures[i].Name = GebiedenLijst[i].Naam;
                pictures[i].Left = XMiddle;
                pictures[i].Top = YMiddle;
                pictures[i].Visible = false;
                pictures[i].Click -= KoffieKeus;
                pictures[i].Click += LandscapeChoiceClick;
            }
        }

        private void VulKoffieLijst()
        {
            KoffieLijst.Add(new Koffie { Naam = "Cappucinno", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Ristretto", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Espresso", Image = ".\\Images\\Koffie\\Espresso.png" });
            KoffieLijst.Add(new Koffie { Naam = "Variatie Koffie", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Doubble Espresso", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Café Creme", Image = ".\\Images\\Koffie\\koffie1.png" });
            KoffieLijst.Add(new Koffie { Naam = "Warme Chocomelk", Image = ".\\Images\\Koffie\\Chocolade.png" });
            KoffieLijst.Add(new Koffie { Naam = "Thee", Image = ".\\Images\\Koffie\\koffie1.png" });
            //set images
            //for (int i = 0; i < Koffies.Length; i++) {
              //  Koffies[i].BackgroundImage = Image.FromFile(KoffieLijst[i].Image);
                //Koffies[i].Name = KoffieLijst[i].Naam;
            //}

           for (int i = 0; i < pictures.Length; i++)
            {
                pictures[i].BackgroundImage = Image.FromFile(KoffieLijst[i].Image);
                pictures[i].Name = KoffieLijst[i].Naam;
                pictures[i].BackColor = Color.Transparent;
            }
        }

        private void SetStrenghtValue(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            SterkteOptions[Sterkte].BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
            String NewValue = TempPicture.Name;
            TempPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
            Sterkte = Convert.ToInt32(NewValue);
        }
        private void SetMilkValue(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            MelkOptions[Melk].BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
            String NewValue = TempPicture.Name;
            TempPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
            Melk = Convert.ToInt32(NewValue);
        }
        private void SetSugarValue(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            SuikerOptions[Suiker].BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
            String NewValue = TempPicture.Name;
            TempPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
            Suiker = Convert.ToInt32(NewValue);
        }

        private void KoffieKeus(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            CenterPicture.BackgroundImage = TempPicture.BackgroundImage;
            SelectedKoffie = KoffieLijst.Find(x => x.Naam.Contains(TempPicture.Name));
        }

        private void LandscapeChoiceClick(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            BackgroundImage = TempPicture.BackgroundImage;
            SelectedLandscape = GebiedenLijst.Find(x => x.Naam.Contains(TempPicture.Name));
        }

        private void ToggleOptionsVisibility()
        {
            SterktePicture.Visible = !SterktePicture.Visible;
            foreach(PictureBox picture in SterkteOptions){
                picture.Visible = !picture.Visible;
            }

            MelkPicture.Visible = !MelkPicture.Visible;
            foreach (PictureBox picture in MelkOptions)
            {
                picture.Visible = !picture.Visible;
            }
            
            SuikerPicture.Visible = !SuikerPicture.Visible;
            foreach (PictureBox picture in SuikerOptions)
            {
                picture.Visible = !picture.Visible;
            }
        }

        private void OkeKnopKlik(object sender, EventArgs e)
        {
            if (!LandscapeChoice)
            {
                if (SelectedKoffie != null)
                {
                    MoveControls move = new MoveControls();
                    //move.MovePicturesToMiddle(pictures, XMiddle, YMiddle);
                    move.MoveBitchGetOutTheWay(pictures, XMiddle, YMiddle);
                    VulEnviormentLijst();
                    //move.MovePicturesToSide(pictures, XMiddle, YMiddle);
                    ToggleOptionsVisibility();
                    move.JustPlaceIt(pictures, XMiddle, YMiddle);
                    
                    LandscapeChoice = true;
                }
                else
                {
                    //TODO
                    //Pls Select Coffee Message
                }
            }
            else
            {
                if (SelectedLandscape != null)
                {
                    HttpController http = new HttpController();
                    http.PostKoffie(SelectedLandscape.Naam, SelectedKoffie.Naam, 30);
                    MoveControls move = new MoveControls();
                    move.MovePicturesToMiddle(pictures, XMiddle, YMiddle);
                }
            }
            
            
        }

        
    }
}
