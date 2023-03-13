using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class Glass : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourseColor = sourceImage.GetPixel(x, y);
            Random random = new Random();
            double r1 = random.NextDouble();
            double r2 = random.NextDouble();
            int newX = (int)(x + (r1 - 0.5) * 10);
            int newY = (int)(y + (r2 - 0.5) * 10);
            if (newX > 0 && newX < sourceImage.Width && newY > 0 && newY < sourceImage.Height)
            {
                sourseColor = sourceImage.GetPixel(newX, newY);
            }

            return Color.FromArgb(sourseColor.R, sourseColor.G, sourseColor.B);
        }
    }
}
