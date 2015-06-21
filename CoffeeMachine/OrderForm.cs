using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CoffeeMachine.Controllers;
using CoffeeMachine.Models;
using CoffeeMachine.Properties;

namespace CoffeeMachine
{
    public partial class OrderForm : Form
    {
        OrderController _orderController = new OrderController();
        readonly DrinkController _drinkController = new DrinkController();
        readonly LandscapeController _landscapeController = new LandscapeController();
        
        //private List<Drink> DrinkList = new List<Drink>();
        //private List<Landscape> LandscapeList = new List<Landscape>();
        private PictureBox[] _pictures = new PictureBox[8];
        PictureBox[] _strengthOptions = new PictureBox[5];
        PictureBox[] _milkOptions = new PictureBox[5];
        PictureBox[] _sugarOptions = new PictureBox[5];

        private PictureBox _centerPicture;
        private PictureBox _sugarPicture;
        private PictureBox _strengthPicture;
        private PictureBox _milkPicture;
        
        private int XMiddle = 683;
        private int YMiddle = 350;
        private int _stepNumber = 1;
        
        public OrderForm()
        {
            InitializeComponent();
            InitializeSystem();

            FillPictureboxes(_drinkController.Drinks);
            
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
            _centerPicture = pictureBox9;
            
            _pictures[0] = pictureBox1;
            _pictures[1] = pictureBox2;
            _pictures[2] = pictureBox3;
            _pictures[3] = pictureBox4;
            _pictures[4] = pictureBox5;
            _pictures[5] = pictureBox6;
            _pictures[6] = pictureBox7;
            _pictures[7] = pictureBox8;
           
        }

        private void InitializeOptions()
        {
            PictureController pictureController = new PictureController();

            _strengthPicture = pictureController.GetStrengthOptionPicture(pictureBox10);
            _sugarPicture = pictureController.GetSugarOptionPicture(pictureBox11);
            _milkPicture = pictureController.GetMilkOptionPicture(pictureBox12);

            _strengthOptions = pictureController.SetOptionsImages(_strengthOptions, 483, _orderController.Strength);
            _sugarOptions = pictureController.SetOptionsImages(_sugarOptions, 758, _orderController.Sugar);
            _milkOptions = pictureController.SetOptionsImages(_milkOptions, 621, _orderController.Milk);

            Controls.AddRange(_strengthOptions);
            Controls.AddRange(_sugarOptions);
            Controls.AddRange(_milkOptions);

            AddClickHandler(_strengthOptions, SetStrenghtValue);
            AddClickHandler(_sugarOptions, SetSugarValue);
            AddClickHandler(_milkOptions, SetMilkValue);
                       
        }

        private void FillPictureboxes(List<Drink> drinks)
        {
            ClearImages();

            for (int i = 0; i < drinks.Count; i++)
            {
                _pictures[i].BackgroundImage = Image.FromFile(drinks[i].Image);
                _pictures[i].Name = drinks[i].Name;
                _pictures[i].BackColor = Color.Transparent;
                _pictures[i].Click += DrinkChoiceClick;
                _pictures[i].Click -= LandscapeChoiceClick;
            }
        }

        private void ClearImages()
        {
            foreach (PictureBox picture in _pictures)
            {
                picture.BackgroundImage = null;
            }
        }

        private void FillPictureboxes(List<Landscape> landscapes)
        {
            ClearImages();

            for (int i = 0; i < landscapes.Count; i++)
            {
                _pictures[i].BackgroundImage = Image.FromFile(landscapes[i].Image);
                _pictures[i].Name = landscapes[i].Name;
                _pictures[i].Click -= DrinkChoiceClick;
                _pictures[i].Click += LandscapeChoiceClick;
            }
        }

        private void AddClickHandler(IEnumerable<PictureBox> picturebox, EventHandler method){
            foreach (var picture in picturebox)
            {
                picture.Click += method;
            }
        }
        
        private void RenderScreen()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            BackColor = Color.FromArgb(36, 27, 18);
            _centerPicture.BackColor = Color.Transparent;
            _centerPicture.BackgroundImage = null;
        }

        private void FillLandscapes()
        {
            /*
            Array.Clear(_pictures, 0, _pictures.Length);
            InitializeVariables();

            LandscapeList.Add(new Landscape { Name = "Alps", Image = ".\\Images\\Drink\\Alps.png" });
            LandscapeList.Add(new Landscape { Name = "BamboForest", Image = ".\\Images\\Drink\\BamboForest.png" });
            LandscapeList.Add(new Landscape { Name = "Hitachi", Image = ".\\Images\\Drink\\Hitachi.png" });
            LandscapeList.Add(new Landscape { Name = "ParisNights", Image = ".\\Images\\Drink\\ParisNights.png" });
            LandscapeList.Add(new Landscape { Name = "Bos", Image = ".\\Images\\Coffee\\Coffee1.png" });
            LandscapeList.Add(new Landscape { Name = "Strand", Image = ".\\Images\\Coffee\\Coffee1.png" });

            //set images
            for (int i = 0; i < LandscapeList.Count; i++)
            {
                _pictures[i].BackgroundImage = Image.FromFile(LandscapeList[i].Image);
                _pictures[i].Name = LandscapeList[i].Name;
                _pictures[i].Left = XMiddle;
                _pictures[i].Top = YMiddle;
                _pictures[i].Click -= DrinkChoiceClick;
                _pictures[i].Click += LandscapeChoiceClick;
            }
            */
        }

        private void FillCoffeeList()
        {
            /*
            DrinkList.Add(new Drink { Name = "Cappucinno", Image = ".\\Images\\Drink\\Coffee1.png" });
            DrinkList.Add(new Drink { Name = "Ristretto", Image = ".\\Images\\Drink\\Coffee1.png" });
            DrinkList.Add(new Drink { Name = "Espresso", Image = ".\\Images\\Drink\\Espresso.png" });
            DrinkList.Add(new Drink { Name = "Variatie Coffee", Image = ".\\Images\\Drink\\Coffee1.png" });
            DrinkList.Add(new Drink { Name = "Doubble Espresso", Image = ".\\Images\\Drink\\Coffee1.png" });
            DrinkList.Add(new Drink { Name = "Cafe Creme", Image = ".\\Images\\Drink\\Coffee1.png" });
            DrinkList.Add(new Drink { Name = "Warme Chocomelk", Image = ".\\Images\\Drink\\Chocolade.png" });
            DrinkList.Add(new Drink { Name = "Thee", Image = ".\\Images\\Drink\\Thee.png" });
            
            for (int i = 0; i < _pictures.Length; i++)
            {
                _pictures[i].BackgroundImage = Image.FromFile(DrinkList[i].Image);
                _pictures[i].Name = DrinkList[i].Name;
                _pictures[i].BackColor = Color.Transparent;
            }
             */
        }

        private void FillUnderlyingPictures(PictureBox[] pictureBoxes, int id)
        {
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (i <= id) {
                    pictureBoxes[i].BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
                }
                else
                {
                    pictureBoxes[i].BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
                }
            }
        }

        private void SetStrenghtValue(object sender, EventArgs e)
        {
            PictureBox tempPicture = (PictureBox)sender;
            _orderController.Strength = Convert.ToInt32(tempPicture.Name);
            FillUnderlyingPictures(_strengthOptions, _orderController.Strength);
        }
        private void SetMilkValue(object sender, EventArgs e)
        {
            PictureBox tempPicture = (PictureBox)sender;
            _orderController.Milk = Convert.ToInt32(tempPicture.Name);
            FillUnderlyingPictures(_milkOptions, _orderController.Milk);
        }
        private void SetSugarValue(object sender, EventArgs e)
        {
            PictureBox tempPicture = (PictureBox)sender;
            _orderController.Sugar = Convert.ToInt32(tempPicture.Name);
            FillUnderlyingPictures(_sugarOptions, _orderController.Sugar);
        }

        private void DrinkChoiceClick(object sender, EventArgs e)
        {
            PictureBox tempPicture = (PictureBox)sender;
            _centerPicture.BackgroundImage = tempPicture.BackgroundImage;
            _orderController.SelectedCoffee = _drinkController.Drinks.Find(x => x.Name.Contains(tempPicture.Name));

            ButtonOk.Visible = true;
        }

        private void LandscapeChoiceClick(object sender, EventArgs e)
        {
            PictureBox tempPicture = (PictureBox)sender;
            //BackgroundImage = TempPicture.BackgroundImage;
            _orderController.SelectedLandscape = _landscapeController.Landscapes.Find(x => x.Name.Contains(tempPicture.Name));

            ButtonOk.Visible = true;
        }

        private void OptionsVisibility(bool visiblity)
        {
            _strengthPicture.Visible = visiblity;
            foreach (PictureBox picture in _strengthOptions)
            {
                picture.Visible = visiblity;
            }

            _milkPicture.Visible = !_milkPicture.Visible;
            foreach (PictureBox picture in _milkOptions)
            {
                picture.Visible = visiblity;
            }

            _sugarPicture.Visible = !_sugarPicture.Visible;
            foreach (PictureBox picture in _sugarOptions)
            {
                picture.Visible = visiblity;
            }
        }

        private void ResetScreen()
        {
            _orderController = new OrderController();
            InitializeComponent();
            InitializeSystem();
            InitializeVariables();
            InitializeOptions();
            FillPictureboxes(_drinkController.Drinks);
            
            BerichtLbl.Visible = false;

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            BackColor = Color.FromArgb(36, 27, 18);
            _centerPicture.Visible = false;
            _stepNumber = 1;

            Refresh();
        }

        private void GoToStepTwo()
        {
            MoveController move = new MoveController(XMiddle, YMiddle);

            OptionsVisibility(false);
            ButtonOk.Visible = false;
            ButtonBack.Visible = true;
            move.HidePictures(_pictures);
            
            FillPictureboxes(_landscapeController.Landscapes);
            move.UnhidePictures(_pictures);
            _stepNumber = 2;

        }

        private async void SendToServer()
        {
            MoveController move = new MoveController(XMiddle, YMiddle);
            HttpController httpController = new HttpController();
            var fooCaller = new Func<bool>(httpController.CanWePlay);

            var asyncResult = fooCaller.BeginInvoke(null, null);
            move.HidePictures(_pictures);

            asyncResult.AsyncWaitHandle.WaitOne();
            bool canPlay = fooCaller.EndInvoke(asyncResult);
            if (canPlay)
            {
                BerichtLbl.Text = "Uw " + _orderController.SelectedCoffee.Name + " wordt gezet u kunt naar de belevingskamer lopen.";
                BerichtLbl.Visible = true;
                    
                httpController.PostCoffee(_orderController.SelectedLandscape.Name, _orderController.SelectedCoffee.Name, 30);
            }
            else
            {
                BerichtLbl.Text = Resources.ChamberInUse;
                BerichtLbl.Visible = true;
                bool sended = false;
                this.Refresh();
                    
                while (!sended)
                {
                    Thread.Sleep(1500);

                    if (httpController.CanWePlay())
                    {
                        BerichtLbl.Text = "Uw " + _orderController.SelectedCoffee.Name + " wordt gezet u kunt naar de belevingskamer lopen.";
                        Refresh();
                            
                        sended = true;
                        httpController.PostCoffee(_orderController.SelectedLandscape.Name, _orderController.SelectedCoffee.Name, 30);
                    }
                }
            }

            Thread.Sleep(3000);

            BerichtLbl.Visible = false;
            ResetScreen();
                                
        }

        private void BackButtonClicked(object sender, EventArgs e)
        {
            MoveController move = new MoveController(XMiddle, YMiddle);

            OptionsVisibility(true);
            ButtonOk.Visible = true;
            ButtonBack.Visible = false;
            move.HidePictures(_pictures);

            FillPictureboxes(_drinkController.Drinks);
            move.UnhidePictures(_pictures);
            _stepNumber = 1;
        }

        private void OkeButtonClicked(object sender, EventArgs e)
        {
            MoveController move = new MoveController(XMiddle, YMiddle);

            switch (_stepNumber)
            {
                case 1:
                    if (_orderController.SelectedCoffee == null) return;
                    GoToStepTwo();

                    break;
                case 2:
                    if (_orderController.SelectedLandscape == null) return;
                    SendToServer();
                    break;
            }
            /*
            if (_orderController.SelectedLandscape == null)
            {

                if (_orderController.SelectedCoffee != null)
                {
                    
                    move.HidePictures(_pictures);
                    OptionsVisibility(false);
                    FillPictureboxes(_landscapeController.Landscapes);
                    move.UnhidePictures(_pictures);

                    ButtonOk.Visible = false;
                }
            }
            else
            {
                move.HidePictures(_pictures);
                
                HttpController htc = new HttpController();
                bool canPlay = htc.CanWePlay();

                if (canPlay)
                {
                    BerichtLbl.Text = "Uw " + _orderController.SelectedCoffee.Name + " wordt gezet u kunt naar de belevingskamer lopen.";
                    BerichtLbl.Visible = true;
                    
                    htc.PostCoffee(_orderController.SelectedLandscape.Name, _orderController.SelectedCoffee.Name, 30);
                }
                else
                {
                    BerichtLbl.Text = Resources.ChamberInUse;
                    BerichtLbl.Visible = true;
                    bool sended = false;
                    this.Refresh();
                    
                    while (!sended)
                    {
                        Thread.Sleep(2500);

                        if (htc.CanWePlay())
                        {
                            BerichtLbl.Text = "Uw " + _orderController.SelectedCoffee.Name + " wordt gezet u kunt naar de belevingskamer lopen.";
                            this.Refresh();
                            
                            sended = true;
                            htc.PostCoffee(_orderController.SelectedLandscape.Name, _orderController.SelectedCoffee.Name, 30);
                        }
                    }
                }

                Thread.Sleep(3000);

                BerichtLbl.Visible = false;
                ResetScreen();
                
            }*/            
        }
    }
}
