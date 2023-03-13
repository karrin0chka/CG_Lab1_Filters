using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class Sepia : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourseColor = sourceImage.GetPixel(x, y);
            double Intensity = 0.36 * sourseColor.R + 0.36 * sourseColor.G + 0.36 * sourseColor.B;
            int k = 20;
            Color resultColor = Color.FromArgb(
                Clamp((int)(Intensity + 2 * k), 0, 255),
                Clamp((int)(Intensity + 0.5 * k), 0, 255),
                Clamp((int)(Intensity - 1 * k), 0, 255));
            return resultColor;
        }
    }
}
