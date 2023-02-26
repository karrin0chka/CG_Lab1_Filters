using System.Drawing;

namespace КГ_Лаб1_Фильтры
{
	internal class Invert : Filters
	{
		protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
		{
			Color sourseColor = sourceImage.GetPixel(x, y);
			Color resultColor = Color.FromArgb(255 - sourseColor.R, 255 - sourseColor.G, 255 - sourseColor.B);
			return resultColor;
			
		}
	}
}
