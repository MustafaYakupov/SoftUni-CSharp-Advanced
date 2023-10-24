using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> collection;

        public CustomStack()
        {
            this.collection = new List<T>();
        }

        public void Push(T element)
        {
            this.collection.Add(element);
        }

        public T Pop()
        {
            if (this.collection.Count > 0)
            {
                T removedElement = this.collection.ElementAt(this.collection.Count - 1);
                this.collection.RemoveAt(this.collection.Count - 1);
                return removedElement;
            }
            else
            {
                throw new InvalidOperationException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.collection.Count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
