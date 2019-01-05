//C#
//© Кушнір Б.T. , 2018
using System;

namespace PocketLib
{
    public class Range<T> : IRange<T> where T : IComparable<T>
    {
        public Range(T start, T end)
        {
            if (start.CompareTo(end) > 0)
                throw new Exception();

            Start = start;
            End = end;
        }

        public T End { get; set; }
        public bool? Growing => Start.CompareTo(End) < 0 ? true : Start.CompareTo(End) > 0 ? false : (bool?)null;
        public T Start { get; set; }

        public bool In(T element) => element.CompareTo(Start) >= 0 && element.CompareTo(End) <= 0 ? true : false;
    }
}