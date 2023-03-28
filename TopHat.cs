using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class TopHat : Filters
    {

        Bitmap imageOp;
        public TopHat(Bitmap imageOp)
        {
            this.imageOp = imageOp;        
        }
        
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            
            Color sourseColor = sourceImage.GetPixel(x, y);
            Color OpColor = imageOp.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                Clamp(sourseColor.R - OpColor.R, 0, 255),
                Clamp(sourseColor.G - OpColor.G, 0, 255),
                Clamp(sourseColor.B - OpColor.B, 0, 255));
            return resultColor;
        }
    }
}
