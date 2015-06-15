using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InovativeCoffeeGUI
{
    class MoveControls
    {
        private Coordinates[] PictureCoordinatesList = new Coordinates[6];

        public MoveControls(int XStart, int YStart)
        {
            SetCoordinates(XStart, YStart);
        }
        
        public void SetCoordinates(int x, int y) {
            for (int i = 0; i < PictureCoordinatesList.Length; i++) {
                PictureCoordinatesList[i] = new Coordinates();
            }

            PictureCoordinatesList[0].x = x + 200;
            PictureCoordinatesList[0].y = y - 200;
            PictureCoordinatesList[1].x = x - 350;
            PictureCoordinatesList[1].y = y - 200;
            PictureCoordinatesList[2].x = x - 400;
            PictureCoordinatesList[2].y = y - 25;
            PictureCoordinatesList[3].x = x + 250;
            PictureCoordinatesList[3].y = y - 25;
            PictureCoordinatesList[4].x = x - 350;
            PictureCoordinatesList[4].y = y + 150;
            PictureCoordinatesList[5].x = x + 200;
            PictureCoordinatesList[5].y = y + 150;
        }

        public void HidePictures(PictureBox[] Pictures)
        {
            for (int i = 0; i < Pictures.Length; i++)
            {
                while (Pictures[i].Height > 0)
                {
                    Pictures[i].Height -= 5;
                    Pictures[i].Width -= 5;
                    Pictures[i].Refresh();
                }
            }

        }

        public void UnhidePictures(PictureBox[] Pictures)
        {
            for (int i = 0; i < PictureCoordinatesList.Length; i++)
            {                
                while (Pictures[i].Height < 150)
                {
                    Pictures[i].Height += 5;
                    Pictures[i].Width += 5;
                    Pictures[i].Left = PictureCoordinatesList[i].x;
                    Pictures[i].Top = PictureCoordinatesList[i].y;
                    Pictures[i].Refresh();
                }                
            }
        }

        #region Picture movement, old code not used

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

                while (!(x == PictureCoordinatesList[i].x && y == PictureCoordinatesList[i].y))
                {
                    toRight = (x < PictureCoordinatesList[i].x);
                    toBottom = (y < PictureCoordinatesList[i].y);
                    int tempX;
                    int tempY;

                    Console.WriteLine("x=" + x + "gebiedpla=" + PictureCoordinatesList[i].x);
                    Console.WriteLine("y=" + y + "gebiedpla=" + PictureCoordinatesList[i].y);

                    tempX = (toRight) ? Convert.ToInt32(x + (PictureCoordinatesList[i].x / x)) : Convert.ToInt32(x - (x / PictureCoordinatesList[i].x));
                    tempY = (toBottom) ? Convert.ToInt32(y + (PictureCoordinatesList[i].y / y)) : Convert.ToInt32(y - (y / PictureCoordinatesList[i].y));

                    x = tempX;
                    if (Pictures[i].Left != PictureCoordinatesList[i].x)
                    {
                        Pictures[i].Left = tempX;
                    }
                    else
                    {
                        x = PictureCoordinatesList[i].x;
                    }
                    y = tempY;
                    if (Pictures[i].Top != PictureCoordinatesList[i].y)
                    {
                        Pictures[i].Top = tempY;
                    }
                    else
                    {
                        y = PictureCoordinatesList[i].y;
                    }

                    Pictures[i].Refresh();
                }

            }
        }

        #endregion
    }
}
