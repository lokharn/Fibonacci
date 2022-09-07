using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    internal class DoubleMatrix //Класс реализующий двоичную матрицу
    {
        public int _11, _12, _21, _22;
        public static DoubleMatrix operator *(DoubleMatrix lhs, DoubleMatrix rhs) //Метод умножения двоичных матриц через перегрузку оператора
        {
            return new DoubleMatrix
            {
                _11 = lhs._11 * rhs._11 + lhs._12 * rhs._21,
                _12 = lhs._11 * rhs._12 + lhs._12 * rhs._22,
                _21 = lhs._21 * rhs._11 + lhs._22 * rhs._21,
                _22 = lhs._21 * rhs._12 + lhs._22 * rhs._22
            };
        }
    }
}
