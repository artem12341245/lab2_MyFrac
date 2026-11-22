using System;
using System.Text;
using lab2_MyFrac;

namespace lab4block1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Введіть перший дріб. Спочатку чисельник, потім знаменник (через Enter):");
            long nom1 = long.Parse(Console.ReadLine());
            long denom1 = long.Parse(Console.ReadLine());
            MyFrac f1 = new MyFrac(nom1, denom1);

            Console.WriteLine("Введіть другий дріб. Спочатку чисельник, потім знаменник (через Enter):");
            long nom2 = long.Parse(Console.ReadLine());
            long denom2 = long.Parse(Console.ReadLine());
            MyFrac f2 = new MyFrac(nom2, denom2);

            Console.WriteLine("Введіть значення n для останніх двох завдань:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Вами було введено дроби:");
            Console.WriteLine(f1);
            Console.WriteLine(f2);

            Console.WriteLine("Ваші дроби з виділеною цілою частиною:");
            Console.WriteLine(f1.ToStringWithIntPart());
            Console.WriteLine(f2.ToStringWithIntPart());

            Console.WriteLine("Ваші дроби як дійсні значення:");
            Console.WriteLine(f1.DoubleValue());
            Console.WriteLine(f2.DoubleValue());

            Console.WriteLine("Результат додавання ваших дробів:");
            Console.WriteLine((f1 + f2).Normalize());

            Console.WriteLine("Результат віднімання ваших дробів:");
            Console.WriteLine((f1 - f2).Normalize());

            Console.WriteLine("Результат множення ваших дробів:");
            Console.WriteLine((f1 * f2).Normalize());

            Console.WriteLine("Результат ділення ваших дробів:");
            Console.WriteLine((f1 / f2).Normalize());

            Console.WriteLine("Результат 1/(1*2) + 1/(2*3) + 1/(3*4) + ... + 1/(n*(n+1)):");
            Console.WriteLine(CalcExpr1(n).Normalize());

            Console.WriteLine("Результат (1 - 1/4)*(1 - 1/9)*(1 - 1/16)*...*(1 - 1/n^2):");
            Console.WriteLine(CalcExpr2(n).Normalize());
        }

        static MyFrac CalcExpr1(int n)
        {
            MyFrac result = new MyFrac(0, 1);
            for (int i = 1; i <= n; i++)
            {
                long denom = (long)i * (i + 1);
                result = result + new MyFrac(1, denom);
            }
            return result;
        }

        static MyFrac CalcExpr2(int n)
        {
            MyFrac result = new MyFrac(1, 1);
            MyFrac one = new MyFrac(1, 1);
            for (int i = 2; i <= n; i++)
            {
                long sq = (long)i * i;
                MyFrac term = one - new MyFrac(1, sq);
                result = result * term;
            }
            return result;
        }
    }
}