using System;

namespace PocketLib
{
    public class Range<T> where T : IComparable<T>
    {
        public Range(T start, T end)
        {
            if (start.CompareTo(end) > 0)
                throw new Exception();

            Start = start;
            End = end;
        }

        public T Start { get; private set; }
        public T End { get; private set; }

        public bool In(T element)
        {
            if (element.CompareTo(Start) >= 0 && element.CompareTo(End) <= 0)
                return true;
            return false;
        }
    }
}