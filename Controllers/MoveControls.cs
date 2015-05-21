using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InovativeCoffeeGUI
{
    class MoveControls
    {
        private Coordinaten[] GebiedPlaatsen = new Coordinaten[6];
        public void MovePicturesToMiddle(PictureBox[] Pictures, int XMiddle, int YMiddle)
        {
            for (int i = 0; i < Pictures.Length; i++)
            {
                int x = Pictures[i].Left;
                int y = Pictures[i].Top;
                while (x != XMiddle)
                {
                    if (x > XMiddle)
                    {
                        x--;
                    }
                    else
                    {
                        x++;
                    }
                    while (y != YMiddle)
                    {
                        if (y > YMiddle)
                        {
                            y--;
                        }
                        else
                        {
                            y++;
                        }
                        Pictures[i].Top = y;
                    }
                    Pictures[i].Left = x;
                }
            }
        }

        public void MoveBitchGetOutTheWay(PictureBox[] Pictures, int XMiddle, int YMiddle)
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
                    
                    if (toRight)
                    {
                        tempX = Convert.ToInt32(x + (XMiddle / x));
                    }
                    else
                    {
                        tempX = Convert.ToInt32(x - (x / XMiddle));
                    }

                    if (toBottom)
                    {
                        tempY = Convert.ToInt32(y + (YMiddle / y));
                    }
                    else
                    {
                        tempY = Convert.ToInt32(y - (y / YMiddle));
                    }

                    x = tempX;
                    if (Pictures[i].Left != XMiddle)
                    {
                        Pictures[i].Left = x;
                    }
                    else
                    {
                        x = XMiddle;
                    }
                    y = tempY;
                    if (Pictures[i].Top != YMiddle)
                    {
                        Pictures[i].Top = y;
                    }
                    else
                    {
                        y = YMiddle;
                    }

                    if (i == 0)
                    {
                        Console.WriteLine("x="+x+"----y="+y);
                        Console.WriteLine(!(x == XMiddle && y == YMiddle));
                    }

                    /*if (x >= y)
                    {
                        // x eerst
                        x = tempX;
                        Pictures[i].Left = x;
                    }
                    else
                    {
                        // y eerst
                        y = tempY;
                        Pictures[i].Top = y;
                    }*/
                }

                
            }
        }

        public void MovePicturesToSide(PictureBox[] Gebieden, int XStart, int YStart) {
            SetCoords(XStart,YStart);
            for (int i = 0; i < OrderForm.TotalLandscapes; i++ )
            {
                Gebieden[i].Visible = true;
                int x = Gebieden[i].Left;
                int y = Gebieden[i].Top;
                while (x != GebiedPlaatsen[i].x) {
                    if (x > GebiedPlaatsen[i].x)
                    {
                        x--;
                    }
                    else
                    {
                        x++;
                    }
                    while (y != GebiedPlaatsen[i].y)
                    {
                        if (y > GebiedPlaatsen[i].y)
                        {
                            y--;
                        }
                        else
                        {
                            y++;
                        }
                        Gebieden[i].Top = y;
                    }
                    Gebieden[i].Left = x;
                }
                

            }
        }

        public void SetCoords(int x, int y) {
            for (int i = 0; i < GebiedPlaatsen.Length; i++) {
                GebiedPlaatsen[i] = new Coordinaten();
            }
            GebiedPlaatsen[0].x = x + 200;
            GebiedPlaatsen[0].y = y - 200;
            GebiedPlaatsen[1].x = x - 350;
            GebiedPlaatsen[1].y = y - 200;
            GebiedPlaatsen[2].x = x - 400;
            GebiedPlaatsen[2].y = y - 25;
            GebiedPlaatsen[3].x = x + 250;
            GebiedPlaatsen[3].y = y - 25;
            GebiedPlaatsen[4].x = x - 350;
            GebiedPlaatsen[4].y = y + 150;
            GebiedPlaatsen[5].x = x + 200;
            GebiedPlaatsen[5].y = y + 150;
        }

    }
}
