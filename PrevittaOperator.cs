using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class PrevittaOperator : MatrixFilter
    {
        public PrevittaOperator()
        {
            const int size = 3;
            kegelX = new float[size, size] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
            kegelY = new float[size, size] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
        }
    }
}
