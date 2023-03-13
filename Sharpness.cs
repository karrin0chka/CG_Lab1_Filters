using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ_Лаб1_Фильтры
{
    class Sharpness : MatrixFilter // резкость
    {
        public Sharpness()
        {
            const int sizeX = 3;
            const int sizeY = 3;
            kegel = new float[sizeX, sizeY] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
        }
    }
}
