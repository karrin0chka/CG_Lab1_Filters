using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class Borders : MatrixFilter // выделение границ оператор Щарра
    {
        public Borders()
        {
            const int size = 3;
            kegelX = new float[size, size] { { 3, 10, 3}, { 0, 0, 0 }, { -3, -10, -3 } };
            kegelY = new float[size, size] { { 3, 0, -3 }, { 10, 0, -10 }, { 3, 0, -3 } };
        }
    }
}
