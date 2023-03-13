using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace КГ_Лаб1_Фильтры
{
    class Extension : MatrixFilter // расширение
    {
        public Extension()
        {
            const int size = 3; 
            kegel = new float[size, size] { { 0, 1, 0}, { 1, 1, 1}, { 0, 1, 0} };
        }
    }
}
