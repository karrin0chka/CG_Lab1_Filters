using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class MotionBlur : MatrixFilter // размытие в движении
    {
        public MotionBlur()
        {
            const int size = 7;
            kegel = new float[size, size];
            for (int i = 0; i < size; i++)
                kegel[i, i] = 1.0f / size;
        }
    }
}
