using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    internal class CalcFibonacci
    {
        private static readonly DoubleMatrix fibonacciMatrix = new DoubleMatrix { _11 = 1, _12 = 1, _21 = 1 }; 
        private static readonly DoubleMatrix identityМatrix = new DoubleMatrix { _11 = 1, _22 = 1 };

        //В методе используется алгоритм целочисленного возведения в степень
        //https://www.johndcook.com/blog/2008/12/10/fast-exponentiation/
        public static DoubleMatrix IntPower(DoubleMatrix x, short powNum)
        {
            if (powNum == 0) return identityМatrix; //Возвращает 0, если возведение в нулевую степень.
            if (powNum == 1) return x; //Возвращает исходную матрицу, если возведение в первую степень. 
            int n = 15;
            while ((powNum <<= 1) >= 0) //Побитовый сдвиг влево для нахождения нужного количества итераций.
            {
                n--; 
            }
            DoubleMatrix tempMatrix = x;
            while (--n > 0)
            {
                tempMatrix = (tempMatrix * tempMatrix) * (((powNum <<= 1) < 0) ? x : identityМatrix); //Расчёт по формуле целочисленного возведения в степень.
            }                
            return tempMatrix;
        }

        //Расчёт числа Фибоначчи по порядковому номеру основан на матричном методе.
        //http://mech.math.msu.su/~shvetz/54/inf/perl-examples/PerlExamples_Fibonacci_Ideas.xhtml
        public static int Fibonacci(int n)
        {
            return IntPower(fibonacciMatrix, (short)(n - 1))._11; //Возврат элемента первой строки первого столбца, содержащего результат.
        }

        public static int StartNumber(int innerBorder)
        {
            int k = 0;
            while (CalcFibonacci.Fibonacci(k) <= innerBorder)
            {
                k++;
            }
            return k;
        }

    }
}
