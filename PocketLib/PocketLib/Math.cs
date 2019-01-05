//C#
//© Кушнір Б.T. , 2018
using System;

namespace PocketLib
{
    public static class Math
    {
        public static bool InRange<T>(this T element, Range<T> range) where T : IComparable<T> => element.CompareTo(range.Start) >= 0 && element.CompareTo(range.End) <= 0 ? true : false;

        public static bool InRange<T>(this T element, T start, T end) where T : IComparable<T> => element.CompareTo(start) >= 0 && element.CompareTo(end) <= 0 ? true : false;

        public static Range<T> To<T>(this T start, T end) where T : IComparable<T> => new Range<T>(start, end);
    }
}