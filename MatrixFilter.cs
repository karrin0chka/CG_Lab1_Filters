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
        protected float[,] kegelX = null;
        protected float[,] kegelY = null;
        protected MatrixFilter() {}
        public MatrixFilter(float[,] kegel)
        {
            this.kegel = kegel;
        }
        public MatrixFilter(float[,] kegelX, float[,] kegelY)
        {
            this.kegelX = kegelX;
            this.kegelY = kegelY;
        }

        public void setStructElem(float[,] struct_elem)
        {
            kegel = struct_elem;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            if (kegelX == null)
            {
                int radiusX = kegel.GetLength(0) / 2;
                int radiusY = kegel.GetLength(1) / 2;

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
            else
            {
                int radiusXX = kegelX.GetLength(0) / 2;
                int radiusYY = kegelX.GetLength(1) / 2;

                // перебор окрестности пикселя
                float[] RGBx = new float[3] { 0f, 0f, 0f };
                float[] RGBy = new float[3] { 0f, 0f, 0f };

                for (int i = -radiusYY; i <= radiusYY; i++)
                {
                    for (int j = -radiusXX; j <= radiusXX; j++)
                    {
                        // координаты пикселей-соседей пикселя xy, для которого происходит вычисление
                        int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                        int idY = Clamp(y + i, 0, sourceImage.Height - 1);
                        Color neighborColor = sourceImage.GetPixel(idX, idY);
                        RGBx[0] += neighborColor.R * kegelX[j + radiusXX, i + radiusYY];
                        RGBx[1] += neighborColor.G * kegelX[j + radiusXX, i + radiusYY];
                        RGBx[2] += neighborColor.B * kegelX[j + radiusXX, i + radiusYY];

                        RGBy[0] += neighborColor.R * kegelY[j + radiusXX, i + radiusYY];
                        RGBy[1] += neighborColor.G * kegelY[j + radiusXX, i + radiusYY];
                        RGBy[2] += neighborColor.B * kegelY[j + radiusXX, i + radiusYY];
                    }
                }
                return Color.FromArgb(
                Clamp((int)Math.Sqrt(RGBx[0] * RGBx[0] + RGBy[0] * RGBy[0]), 0, 255),
                Clamp((int)Math.Sqrt(RGBx[1] * RGBx[1] + RGBy[1] * RGBy[1]), 0, 255),
                Clamp((int)Math.Sqrt(RGBx[2] * RGBx[2] + RGBy[2] * RGBy[2]), 0, 255));

            }
           
        }
    }
}
