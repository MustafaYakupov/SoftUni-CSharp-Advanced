using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class CustomStack
    {
        private List<int> items;
        private int count;

        public CustomStack()
        {
            this.items = new List<int>();
        }
        public int Count { get; private set; }

        public void Push(int element)
        {
            items.Add(element);
            this.Count++;
        }

        public int Pop()
        {
            if (this.Count > 0)
            {
                int lastElement = this.items[this.Count - 1];
                this.items.RemoveAt(this.Count - 1);
                this.Count--;   
                return lastElement;
            }
            else
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        public int Peek()
        {
            if (this.Count > 0)
            {
                int lastElement = this.items[this.Count - 1];
                return lastElement;
            }
            else
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        public void ForEach(Action<object> Action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                Action(this.items[i]);
            }
        }
    }
}
