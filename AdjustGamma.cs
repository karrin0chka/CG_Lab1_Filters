using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class AdjustGamma : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double gammacorrection = 0.5;
            Color sourseColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                Clamp((int)(255 * Math.Pow(sourseColor.R / 255.0, gammacorrection)), 0, 255),
                Clamp((int)(255 * Math.Pow(sourseColor.G / 255.0, gammacorrection)), 0, 255),
                Clamp((int)(255 * Math.Pow(sourseColor.B / 255.0, gammacorrection)), 0, 255));
            return resultColor;
        }
    }
}
