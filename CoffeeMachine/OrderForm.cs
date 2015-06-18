﻿using CoffeeMachine.Controllers;
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
        OrderController OrderController = new OrderController();
        
        private List<Coffee> CoffeeList = new List<Coffee>();
        private List<Landscape> LandscapeList = new List<Landscape>();
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
        

        public OrderForm()
        {
            InitializeComponent();
            InitializeSystem();

            FillCoffeeList();
        }

        private void InitializeSystem()
        {
            InitializeVariables();
            InitializeOptions();

            RenderScreen();
        }

        private void InitializeVariables()
        {
            //Eerste state van de GUI
            //Coffee Pictures
            CenterPicture = this.pictureBox9;
            
            Pictures[0] = pictureBox1;
            Pictures[1] = pictureBox2;
            Pictures[2] = pictureBox3;
            Pictures[3] = pictureBox4;
            Pictures[4] = pictureBox5;
            Pictures[5] = pictureBox6;
            Pictures[6] = pictureBox7;
            Pictures[7] = pictureBox8;
           
        }

        private void InitializeOptions()
        {
            PictureController PictureController = new PictureController();

            StrengthPicture = PictureController.GetStrengthOptionPicture(pictureBox10);
            SugarPicture = PictureController.GetSugarOptionPicture(pictureBox11);
            MilkPicture = PictureController.GetMilkOptionPicture(pictureBox12);

            StrengthOptions = PictureController.SetOptionsImages(StrengthOptions, 483, OrderController.Strength);
            SugarOptions = PictureController.SetOptionsImages(SugarOptions, 758, OrderController.Sugar);
            MilkOptions = PictureController.SetOptionsImages(MilkOptions, 621, OrderController.Milk);

            Controls.AddRange(StrengthOptions);
            Controls.AddRange(SugarOptions);
            Controls.AddRange(MilkOptions);

            AddClickHandler(StrengthOptions, SetStrenghtValue);
            AddClickHandler(SugarOptions, SetSugarValue);
            AddClickHandler(MilkOptions, SetMilkValue);
                       
        }

        private void AddClickHandler(PictureBox[] Picturebox, EventHandler Method){
            foreach (PictureBox Picture in Picturebox)
            {
                Picture.Click += Method;
            }
        }
        
        private void RenderScreen()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(36, 27, 18);
            CenterPicture.BackColor = Color.Transparent;
            CenterPicture.BackgroundImage = null;
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
            InitializeVariables();

            LandscapeList.Add(new Landscape { Name = "Alps", Image = ".\\Images\\Landscapes\\Alps.png" });
            LandscapeList.Add(new Landscape { Name = "BamboForest", Image = ".\\Images\\Landscapes\\BamboForest.png" });
            LandscapeList.Add(new Landscape { Name = "Hitachi", Image = ".\\Images\\Landscapes\\Hitachi.png" });
            LandscapeList.Add(new Landscape { Name = "ParisNights", Image = ".\\Images\\Landscapes\\ParisNights.png" });
            LandscapeList.Add(new Landscape { Name = "Bos", Image = ".\\Images\\Coffee\\Coffee1.png" });
            LandscapeList.Add(new Landscape { Name = "Strand", Image = ".\\Images\\Coffee\\Coffee1.png" });

            //set images
            for (int i = 0; i < LandscapeList.Count; i++)
            {
                Pictures[i].BackgroundImage = Image.FromFile(LandscapeList[i].Image);
                Pictures[i].Name = LandscapeList[i].Name;
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

        private void FillUnderlyingPictures(PictureBox[] PictureBoxes, int id)
        {
            for (int i = 0; i < PictureBoxes.Length; i++)
            {
                if (i <= id) {
                    PictureBoxes[i].BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
                }
                else
                {
                    PictureBoxes[i].BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
                }
            }
        }

        private void SetStrenghtValue(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            OrderController.Strength = Convert.ToInt32(TempPicture.Name);
            FillUnderlyingPictures(StrengthOptions, OrderController.Strength);
        }
        private void SetMilkValue(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            OrderController.Milk = Convert.ToInt32(TempPicture.Name);
            FillUnderlyingPictures(MilkOptions, OrderController.Milk);
        }
        private void SetSugarValue(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            OrderController.Sugar = Convert.ToInt32(TempPicture.Name);
            FillUnderlyingPictures(SugarOptions, OrderController.Sugar);
        }

        private void CoffeeChoice(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            CenterPicture.BackgroundImage = TempPicture.BackgroundImage;
            OrderController.SelectedCoffee = CoffeeList.Find(x => x.Name.Contains(TempPicture.Name));

            ButtonOk.Visible = true;
        }

        private void LandscapeChoiceClick(object sender, EventArgs e)
        {
            PictureBox TempPicture = (PictureBox)sender;
            //BackgroundImage = TempPicture.BackgroundImage;
            OrderController.SelectedLandscape = LandscapeList.Find(x => x.Name.Contains(TempPicture.Name));

            ButtonOk.Visible = true;
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

        private void ResetScreen()
        {
            OrderController = new OrderController();
            InitializeComponent();
            InitializeSystem();
            InitializeVariables();
            InitializeOptions();
            FillCoffeeList();
            BerichtLbl.Visible = false;

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(36, 27, 18);

            
            this.Refresh();
        }

        private async void OkeButtonClicked(object sender, EventArgs e)
        {
            MoveControls move = new MoveControls(XMiddle, YMiddle);

            if (OrderController.SelectedLandscape == null)
            {

                if (OrderController.SelectedCoffee != null)
                {
                    
                    move.HidePictures(Pictures);
                    ToggleOptionsVisibility();
                    FillLandscapes();
                    move.UnhidePictures(Pictures);

                    ButtonOk.Visible = false;
                }
            }
            else
            {
                Console.WriteLine("verzend bericht naar server");
                move.HidePictures(Pictures);
                
                
                HttpController htc = new HttpController();
                bool canPlay = htc.CanWePlay();

                if (canPlay)
                {
                    BerichtLbl.Text = "Uw " + OrderController.SelectedCoffee.Name + " wordt gezet u kunt naar de belevingskamer lopen.";
                    BerichtLbl.Visible = true;
                    Console.WriteLine("coffee sended");
                    htc.PostCoffee(OrderController.SelectedLandscape.Name, OrderController.SelectedCoffee.Name, 30);
                }
                else
                {
                    BerichtLbl.Text = "De belevingskamer is in gebruik een moment geduld aub..";
                    BerichtLbl.Visible = true;
                    bool sended = false;
                    this.Refresh();
                    
                    while (!sended)
                    {
                        System.Threading.Thread.Sleep(2500);

                        if (htc.CanWePlay())
                        {
                            BerichtLbl.Text = "Uw " + OrderController.SelectedCoffee.Name + " wordt gezet u kunt naar de belevingskamer lopen.";
                            this.Refresh();
                            Console.WriteLine("coffee sended");
                            sended = true;
                            htc.PostCoffee(OrderController.SelectedLandscape.Name, OrderController.SelectedCoffee.Name, 30);
                        }
                    }
                }

                System.Threading.Thread.Sleep(3000);

                BerichtLbl.Visible = false;
                ResetScreen();
                
            }            
        }
    }
}
