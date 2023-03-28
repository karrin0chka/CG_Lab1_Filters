using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class MaxFilter : Filters
    {

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor;

            // RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR

            if ((sourceColor.R > sourceColor.G) && (sourceColor.R > sourceColor.B))
            {
                resultColor = Color.FromArgb(Clamp(sourceColor.R, 0, 255),
                0,
                0);
                return resultColor;
            }

            if ((sourceColor.R == sourceColor.G) && (sourceColor.R > sourceColor.B))
            {
                resultColor = Color.FromArgb(Clamp(sourceColor.R, 0, 255),
                Clamp(sourceColor.G, 0, 255),
                0);
                return resultColor;
            }

            if ((sourceColor.R == sourceColor.B) && (sourceColor.R > sourceColor.G))
            {
                resultColor = Color.FromArgb(Clamp(sourceColor.R, 0, 255),
                0,
                Clamp(sourceColor.B, 0, 255));
                return resultColor;
            }

            // GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG

            if ((sourceColor.G > sourceColor.R) && (sourceColor.G > sourceColor.B))
            {
                resultColor = Color.FromArgb(0,
                Clamp(sourceColor.G, 0, 255),
                0);
                return resultColor;
            }

            if ((sourceColor.G == sourceColor.B) && (sourceColor.G > sourceColor.R))
            {
                resultColor = Color.FromArgb(0,
                Clamp(sourceColor.G, 0, 255),
                Clamp(sourceColor.B, 0, 255));
                return resultColor;
            }

            // BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB

            if ((sourceColor.B > sourceColor.R) && (sourceColor.B > sourceColor.G))
            {
                resultColor = Color.FromArgb(0,
                0,
                Clamp(sourceColor.B, 0, 255));
                return resultColor;
            }
            else
                return resultColor = Color.FromArgb(Clamp(sourceColor.R, 0, 255),
                Clamp(sourceColor.G, 0, 255),
                Clamp(sourceColor.B, 0, 255)); ;
        }
    }
}
