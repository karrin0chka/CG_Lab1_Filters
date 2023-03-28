using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class Glass : MatrixFilter
    {
        Random rand = new Random();
        
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float resultR1 = 0;
            float resultG1 = 0;
            float resultB1 = 0;

            kegel = new float[3, 3] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
            int radiusX = kegel.GetLength(0) / 2;
            int radiusY = kegel.GetLength(1) / 2;

            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp((int)(x + 10 * (rand.NextDouble() - 0.5)), 0, sourceImage.Width - 1); //пиксели - соседи
                    int idY = Clamp((int)(y + 10 * (rand.NextDouble() - 0.5)), 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR1 += neighborColor.R * kegel[k + radiusX, l + radiusY];
                    resultG1 += neighborColor.G * kegel[k + radiusX, l + radiusY];
                    resultB1 += neighborColor.B * kegel[k + radiusX, l + radiusY];
                }
            return Color.FromArgb(Clamp((int)resultR1, 0, 255),
            Clamp((int)resultG1, 0, 255),
            Clamp((int)resultB1, 0, 255));
        }
    }
}
