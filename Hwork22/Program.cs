using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Hwork22
{
    class Program
    {
        static int[] m;
        static void Main(string[] args)
        {
            Console.Write("Введите размерность массива: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            m = new int[n];
            Console.Write("Массив чисел: ");
            for (int i = 0; i < n; i++)
            {
                m[i] = random.Next(-99, 99);
                Console.Write($"{m[i]}\t");
                Thread.Sleep(10);
            }
            Console.WriteLine();
            Task task1 = new Task(Sum);
            Task task2 = task1.ContinueWith(Max);
            task1.Start();
            task2.Wait();
            Console.ReadKey();
        }
        static void Sum()
        {
            int[] array = m;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += m[i];
            }
            Console.WriteLine($"Сумма чисел: {sum}");
        }
        static void Max(Task task)
        {
            int[] array = m;
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (m[i] > max)
                {
                    max = m[i];
                }
            }
            Console.WriteLine($"Максимальное число: {max}");
        }
    }
}
