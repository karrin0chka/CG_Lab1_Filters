using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class GlowingEdges : MatrixFilter // светящиеся края
    {
        public GlowingEdges(Bitmap sourceImage)
        {
            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    sourceImage.SetPixel(x, y, createMedianFilter(sourceImage, x, y));
                }
            }
            
        }

        private Color createMedianFilter(Bitmap sourceImage, int x, int y)
        {
            int Width = sourceImage.Width;
            int Height = sourceImage.Height;

            int radiusX = 3;
            int radiusY = 3;

            List<int> RGBcolors = new List<int>();

            for (int j = -radiusY / 2; j <= radiusY / 2; j++)
            {
                for (int i = -radiusX / 2; i <= radiusX / 2; i++)
                {
                    if (x + i < 0 || x + i >= Width || y + j < 0 || y + j >= Height)
                        continue;

                    RGBcolors.Add(sourceImage.GetPixel(x + i, y + j).ToArgb());
                }
            }
            RGBcolors.Sort();
            return Color.FromArgb(RGBcolors[RGBcolors.Count / 2]);
        }


    }
}
