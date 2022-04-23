using System;
using System.Collections.Generic;
using System.Linq;

namespace LZW
{
    internal class ArrayComparer : IEqualityComparer<List<byte>>
    {
        public bool Equals(List<byte> obj1, List<byte> obj2)
        {
            if (obj1 == null && obj2 == null)
                return true;
            else if (obj1 == null || obj2 == null)
                return false;
            return obj1.SequenceEqual(obj2);
        }

        public int GetHashCode(List<byte> obj)
        {
            return obj.Select(item => item.GetHashCode()).Aggregate((total, nextCode) => total ^ nextCode);
        }
    }
}
