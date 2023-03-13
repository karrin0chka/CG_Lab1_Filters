using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class GrayScaleFilter : Filters // черно-белый
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourseColor = sourceImage.GetPixel(x, y);
            int Intensity = (int)(0.36 * sourseColor.R + 0.36 * sourseColor.G + 0.36 * sourseColor.B);
            Color resultColor = Color.FromArgb(
                Clamp(Intensity, 0, 255),
                Clamp(Intensity, 0, 255),
                Clamp(Intensity, 0, 255));
            return resultColor;
        }
    }
}
