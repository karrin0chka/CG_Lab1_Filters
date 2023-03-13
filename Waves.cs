using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace КГ_Лаб1_Фильтры
{
    class Waves : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourseColor = sourceImage.GetPixel(x, y);
            int newX = (int)(x + 20 * Math.Sin(Math.PI * (x) / 30));
            if (newX > 0 && newX < sourceImage.Width && y > 0 && y < sourceImage.Height)
            {
                sourseColor = sourceImage.GetPixel(newX, y);
            }

            return Color.FromArgb(sourseColor.R, sourseColor.G, sourseColor.B);

        }
    }
}
