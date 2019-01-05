//C#
//© Кушнір Б.T. , 2018
using System;
using System.Collections.Generic;
using System.Linq;

namespace PocketLib
{
    public static class Collections
    {
        public static IEnumerable<T> Add<T>(this IEnumerable<T> source, params T[] newItems)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (newItems == null)
                throw new ArgumentNullException(nameof(newItems));

            List<T> list = source.ToList();
            list.AddRange(newItems);
            return list.ToArray();
        }

        public static void QuickSort<T>(this IEnumerable<T> source, bool reverse = false) where T : IComparable<T>
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            T[] array = source.ToArray();

            if (array.Length < 2)
                return;

            int c;
            if (reverse)
                c = PartitionR(array, 0, array.Length - 1);
            else
                c = Partition(array, 0, array.Length - 1);

            QuickSort(array, 0, c - 1, reverse);
            QuickSort(array, c + 1, array.Length - 1, reverse);
        }

        public static void QuickSort<T>(this T[] array, bool reverse) where T : IComparable<T>
        {
            if (array.Length < 2)
                return;

            int c;
            if (reverse)
                c = PartitionR(array, 0, array.Length - 1);
            else
                c = Partition(array, 0, array.Length - 1);

            QuickSort(array, 0, c - 1, reverse);
            QuickSort(array, c + 1, array.Length - 1, reverse);
        }

        private static int Partition<T>(T[] array, int first, int last) where T : IComparable<T>
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int i = first;
            for (int j = first; j <= last; j++)
                if (array[j].CompareTo(array[last]) < 0)
                {
                    T t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                    i++;
                }
            return i - 1;
        }

        private static int PartitionR<T>(T[] array, int first, int last) where T : IComparable<T>
        {
            int i = first;
            for (int j = first; j <= last; j++)
                if (array[j].CompareTo(array[last]) > 0)
                {
                    T t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                    i++;
                }
            return i - 1;
        }

        private static void QuickSort<T>(T[] array, int first, int last, bool reverse) where T : IComparable<T>
        {
            if (first >= last)
                return;

            int c;
            if (reverse)
                c = PartitionR(array, first, last);
            else
                c = Partition(array, first, last);

            QuickSort(array, first, c - 1, reverse);
            QuickSort(array, c + 1, last, reverse);
        }
    }
}