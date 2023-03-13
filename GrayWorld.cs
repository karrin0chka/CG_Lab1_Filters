using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class GrayWorld : Filters
    {
        int R = 0;
        int G = 0;
        int B = 0;
        int Avg = 0;
        
        public GrayWorld(Bitmap sourceImage)
        {
            int N = sourceImage.Width * sourceImage.Height;
            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    R += sourceImage.GetPixel(x, y).R;
                    G += sourceImage.GetPixel(x, y).G;
                    B += sourceImage.GetPixel(x, y).B;
                }
            R /= N;
            G /= N;
            B /= N;
            Avg = (R + G + B) / 3;
           
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourseColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                Clamp(sourseColor.R * Avg / R, 0, 255),
                Clamp(sourseColor.G * Avg / G, 0, 255),
                Clamp(sourseColor.B * Avg / B, 0, 255));
            return resultColor;
            
        }
    }
}
