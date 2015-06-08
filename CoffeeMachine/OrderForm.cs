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

        private Landscape SelectedLandscape;
        private bool LandscapeChoice = false;
        private Coffee SelectedCoffee;

        private List<Coffee> CoffeeList = new List<Coffee>();
        private List<Landscape> GebiedenLijst = new List<Landscape>();
        private PictureBox[] Pictures = new PictureBox[8];
        PictureBox[] StrengthOptions = new PictureBox[5];
        PictureBox[] MilkOptions = new PictureBox[5];
        PictureBox[] SugarOptions = new PictureBox[5];

        private PictureBox CenterPicture;
        private PictureBox SugarPicture;
        private PictureBox StrengthPicture;
        private PictureBox MilkPicture;

        private int XMiddle = 683;
        private int YMiddle = 350;
        private int Strength = 0, Milk = 0, Sugar = 0;

        public OrderForm()
        {
            InitializeComponent();

            InitPictureboxes();
            InitOptions();
            FillCoffeeList();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(36, 27, 18);
        }

        private void InitPictureboxes()
        {
            //Eerste state van de GUI
            //Coffee Pictures
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
            SugarPicture = pictureBox11;
            SugarPicture.BackColor = Color.Transparent;
            SugarPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\Suiker.png");
            
            StrengthPicture = pictureBox10;
            StrengthPicture.BackColor = Color.Transparent;
            StrengthPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\Sterkte.png");

            MilkPicture = pictureBox12;
            MilkPicture.BackColor = Color.Transparent;
            MilkPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\Melk.png");

            StrengthOptions = SetOptionsImages(StrengthOptions, 483, Strength);
            SugarOptions = SetOptionsImages(SugarOptions, 758, Sugar);
            MilkOptions = SetOptionsImages(MilkOptions, 621, Milk);
            
            for (int i = 0; i < StrengthOptions.Length; i++)
            {
                StrengthOptions[i].Click += SetStrenghtValue;
                SugarOptions[i].Click += SetSugarValue;
                MilkOptions[i].Click += SetMilkValue;
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



        private void FillLandscapes()
        {
            Array.Clear(Pictures, 0, Pictures.Length);
            InitPictureboxes();

            GebiedenLijst.Add(new Landscape { Name = "Alps", Image = ".\\Images\\Landscapes\\Alps.png" });
            GebiedenLijst.Add(new Landscape { Name = "BamboForest", Image = ".\\Images\\Landscapes\\BamboForest.png" });
            GebiedenLijst.Add(new Landscape { Name = "Hitachi", Image = ".\\Images\\Landscapes\\Hitachi.png" });
            GebiedenLijst.Add(new Landscape { Name = "ParisNights", Image = ".\\Images\\Landscapes\\ParisNights.png" });
            GebiedenLijst.Add(new Landscape { Name = "Bos", Image = ".\\Images\\Coffee\\Coffee1.png" });
            GebiedenLijst.Add(new Landscape { Name = "Strand", Image = ".\\Images\\Coffee\\Coffee1.png" });

            //set images
            for (int i = 0; i < GebiedenLijst.Count; i++)
            {
                Pictures[i].BackgroundImage = Image.FromFile(GebiedenLijst[i].Image);
                Pictures[i].Name = GebiedenLijst[i].Name;
                Pictures[i].Left = XMiddle;
                Pictures[i].Top = YMiddle;
                Pictures[i].Click -= CoffeeChoice;
                Pictures[i].Click += LandscapeChoiceClick;
            }
        }

        private void FillCoffeeList()
        {
            CoffeeList.Add(new Coffee { Name = "Cappucinno", Image = ".\\Images\\Coffee\\Coffee1.png" });
            CoffeeList.Add(new Coffee { Name = "Ristretto", Image = ".\\Images\\Coffee\\Coffee1.png" });
            CoffeeList.Add(new Coffee { Name = "Espresso", Image = ".\\Images\\Coffee\\Espresso.png" });
            CoffeeList.Add(new Coffee { Name = "Variatie Coffee", Image = ".\\Images\\Coffee\\Coffee1.png" });
            CoffeeList.Add(new Coffee { Name = "Doubble Espresso", Image = ".\\Images\\Coffee\\Coffee1.png" });
            CoffeeList.Add(new Coffee { Name = "Cafe Creme", Image = ".\\Images\\Coffee\\Coffee1.png" });
            CoffeeList.Add(new Coffee { Name = "Warme Chocomelk", Image = ".\\Images\\Coffee\\Chocolade.png" });
            CoffeeList.Add(new Coffee { Name = "Thee", Image = ".\\Images\\Coffee\\Thee.png" });
            
            for (int i = 0; i < Pictures.Length; i++)
            {
                Pictures[i].BackgroundImage = Image.FromFile(CoffeeList[i].Image);
                Pictures[i].Name = CoffeeList[i].Name;
                Pictures[i].BackColor = Color.Transparent;
            }
        }

        private void SetStrenghtValue(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            StrengthOptions[Strength].BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
            TempPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
            Strength = Convert.ToInt32(TempPicture.Name);
        }
        private void SetMilkValue(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            MilkOptions[Milk].BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
            TempPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
            Milk = Convert.ToInt32(TempPicture.Name);
        }
        private void SetSugarValue(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            SugarOptions[Sugar].BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
            TempPicture.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
            Sugar = Convert.ToInt32(TempPicture.Name);
        }

        private void CoffeeChoice(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            CenterPicture.BackgroundImage = TempPicture.BackgroundImage;
            SelectedCoffee = CoffeeList.Find(x => x.Name.Contains(TempPicture.Name));
        }

        private void LandscapeChoiceClick(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            BackgroundImage = TempPicture.BackgroundImage;
            SelectedLandscape = GebiedenLijst.Find(x => x.Name.Contains(TempPicture.Name));
        }

        private void ToggleOptionsVisibility()
        {
            StrengthPicture.Visible = !StrengthPicture.Visible;
            foreach (PictureBox picture in StrengthOptions)
            {
                picture.Visible = !picture.Visible;
            }

            MilkPicture.Visible = !MilkPicture.Visible;
            foreach (PictureBox picture in MilkOptions)
            {
                picture.Visible = !picture.Visible;
            }

            SugarPicture.Visible = !SugarPicture.Visible;
            foreach (PictureBox picture in SugarOptions)
            {
                picture.Visible = !picture.Visible;
            }
        }

        private void OkeButtonClicked(object sender, EventArgs e)
        {
            if (!LandscapeChoice)
            {
                if (SelectedCoffee != null)
                {
                    MoveControls move = new MoveControls();
                    move.HidePictures(Pictures, XMiddle, YMiddle);
                    ToggleOptionsVisibility();
                    FillLandscapes();
                    move.UnhidePictures(Pictures, XMiddle, YMiddle);
                    
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
                    http.PostCoffee(SelectedLandscape.Name, SelectedCoffee.Name, 30);
                    //MoveControls move = new MoveControls();
                    //move.MovePicturesToMiddle(pictures, XMiddle, YMiddle);
                }
            }
        }
    }
}
