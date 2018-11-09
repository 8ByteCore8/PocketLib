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

        public static void QuickSort<T>(this IEnumerable<T> source, bool Reverse = false) where T : IComparable<T>
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            T[] array = source.ToArray();

            if (array.Length < 2) return;

            int c;
            if (Reverse)
                c = PartitionR(array, 0, array.Length - 1);
            else
                c = Partition(array, 0, array.Length - 1);

            QuickSort(array, 0, c - 1, Reverse);
            QuickSort(array, c + 1, array.Length - 1, Reverse);
        }

        public static void QuickSort<T>(this T[] Array, bool Reverse) where T : IComparable<T>
        {
            if (Array.Length < 2) return;

            int c;
            if (Reverse)
                c = PartitionR(Array, 0, Array.Length - 1);
            else
                c = Partition(Array, 0, Array.Length - 1);

            QuickSort(Array, 0, c - 1, Reverse);
            QuickSort(Array, c + 1, Array.Length - 1, Reverse);
        }

        private static void QuickSort<T>(T[] Array, int First, int Last, bool Reverse) where T : IComparable<T>
        {
            if (First >= Last) return;

            int c;
            if (Reverse)
                c = PartitionR(Array, First, Last);
            else
                c = Partition(Array, First, Last);

            QuickSort(Array, First, c - 1, Reverse);
            QuickSort(Array, c + 1, Last, Reverse);
        }

        private static int Partition<T>(T[] Array, int First, int Last) where T : IComparable<T>
        {
            int i = First;
            for (int j = First; j <= Last; j++)
                if (Array[j].CompareTo(Array[Last]) < 0)
                {
                    T t = Array[i];
                    Array[i] = Array[j];
                    Array[j] = t;
                    i++;
                }
            return i - 1;
        }

        private static int PartitionR<T>(T[] Array, int First, int Last) where T : IComparable<T>
        {
            int i = First;
            for (int j = First; j <= Last; j++)
                if (Array[j].CompareTo(Array[Last]) > 0)
                {
                    T t = Array[i];
                    Array[i] = Array[j];
                    Array[j] = t;
                    i++;
                }
            return i - 1;
        }
    }
}

