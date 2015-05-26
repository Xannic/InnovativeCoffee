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
        private Coordinates[] GebiedPlaatsen = new Coordinates[6];
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

                    tempX = (toRight) ? Convert.ToInt32(x + (XMiddle / x)) : Convert.ToInt32(x - (x / XMiddle));
                    tempY = (toBottom) ? Convert.ToInt32(y + (YMiddle / y)) : Convert.ToInt32(y - (y / YMiddle));

                    x = tempX;
                    if (Pictures[i].Left != XMiddle)
                    {
                        Pictures[i].Left = tempX;
                    }
                    else
                    {
                        x = XMiddle;
                    }
                    y = tempY;
                    if (Pictures[i].Top != YMiddle)
                    {
                        Pictures[i].Top = tempY;
                    }
                    else
                    {
                        y = YMiddle;
                    }
                                      
                }
                               
            }
        }

        public void MoveBitchGetInTheWay(PictureBox[] Pictures, int XStart, int YStart)
        {
            Console.WriteLine("Starting move in the way");
            SetCoordinates(XStart, YStart);
            for (int i = 0; i < OrderForm.TotalLandscapes; i++)
            {
                Console.WriteLine("moving picture " + i);
                Pictures[i].Visible = true;
                int x = Pictures[i].Left;
                int y = Pictures[i].Top;
                bool toRight;
                bool toBottom;

                while (!(x == GebiedPlaatsen[i].x && y == GebiedPlaatsen[i].y))
                {
                    toRight = (x < GebiedPlaatsen[i].x);
                    toBottom = (y < GebiedPlaatsen[i].y);
                    int tempX;
                    int tempY;

                    Console.WriteLine("x=" + x + "gebiedpla=" + GebiedPlaatsen[i].x);
                    Console.WriteLine("y=" + y + "gebiedpla=" + GebiedPlaatsen[i].y);

                    tempX = (toRight) ? Convert.ToInt32(x + (GebiedPlaatsen[i].x / x)) : Convert.ToInt32(x - (x / GebiedPlaatsen[i].x));
                    tempY = (toBottom) ? Convert.ToInt32(y + (GebiedPlaatsen[i].y / y)) : Convert.ToInt32(y - (y / GebiedPlaatsen[i].y));

                    x = tempX;
                    if (Pictures[i].Left != GebiedPlaatsen[i].x)
                    {
                        Pictures[i].Left = tempX;
                    }
                    else
                    {
                        x = GebiedPlaatsen[i].x;
                    }
                    y = tempY;
                    if (Pictures[i].Top != GebiedPlaatsen[i].y)
                    {
                        Pictures[i].Top = tempY;
                    }
                    else
                    {
                        y = GebiedPlaatsen[i].y;
                    }

                }

            }
        }

        public void MovePicturesToSide(PictureBox[] Gebieden, int XStart, int YStart) {
            SetCoordinates(XStart,YStart);
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

        public void SetCoordinates(int x, int y) {
            for (int i = 0; i < GebiedPlaatsen.Length; i++) {
                GebiedPlaatsen[i] = new Coordinates();
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

        private static void Swap<T>(ref T lhs, ref T rhs) { T temp; temp = lhs; lhs = rhs; rhs = temp; }
        public static void Line(int Bx, int By, int Ex, int Ey)
        {
            bool steep = Math.Abs(Ey - By) > Math.Abs(Ex - Bx);
            if (steep) { Swap<int>(ref Bx, ref By); Swap<int>(ref Ex, ref Ey); }
            if (Bx > Ex) { Swap<int>(ref Bx, ref Ex); Swap<int>(ref By, ref Ey); }
            int dX = (Ex - Bx), dY = Math.Abs(Ey - By), err = (dX / 2), ystep = (By < Ey ? 1 : -1), y = By;

            for (int x = Bx; x <= Ex; ++x)
            {
                //if (!(steep ? plot(y, x) : plot(x, y))) return;
                err = err - dY;
                if (err < 0) { y += ystep; err += dX; }
            }
        }

        public void JustPlaceIt(PictureBox[] Pictures, int XStart, int YStart)
        {
            SetCoordinates(XStart, YStart);
            for (int i = 0; i < OrderForm.TotalLandscapes; i++)
            {
                Pictures[i].Left = GebiedPlaatsen[i].x;
                Pictures[i].Top = GebiedPlaatsen[i].y;
                Pictures[i].Visible = true;
                Console.WriteLine("placed"+i);
            }
        }

        public void MoveBitchGetInTheWayOne(PictureBox[] Pictures, int XStart, int YStart)
        {
            Console.WriteLine("Starting move in the way");
            SetCoordinates(XStart, YStart);
            for (int i = 0; i < OrderForm.TotalLandscapes; i++)
            {
                Pictures[i].Visible = true;
                int Bx = XStart;
                int By = YStart;
                int Ex = GebiedPlaatsen[i].x;
                int Ey = GebiedPlaatsen[i].y;
                bool steep = Math.Abs(Ey - By) > Math.Abs(Ex - Bx);
                if (steep) { Swap<int>(ref Bx, ref By); Swap<int>(ref Ex, ref Ey); }
                if (Bx > Ex) { Swap<int>(ref Bx, ref Ex); Swap<int>(ref By, ref Ey); }
                int dX = (Ex - Bx), dY = Math.Abs(Ey - By), err = (dX / 2), ystep = (By < Ey ? 1 : -1), y = By;
                
                for (int x = Bx; x <= Ex; ++x)
                {
                    //if (!(steep ? plot(y, x) : plot(x, y))) return;
                    if (steep)
                    {
                        Pictures[i].Left = y;
                        Pictures[i].Top = x;
                    }
                    else
                    {
                        Pictures[i].Left = x;
                        Pictures[i].Top = y;
                        //return;
                    }

                    err = err - dY;
                    if (err < 0) { y += ystep; err += dX; }
                }
                Console.WriteLine("Image " + i + " moved from x=" + Ex + "y=" + Ey + "TOx=" + Pictures[i].Left + "y=" + Pictures[i].Top);
            }
        }
    }
}
