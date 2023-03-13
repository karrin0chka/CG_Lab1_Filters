using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class LinearStretch : Filters // линейная коррекция; растяжение контрастности
    {
        double maxR = 0;
        double maxG = 0;
        double maxB = 0;
        double minR = 255;
        double minG = 255;
        double minB = 255;
        public LinearStretch(Bitmap sourceImage)
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

                    if (minR > sourceImage.GetPixel(x, y).R)
                        minR = sourceImage.GetPixel(x, y).R;
                    if (minG > sourceImage.GetPixel(x, y).G)
                        minG = sourceImage.GetPixel(x, y).G;
                    if (minB > sourceImage.GetPixel(x, y).B)
                        minB = sourceImage.GetPixel(x, y).B;
                }
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourseColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                Clamp((int)((sourseColor.R - minR) * (255 - 0) / (maxR - minR)), 0, 255),
                Clamp((int)((sourseColor.G - minG) * (255 - 0) / (maxG - minG)), 0, 255),
                Clamp((int)((sourseColor.B - minB) * (255 - 0) / (maxB - minB)), 0, 255));
            return resultColor;
        }
    }
}
