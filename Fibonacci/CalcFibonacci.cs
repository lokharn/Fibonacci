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
            if (powNum == 0) return identityМatrix; 
            if (powNum == 1) return x;
            int n = 15;
            while ((powNum <<= 1) >= 0) n--;
            DoubleMatrix tmp = x;
            while (--n > 0)
                tmp = (tmp * tmp) * (((powNum <<= 1) < 0) ? x : identityМatrix); 
            return tmp;
        }

        //Расчёт числа Фибоначчи по порядковому номеру основан на матричном методе.
        //http://mech.math.msu.su/~shvetz/54/inf/perl-examples/PerlExamples_Fibonacci_Ideas.xhtml
        public static int Fibonacci(int n)
        {
            return IntPower(fibonacciMatrix, (short)(n - 1))._11;
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
