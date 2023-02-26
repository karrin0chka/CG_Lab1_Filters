using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class GaussianBlur : MatrixFilter
    {
        public GaussianBlur()
        {
            createGaussianKegel(3, 2);
        }

        // рассчитывает ядро преобразования
        public void createGaussianKegel(int radius, float sigma)
        {
            // определяем размер ядра
            int size = 2 * radius + 1;
            // создаем ядро фильтра
            kegel = new float[size, size];
            // коэффициент нормировки ядра
            float norm = 0;
            // рассчитываем ядро линейного фильтра
            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    kegel[i + radius, j + radius] = (float) (Math.Exp(-(i * i + j * j) / (sigma * sigma)));
                    norm += kegel[i + radius, j + radius];  
                }
            // нормируем ядро
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kegel[i, j] /= norm;
        }
    }
}
