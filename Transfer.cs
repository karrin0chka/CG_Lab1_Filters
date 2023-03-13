using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class Transfer : Filters // сдвиг 
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 50;
            int l = 30;
            Color sourseColor = new Color();
            if (x + k > 0 && x + k < sourceImage.Width && y + l > 0 && y + l < sourceImage.Height)
                sourseColor = sourceImage.GetPixel(x + k, y + l);


            return Color.FromArgb(
                Clamp(sourseColor.R, 0, 255),
                Clamp(sourseColor.G, 0, 255),
                Clamp(sourseColor.B, 0, 255));
        }
    }
}
