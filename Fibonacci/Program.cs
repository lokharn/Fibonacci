using Fibonacci;

Console.WriteLine("X = ");
int x = int.Parse(Console.ReadLine()); //Получить значение X.
Console.WriteLine("N = ");
int n = int.Parse(Console.ReadLine()); //Получить значение N.

var k = CalcFibonacci.StartNumber(x); //Рассчитать порядковый номер числа Фибоначчи от значения которого начинать ряд.

for (int i = 0; i < n; i++) //Последовательный вывод всех чисел от заданного порядкового номера.
{
    Console.Write($"{CalcFibonacci.Fibonacci(k)} ");
    k++;
}
Console.ReadKey();

