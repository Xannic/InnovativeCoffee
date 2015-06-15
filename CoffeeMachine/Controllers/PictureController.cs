using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMachine.Controllers
{
    class PictureController
    {
        public PictureBox GetSugarOptionPicture(PictureBox PictureBox)
        {
            PictureBox.BackColor = Color.Transparent;
            PictureBox.BackgroundImage = Image.FromFile(".\\Images\\Options\\Sugar.png");
            return PictureBox;
        }
        
        public PictureBox GetStrengthOptionPicture(PictureBox PictureBox)
        {
            PictureBox.BackColor = Color.Transparent;
            PictureBox.BackgroundImage = Image.FromFile(".\\Images\\Options\\Strength.png");
            return PictureBox;
        }

        public PictureBox GetMilkOptionPicture(PictureBox PictureBox)
        {
            PictureBox.BackColor = Color.Transparent;
            PictureBox.BackgroundImage = Image.FromFile(".\\Images\\Options\\Milk.png");
            return PictureBox;
        }

        private PictureBox[] SetOptionsImages(PictureBox[] pics, int LocX, int StartValue)
        {
            int LocY = 670;
            for (int i = 0; i < pics.Length; i++)
            {
                PictureBox Picture = new PictureBox();
                Picture.Visible = true;
                Picture.Size = new Size(125, 20);
                Picture.Left = LocX;
                Picture.Top = LocY;
                Picture.BackColor = Color.Transparent;
                Picture.Name = i.ToString();
                if (i == (StartValue))
                {
                    Picture.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionFilled.png");
                }
                else
                {
                    Picture.BackgroundImage = Image.FromFile(".\\Images\\Options\\OptionNotFilled.png");
                }
                pics[i] = Picture;
                LocY -= 25;
                Controls.Add(pics[i]);
            }
            return pics;
        }

    }

}
