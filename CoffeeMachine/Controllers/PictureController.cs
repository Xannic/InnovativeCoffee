using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CoffeeMachine.Models;

namespace CoffeeMachine.Controllers
{
    class PictureController
    {
        public PictureBox GetSugarOptionPicture(PictureBox pictureBox)
        {
            if (pictureBox == null) return null;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.BackgroundImage = Image.FromFile(".\\Images\\Options\\Sugar.png");
            return pictureBox;
        }
        
        public PictureBox GetStrengthOptionPicture(PictureBox pictureBox)
        {
            if (pictureBox == null) return null;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.BackgroundImage = Image.FromFile(".\\Images\\Options\\Strength.png");
            return pictureBox;
        }

        public PictureBox GetMilkOptionPicture(PictureBox pictureBox)
        {
            if (pictureBox == null) return null;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.BackgroundImage = Image.FromFile(".\\Images\\Options\\Milk.png");
            return pictureBox;
        }

        public PictureBox[] SetOptionsImages(PictureBox[] pics, int locX, int startValue)
        {
            int locY = 670;
            for (int i = 0; i < pics.Length; i++)
            {
                PictureBox picture = new PictureBox();
                picture.Visible = true;
                picture.Size = new Size(89, 20);
                picture.Left = locX+18;
                picture.Top = locY;
                picture.BackColor = Color.Transparent;
                picture.Name = i.ToString();
                if (i == (startValue))
                {
                    picture.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
                }
                else
                {
                    picture.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
                }
                pics[i] = picture;
                locY -= 25;
                //Control.Add(pics[i]);
                //Controls.Add(pics[i]);
            }
            return pics;
        }

        public PictureBox[] GetLandscapeImages()
        {
            List<Landscape> landscapeList = new List<Landscape>();
            PictureBox[] pictures = new PictureBox[8];

            landscapeList.Add(new Landscape { Name = "Alps", Image = ".\\Images\\Drink\\Alps.png" });
            landscapeList.Add(new Landscape { Name = "BamboForest", Image = ".\\Images\\Drink\\BamboForest.png" });
            landscapeList.Add(new Landscape { Name = "Hitachi", Image = ".\\Images\\Drink\\Hitachi.png" });
            landscapeList.Add(new Landscape { Name = "ParisNights", Image = ".\\Images\\Drink\\ParisNights.png" });
            landscapeList.Add(new Landscape { Name = "Bos", Image = ".\\Images\\Coffee\\Coffee1.png" });
            landscapeList.Add(new Landscape { Name = "Strand", Image = ".\\Images\\Coffee\\Coffee1.png" });

            //set images
            for (int i = 0; i < landscapeList.Count; i++)
            {
                pictures[i].BackgroundImage = Image.FromFile(landscapeList[i].Image);
                pictures[i].Name = landscapeList[i].Name;
                //Pictures[i].Left = XMiddle;
                //Pictures[i].Top = YMiddle;
                //Pictures[i].Click -= CoffeeChoice;
                //Pictures[i].Click += LandscapeChoiceClick;
            }

            return pictures;
        
        }

    }

}
