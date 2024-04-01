using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1
{
    sealed class OneDimensionalArray<T> : IBaseArray<T>
    {
        const int based_size = 5;
        int array_razmer;
        private int current_size = 0;
        private T[] arr;

        public OneDimensionalArray(int array_razmer)
        {
            arr = new T[array_razmer];
        }
        public OneDimensionalArray() { }

        public void Add(T element)
        {
            if (current_size >= array_razmer)
            {
                array_razmer = array_razmer * 2 + 1;
                Array.Resize(ref arr, array_razmer);
            }
            arr[current_size] = element;
            current_size++;
        }

        public void RemoveEl(T element)
        {
            current_size--;

            int index = FindIndex(element);

            if (index != -1)
            {
                Array.Copy(arr, index + 1, arr, index, array_razmer - index);
            }
        }

        public int Length(Func<T, bool> condition)
        {
            int ans = 0;
            for (int i = 0; i < array_razmer; i++)
            {
                if (condition(arr[i]))
                {
                    ans += 1;
                }
            }
            return ans;
        }
        public int Length()
        {
            return current_size;
        }
        public T Min()
        {
            Comparer<T> comparer = Comparer<T>.Default;

            T min = arr[0];

            for (int i = 1; i < array_razmer; i++)
            {
                if (comparer.Compare(arr[i], min) == -1)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        public void Sort()
        {
            Comparer<T> comparer = Comparer<T>.Default;
            for (int i = 1; i < array_razmer; i++)
            {
                int j = i;

                T k = arr[i];

                while (j > 0 && comparer.Compare(arr[j - 1], k) > 0)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = k;
            }
        }
        public TResult Min<TResult>(Func<T, TResult> projectia)
        {
            ArgumentNullException.ThrowIfNull(projectia);

            Comparer<TResult> comparer = Comparer<TResult>.Default;

            TResult min = projectia(arr[0]);

            for (int i = 1; i < array_razmer; i++)
            {
                if (comparer.Compare(projectia(arr[i]), min) < 0)
                {
                    min = projectia(arr[i]);
                }
            }
            return min;
        }
        public T[] Get(int index, int count)
        {
            T[] arrayResult = new T[count];
            int index1 = 0;

            for (int i = index; i < count + 1; i++)
            {
                arrayResult[index1++] = arr[i];
            }
            return arrayResult;
        }

        public T Max()
        {
            Comparer<T> comparer = Comparer<T>.Default;

            T max = arr[0];

            for (int i = 1; i < array_razmer; i++)
            {
                if (comparer.Compare(arr[i], max) > 0)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        public TResult Max<TResult>(Func<T, TResult> projectia)
        {
            ArgumentNullException.ThrowIfNull(projectia);

            Comparer<TResult> comparer = Comparer<TResult>.Default;

            TResult max = projectia(arr[0]);

            for (int i = 1; i < array_razmer; i++)
            {
                if (comparer.Compare(projectia(arr[i]), max) > 0)
                {
                    max = projectia(arr[i]);
                }
            }
            return max;
        }


        public bool Check(T element)
        {
            return FindIndex(element) != -1;
        }

        public void Reverse()
        {
            T[] _array = new T[array_razmer];

            for (int i = 0; i < array_razmer; i++)
            {
                _array[i] = arr[array_razmer - i - 1];
            }

            arr = _array;
        }
        public bool IfAny(Func<T, bool> condition)
        {
            ArgumentNullException.ThrowIfNull(condition);

            for (int i = 0; i < array_razmer; i++)
            {
                if (condition(arr[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < array_razmer; i++)
            {
                action(arr[i]);
            }
        }


        public T Find(Func<T, bool> condition)
        {
            return arr[FindIndex(condition)];
        }

        public T[] FindAll(Func<T, bool> condition)
        {
            T[] elements = new T[Length(condition)];
            int index = 0;

            for (int i = 0; i < array_razmer; i++)
            {
                if (condition(arr[i]))
                {
                    elements[index] = arr[i];
                    index++;
                }
            }

            return elements;
        }

        public T[] FindAll<TResult>()
        {
            T[] elements = new T[based_size];
            int index = 0;

            for (int i = 0; i < array_razmer; i++)
            {
                if (arr[i] is TResult)
                {
                    elements[index] = arr[i];
                    index++;
                }
            }

            Array.Resize(ref elements, index);
            return elements;
        }

        private int FindIndex(Func<T, bool> condition)
        {
            for (int i = 0; i < current_size; i++)
            {
                if (condition(arr[i]))
                {
                    return i;
                }
            }
            return -1;
        }
        private int FindIndex(T element)
        {
            for (int i = 0; i < array_razmer; i++)
            {
                if (element.Equals(arr[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public TResult[] Project<TResult>(Func<T, TResult> project)
        {
            TResult[] _array = new TResult[current_size];

            for (int i = 0; i < current_size; i++)
            {
                _array[i] = project(arr[i]);
            }

            return _array;
        }

        public void Print()
        {
            foreach (T element in arr)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
        public void Print(T[] _array)
        {
            foreach (T element in _array)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
    }
}
