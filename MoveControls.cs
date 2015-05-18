﻿using System;
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

        public void MovePicturesToSide(PictureBox[] Gebieden, int XStart, int YStart) {
            SetCoords(XStart,YStart);
            for (int i = 0; i < Gebieden.Length; i++ )
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
                    Gebieden[i].Left = x;
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
            }
        }

        private void SetCoords(int x, int y) {
            for (int i = 0; i < GebiedPlaatsen.Length; i++) {
                GebiedPlaatsen[i] = new Coordinaten();
            }
            GebiedPlaatsen[0].x = x + 250;
            GebiedPlaatsen[0].y = y - 175;
            GebiedPlaatsen[1].x = x - 250;
            GebiedPlaatsen[1].y = y - 175;
            GebiedPlaatsen[2].x = x - 300;
            GebiedPlaatsen[2].y = y;
            GebiedPlaatsen[3].x = x + 300;
            GebiedPlaatsen[3].y = y;
            GebiedPlaatsen[4].x = x - 250;
            GebiedPlaatsen[4].y = y + 175;
            GebiedPlaatsen[5].x = x + 250;
            GebiedPlaatsen[5].y = y + 175;

        }

    }
}
