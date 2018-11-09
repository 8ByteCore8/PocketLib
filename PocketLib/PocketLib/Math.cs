using System;

namespace PocketLib
{
    public static class Math
    {
        public static bool InRange<T>(this T element, Range<T> range)where T:IComparable<T>
        {
            if (element.CompareTo(range.Start) >= 0 && element.CompareTo(range.End) <= 0)
                return true;
            return false;
        }

        public static bool InRange<T>(this T element, T start,T end) where T : IComparable<T>
        {
            if (element.CompareTo(start) >= 0 && element.CompareTo(end) <= 0)
                return true;
            return false;
        }

        public static Range<T> To<T>(this T start, T end) where T : IComparable<T>
        {
            return new Range<T>(start, end);
        }
    }
}
