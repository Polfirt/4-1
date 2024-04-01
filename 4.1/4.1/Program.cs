using System;


namespace _4._1
{
    class Program
    {
        static void Main()
        {
            static void Main()
            {
                Console.WriteLine("Введите ёмкость массива или же 0 если хотите по умолчанию");
                int n = int.Parse(Console.ReadLine());

                OneDimensionalArray<int> sobr_arr = (n == 0) ? new() : new(n);

                Console.WriteLine("Введите длину массива");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("Вводите значения элемента по одному");
                for (int i = 0; i < num; i++)
                {
                    sobr_arr.Add(int.Parse(Console.ReadLine()));
                }
                Console.WriteLine("Вывод с использованием метода ForEach");
                sobr_arr.ForEach((j) => Console.WriteLine(j));

                Console.WriteLine("Первый элемент массива, который нам подойдет по условию");
                Console.WriteLine(sobr_arr.Find(j => j % 5 == 0));

                Console.WriteLine("Какой элемент вы хотите 'изгнать' из этого массива? Введите его");
                sobr_arr.RemoveEl(int.Parse(Console.ReadLine()));
                sobr_arr.Print();

                Console.WriteLine("Введите значение, которое хотите найти в этом массиве");
                Console.WriteLine(sobr_arr.Check(int.Parse(Console.ReadLine())));

                Console.WriteLine("Максимальный элемент массива");
                Console.WriteLine(sobr_arr.Max());

                Console.WriteLine("Минимальный элемент массива");
                Console.WriteLine(sobr_arr.Min());

                Console.WriteLine("Все эллементы массива, которые > 6");
                sobr_arr.Print(sobr_arr.FindAll(j => j > 6));

                Console.WriteLine("Все элементы массива, которые попадаются не один раз");
                sobr_arr.Print(sobr_arr.FindAll<double>());

                

                
            }
        }
    }
}