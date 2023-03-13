using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace КГ_Лаб1_Фильтры
{
    class Narrowing : MatrixFilter  // сужение
    {
        protected bool[,] mask;

        public Narrowing()
        {
            mask = new bool[3, 3] {{false, true, false},
                                    {true, true, true},
                                    {false, true, false}};
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int Width = sourceImage.Width;
            int Height = sourceImage.Height;

            int radiusX = mask.GetLength(0) / 2;
            int radiusY = mask.GetLength(1) / 2;

            Color min = Color.White;
            for (int j = -radiusY; j <= radiusY; j++)
            {
                for (int i = -radiusX; i <= radiusX; i++)
                {
                    if (x + i < 0 || x + i >= Width || y + j < 0 || y + j >= Height)
                        continue;
                    if (mask[i + radiusX, j + radiusY] && (sourceImage.GetPixel(x + i, y + j).ToArgb() < min.ToArgb()))
                        min = sourceImage.GetPixel(x + i, y + j);
                }
            }
            return min;
        }
    }
}
