using System;
using System.Linq;
using System.Windows.Forms;
using CoffeeMachine.Models;

namespace CoffeeMachine.Controllers
{
    class MoveController
    {
        
        public void HidePictures(PictureBox[] pictures)
        {
            foreach (PictureBox pictureBox in pictures)
            {
                while (pictureBox.Height > 0)
                {
                    pictureBox.Height -= 5;
                    pictureBox.Width -= 5;
                    pictureBox.Refresh();
                }
            }
        }

        public void UnhidePictures(PictureBox[] pictures)
        {
            for (int i = 0; i < pictures.Length ; i++)
            {                
                while (pictures[i].Height < 150)
                {
                    pictures[i].Height += 5;
                    pictures[i].Width += 5;
                    //Pictures[i].Left = PictureCoordinatesList[i].X;
                    //Pictures[i].Top = PictureCoordinatesList[i].Y;
                    pictures[i].Refresh();
                }                
            }
        }

        #region Picture movement, old code not used
        /*
        private Coordinates[] PictureCoordinatesList = new Coordinates[6];

        public MoveController(int xStart, int yStart)
        {
            SetCoordinates(xStart, yStart);
        }

        public void SetCoordinates(int x, int y)
        {
            for (int i = 0; i < PictureCoordinatesList.Length; i++)
            {
                PictureCoordinatesList[i] = new Coordinates();
            }

            PictureCoordinatesList[0].X = x + 200;
            PictureCoordinatesList[0].Y = y - 200;
            PictureCoordinatesList[1].X = x - 350;
            PictureCoordinatesList[1].Y = y - 200;
            PictureCoordinatesList[2].X = x - 400;
            PictureCoordinatesList[2].Y = y - 25;
            PictureCoordinatesList[3].X = x + 250;
            PictureCoordinatesList[3].Y = y - 25;
            PictureCoordinatesList[4].X = x - 350;
            PictureCoordinatesList[4].Y = y + 150;
            PictureCoordinatesList[5].X = x + 200;
            PictureCoordinatesList[5].Y = y + 150;
        }
        public void MovePicturesOutOfCenter(PictureBox[] Pictures, int XMiddle, int YMiddle)
        {
            for (int i = 0; i < Pictures.Length; i++)
            {
                int x = Pictures[i].Left;
                int y = Pictures[i].Top;
                bool toRight;
                bool toBottom;

                while (!(x == XMiddle && y == YMiddle))
                {
                    toRight = (x < XMiddle);
                    toBottom = (y < YMiddle);
                    int tempX;
                    int tempY;

                    tempX = (toRight) ? Convert.ToInt32(x + (XMiddle / x)) : Convert.ToInt32(x - (x / XMiddle));
                    tempY = (toBottom) ? Convert.ToInt32(y + (YMiddle / y)) : Convert.ToInt32(y - (y / YMiddle));

                    x = tempX;
                    if (Pictures[i].Left != XMiddle)
                    {
                        Pictures[i].Left = tempX;
                        Pictures[i].Refresh();
                    }
                    else
                    {
                        x = XMiddle;
                    }
                    y = tempY;
                    if (Pictures[i].Top != YMiddle)
                    {
                        Pictures[i].Top = tempY;
                        Pictures[i].Refresh();
                    }
                    else
                    {
                        y = YMiddle;
                    }

                }

            }
        }

        public void MovePicturesToCenter(PictureBox[] Pictures, int XStart, int YStart)
        {
            Console.WriteLine("Starting move in the way");
            SetCoordinates(XStart, YStart);
            for (int i = 0; i < Pictures.Length; i++)
            {
                Console.WriteLine("moving picture " + i);
                Pictures[i].Visible = true;
                int x = Pictures[i].Left;
                int y = Pictures[i].Top;
                bool toRight;
                bool toBottom;

                while (!(x == PictureCoordinatesList[i].X && y == PictureCoordinatesList[i].Y))
                {
                    toRight = (x < PictureCoordinatesList[i].X);
                    toBottom = (y < PictureCoordinatesList[i].Y);
                    int tempX;
                    int tempY;

                    Console.WriteLine("x=" + x + "gebiedpla=" + PictureCoordinatesList[i].X);
                    Console.WriteLine("y=" + y + "gebiedpla=" + PictureCoordinatesList[i].Y);

                    tempX = (toRight) ? Convert.ToInt32(x + (PictureCoordinatesList[i].X / x)) : Convert.ToInt32(x - (x / PictureCoordinatesList[i].X));
                    tempY = (toBottom) ? Convert.ToInt32(y + (PictureCoordinatesList[i].Y / y)) : Convert.ToInt32(y - (y / PictureCoordinatesList[i].Y));

                    x = tempX;
                    if (Pictures[i].Left != PictureCoordinatesList[i].X)
                    {
                        Pictures[i].Left = tempX;
                    }
                    else
                    {
                        x = PictureCoordinatesList[i].X;
                    }
                    y = tempY;
                    if (Pictures[i].Top != PictureCoordinatesList[i].Y)
                    {
                        Pictures[i].Top = tempY;
                    }
                    else
                    {
                        y = PictureCoordinatesList[i].Y;
                    }

                    Pictures[i].Refresh();
                }

            }
        }
        */
        #endregion
    }
}
