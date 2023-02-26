using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class Blur : MatrixFilter
    {
        public Blur()
        {
            int sizeX = 3;
            int sizeY = 3;
            kegel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    kegel[i, j] = 1.0f / (float)(sizeX * sizeY);
        }
    }
}
