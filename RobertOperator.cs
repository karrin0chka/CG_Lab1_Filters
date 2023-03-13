using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class RobertOperator : MatrixFilter  // выделение контура, приближенное вычисление градиента
    {
        public RobertOperator()
        {
            const int size = 2;
            kegelX = new float[size, size] { { -1, 0 }, { 0, 1 } };
            kegelY = new float[size, size] { { 0, -1 }, { 1, 0} };
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusXX = kegelX.GetLength(0) / 2;
            int radiusYY = kegelX.GetLength(1) / 2;

            // перебор окрестности пикселя
            float[] RGBx = new float[3] { 0f, 0f, 0f };
            float[] RGBy = new float[3] { 0f, 0f, 0f };

            for (int i = 0; i <= radiusYY; i++)
            {
                for (int j = 0; j <= radiusXX; j++)
                {
                // координаты пикселей-соседей пикселя xy, для которого происходит вычисление
                    int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + i, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    RGBx[0] += neighborColor.R * kegelX[j, i];
                    RGBx[1] += neighborColor.G * kegelX[j, i];
                    RGBx[2] += neighborColor.B * kegelX[j, i];

                    RGBy[0] += neighborColor.R * kegelY[j, i];
                    RGBy[1] += neighborColor.G * kegelY[j, i];
                    RGBy[2] += neighborColor.B * kegelY[j, i];

                }
            }
            return Color.FromArgb(
            Clamp((int)Math.Sqrt(RGBx[0] * RGBx[0] + RGBy[0] * RGBy[0]), 0, 255),
            Clamp((int)Math.Sqrt(RGBx[1] * RGBx[1] + RGBy[1] * RGBy[1]), 0, 255),
            Clamp((int)Math.Sqrt(RGBx[2] * RGBx[2] + RGBy[2] * RGBy[2]), 0, 255));
        }
    }
}
