using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1
{
    interface IBaseArray<T> : IPrintable
    {
        void Add(T element);
        int Length();
        int Length(Func<T, bool> condition);
        void RemoveEl(T element);

        bool Check(T element);
        void ForEach(Action<T> action);

        TResult[] Project<TResult>(Func<T, TResult> project);

        void Sort();

        void Reverse();

        T[] FindAll(Func<T, bool> condition);

        T[] FindAll<TResult>();

        T[] Get(int index, int count);

        T Max();

        T Min();

        TResult Max<TResult>(Func<T, TResult> projectia);

        TResult Min<TResult>(Func<T, TResult> projectia);

        T Find(Func<T, bool> condition);

        bool IfAny(Func<T, bool> condition);
    }
}