using System;

namespace PocketLib
{
    public class Range<T> where T : IComparable<T>
    {
        public Range(T start, T end)
        {
            Start = start;
            End = end;
        }

        public T Start { get;private set; }
        public T End { get;private set; }
    }
}
