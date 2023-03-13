using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace КГ_Лаб1_Фильтры
{
	abstract class Filters
	{
		public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
		{
			Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
			for (int i = 0; i < sourceImage.Width; i++)
			{
				// сигнализирует о текущем прогрессе
				worker.ReportProgress((int)((float)i / resultImage.Width * 100));
				if (worker.CancellationPending)
					return null;

				for (int j = 0; j < sourceImage.Height; j++)
					resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage,i, j));
			}
			return resultImage;
		}

		public Bitmap processImage(Bitmap sourceImage)
		{
			Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
			for (int i = 0; i < sourceImage.Width; i++)
			{
				for (int j = 0; j < sourceImage.Height; j++)
					resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
			}
			return resultImage;
		}

		//вычисляет значение пикселя отфильтрованного изображения
		protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int i, int j);

		//приводит значения цветов к допустимому диапазону
		public int Clamp(int value, int min, int max)
		{
			if (value < min)
				return min;
			if (value > max)
				return max;
			return value;
		}
	}
}
