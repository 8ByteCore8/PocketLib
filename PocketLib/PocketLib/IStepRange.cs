//C#
//© Кушнір Б.T. , 2018
using System;
using System.Collections.Generic;

namespace PocketLib
{
    internal interface ISteppingRange<T> : IRange<T>, IEnumerable<T> where T : IComparable<T>
    {
        T Step { get; set; }
    }
}