using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class SobelOperator : MatrixFilter  // выделение контура, приближенное вычисление градиента
    {
        public SobelOperator()
        {
            const int size = 3;
            kegelX = new float[size, size] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            kegelY = new float[size, size] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
        }
    }
}
