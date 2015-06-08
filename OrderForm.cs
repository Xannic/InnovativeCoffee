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
        private Coffee SelectedKoffie;

        private List<Coffee> CoffeeList = new List<Coffee>();
        private List<Gebied> GebiedenLijst = new List<Gebied>();
        private PictureBox[] Pictures = new PictureBox[8];
        PictureBox[] SterkteOptions = new PictureBox[5];
        PictureBox[] MelkOptions = new PictureBox[5];
        PictureBox[] SuikerOptions = new PictureBox[5];

        private PictureBox CenterPicture;
        private PictureBox SuikerPicture;
        private PictureBox SterktePicture;
        private PictureBox MilkPicture;

        private int XMiddle = 683;
        private int YMiddle = 350;
        private int Sterkte = 0, Melk = 0, Suiker = 0;

        public OrderForm()
        {
            InitializeComponent();

            InitPictureboxes();
            InitOptions();
            VulKoffieLijst();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(36, 27, 18);
        }

        private void InitPictureboxes()
        {
            //Eerste state van de GUI
            //Koffie Pictures
            CenterPicture = this.pictureBox9;
            CenterPicture.BackColor = Color.Transparent;

            Pictures[0] = pictureBox1;
            Pictures[1] = pictureBox2;
            Pictures[2] = pictureBox3;
            Pictures[3] = pictureBox4;
            Pictures[4] = pictureBox5;
            Pictures[5] = pictureBox6;
            Pictures[6] = pictureBox7;
            Pictures[7] = pictureBox8;


        }

        private void InitOptions()
        {
            SuikerPicture = pictureBox11;
            SuikerPicture.BackColor = Color.Transparent;
            SuikerPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\Suiker.png");


            SterktePicture = pictureBox10;
            SterktePicture.BackColor = Color.Transparent;
            SterktePicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\Sterkte.png");

            MilkPicture = pictureBox12;
            MilkPicture.BackColor = Color.Transparent;
            MilkPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\Melk.png");

            SterkteOptions = SetOptionsImages(SterkteOptions, 483, Sterkte);
            SuikerOptions = SetOptionsImages(SuikerOptions, 758, Suiker);
            MelkOptions = SetOptionsImages(MelkOptions, 621, Melk);
            for (int i = 0; i < SterkteOptions.Length; i++)
            {
                SterkteOptions[i].Click += SetStrenghtValue;
                SuikerOptions[i].Click += SetSugarValue;
                MelkOptions[i].Click += SetMilkValue;
            }
        }

        private PictureBox[] SetOptionsImages(PictureBox[] pics, int LocX, int StartValue)
        {
            int LocY = 670;
            for (int i = 0; i < pics.Length; i++)
            {
                PictureBox p = new PictureBox();
                p.Visible = true;
                p.Size = new Size(125, 20);
                p.Left = LocX;
                p.Top = LocY;
                p.BackColor = Color.Transparent;
                p.Name = i.ToString();
                if (i == (StartValue))
                {
                    p.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
                }
                else
                {
                    p.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
                }
                pics[i] = p;
                LocY -= 25;
                Controls.Add(pics[i]);
            }
            return pics;
        }



        private void VulEnviormentLijst()
        {
            Array.Clear(Pictures, 0, Pictures.Length);
            InitPictureboxes();

            GebiedenLijst.Add(new Gebied { Naam = "Alps", Image = ".\\Images\\Alps.png" });
            GebiedenLijst.Add(new Gebied { Naam = "BamboForest", Image = ".\\Images\\BamboForest.png" });
            GebiedenLijst.Add(new Gebied { Naam = "Hitachi", Image = ".\\Images\\Hitachi.png" });
            GebiedenLijst.Add(new Gebied { Naam = "ParisNights", Image = ".\\Images\\ParisNights.png" });
            GebiedenLijst.Add(new Gebied { Naam = "Bos", Image = ".\\Images\\Koffie\\koffie1.png" });
            GebiedenLijst.Add(new Gebied { Naam = "Strand", Image = ".\\Images\\Koffie\\koffie1.png" });

            //set images
            for (int i = 0; i < GebiedenLijst.Count; i++)
            {
                Pictures[i].BackgroundImage = Image.FromFile(GebiedenLijst[i].Image);
                Pictures[i].Name = GebiedenLijst[i].Naam;
                Pictures[i].Left = XMiddle;
                Pictures[i].Top = YMiddle;
                Pictures[i].Click -= KoffieKeus;
                Pictures[i].Click += LandscapeChoiceClick;
            }
        }

        private void VulKoffieLijst()
        {
            CoffeeList.Add(new Coffee { Naam = "Cappucinno", Image = ".\\Images\\Koffie\\koffie1.png" });
            CoffeeList.Add(new Coffee { Naam = "Ristretto", Image = ".\\Images\\Koffie\\koffie1.png" });
            CoffeeList.Add(new Coffee { Naam = "Espresso", Image = ".\\Images\\Koffie\\Espresso.png" });
            CoffeeList.Add(new Coffee { Naam = "Variatie Koffie", Image = ".\\Images\\Koffie\\koffie1.png" });
            CoffeeList.Add(new Coffee { Naam = "Doubble Espresso", Image = ".\\Images\\Koffie\\koffie1.png" });
            CoffeeList.Add(new Coffee { Naam = "Cafe Creme", Image = ".\\Images\\Koffie\\koffie1.png" });
            CoffeeList.Add(new Coffee { Naam = "Warme Chocomelk", Image = ".\\Images\\Koffie\\Chocolade.png" });
            CoffeeList.Add(new Coffee { Naam = "Thee", Image = ".\\Images\\Koffie\\Thee.png" });
            //set images
            //for (int i = 0; i < Koffies.Length; i++) {
            //  Koffies[i].BackgroundImage = Image.FromFile(KoffieLijst[i].Image);
            //Koffies[i].Name = KoffieLijst[i].Naam;
            //}

            for (int i = 0; i < Pictures.Length; i++)
            {
                Pictures[i].BackgroundImage = Image.FromFile(CoffeeList[i].Image);
                Pictures[i].Name = CoffeeList[i].Naam;
                Pictures[i].BackColor = Color.Transparent;
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
            SelectedKoffie = CoffeeList.Find(x => x.Naam.Contains(TempPicture.Name));
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
            foreach (PictureBox picture in SterkteOptions)
            {
                picture.Visible = !picture.Visible;
            }

            MilkPicture.Visible = !MilkPicture.Visible;
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
                    move.HidePictures(Pictures, XMiddle, YMiddle);
                    //move.MoveBitchGetOutTheWay(pictures, XMiddle, YMiddle);
                    VulEnviormentLijst();
                    //move.MovePicturesToSide(pictures, XMiddle, YMiddle);
                    ToggleOptionsVisibility();
                    move.UnhidePictures(Pictures, XMiddle, YMiddle);
                    //move.JustPlaceIt(pictures, XMiddle, YMiddle);
                    //move.MoveBitchGetInTheWay(pictures, XMiddle, YMiddle);

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
                    //MoveControls move = new MoveControls();
                    //move.MovePicturesToMiddle(pictures, XMiddle, YMiddle);
                }
            }


        }


    }
}
