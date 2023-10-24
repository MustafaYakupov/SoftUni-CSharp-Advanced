using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenericCountMethodStrings
{
    public class Box<T> where T: IComparable<T>
    {
        private List<T> items;
        public Box()
        {
            this.items = new List<T>();
        }

        public void Add(T item)
        {
            this.items.Add(item);
        }

        public int CompareTo(T? other)
        {
            throw new NotImplementedException();
        }

        public int CompareLargerElementCount(T itemToCompare)
        {
            int count = 0;

            foreach (var item in this.items)
            {
                if (item.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            foreach (var item in this.items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}
