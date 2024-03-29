﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    internal class PerfectReflector : Filters
    {
        protected double maxR = 0;
        protected double maxG = 0;
        protected double maxB = 0;
        public PerfectReflector(Bitmap sourceImage)
        {
            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    if (maxR < sourceImage.GetPixel(x, y).R)
                        maxR = sourceImage.GetPixel(x, y).R;
                    if (maxG < sourceImage.GetPixel(x, y).G)
                        maxG = sourceImage.GetPixel(x, y).G;
                    if (maxB < sourceImage.GetPixel(x, y).B)
                        maxB = sourceImage.GetPixel(x, y).B;
                }
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourseColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                Clamp((int)(sourseColor.R * (255 / maxR)), 0, 255),
                Clamp((int)(sourseColor.G * (255 / maxG)), 0, 255),
                Clamp((int)(sourseColor.B * (255 / maxB)), 0, 255));
            return resultColor;
        }
    }
}
