using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class Grad : MatrixFilter
    {
        public Bitmap processImageGrad(Bitmap pic1, Bitmap pic2)
        {
            Bitmap resultImage = new Bitmap(pic1.Width, pic1.Height);
            for (int x = 0; x < resultImage.Width; x++)
            {
                for (int y = 0; y < resultImage.Height; y++)
                {
                    resultImage.SetPixel(x, y, Color.FromArgb(
                    Clamp(pic1.GetPixel(x, y).R - pic2.GetPixel(x, y).R, 0, 255),
                    Clamp(pic1.GetPixel(x, y).G - pic2.GetPixel(x, y).G, 0, 255),
                    Clamp(pic1.GetPixel(x, y).B - pic2.GetPixel(x, y).B, 0, 255)));
                }
            }

            return resultImage;
        }
    }
}
