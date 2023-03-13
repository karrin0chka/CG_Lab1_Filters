using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    // Эти расчёты не создают новых значений, и соседний пиксель вне выборки не повлияет на результат. Поэтому этот фильтр сохраняет
    // границы и скругляет углы. Его используют для уменьшения шума, особенно «шума соли и перца», и для удаления царапин на фото.
    class MedianFilter : MatrixFilter // Медианный фильтр радиусом r –выбор медианы среди пикселей в окрестности [-r,r]+ текущий.
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
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