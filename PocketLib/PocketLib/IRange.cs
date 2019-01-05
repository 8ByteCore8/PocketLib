//C#
//© Кушнір Б.T. , 2018
using System;

namespace PocketLib
{
    public interface IRange<T> where T : IComparable<T>
    {
        T End { get; set; }
        bool? Growing { get; }
        T Start { get; set; }

        bool In(T element);
    }
}