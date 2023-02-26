using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class MatrixFilter : Filters
    {
        protected float[,] kegel = null;
        protected MatrixFilter()
        {
        }
        public MatrixFilter(float[,] kegel)
        {
            this.kegel = kegel;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            //радиусы фильтра на основании матрицы 
            int radiusX = kegel.GetLength(0) / 2;
            int radiusY = kegel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            // перебор окрестности пикселя
            for (int l = -radiusY; l <= radiusY; l++) 
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    // координаты пикселей-соседей пикселя xy, для которого происходит вычисление
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kegel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kegel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kegel[k + radiusX, l + radiusY];
                }
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255));
        }
    }
}
