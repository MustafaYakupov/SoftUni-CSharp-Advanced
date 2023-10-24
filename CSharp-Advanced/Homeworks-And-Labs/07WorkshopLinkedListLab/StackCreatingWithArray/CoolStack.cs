namespace StackCreating
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class CoolStack 
    {
        private object[] values;
        private int count;

        public CoolStack()               // Constructor
            :this(16)
        {
        }

        public CoolStack(int initialCapacity)
        {
            this.count = 0;
            this.values = new object[initialCapacity];
        }

        public int Count  // Property
        {
            get
            {
                return this.count;
            }
            set 
            { }
        }

        public void Push(object value)  //Method
        {
            if (this.count == this.values.Length)
            {
                var nextValues = new object[this.values.Length * 2];

                for (int i = 0; i < this.values.Length; i++)
                {
                    nextValues[i] = this.values[i];
                }

                this.values = nextValues;
            }

            this.values[this.count] = value;
            this.Count++;
        }

        public object Pop()     //Method
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Cool stack is empty");
            }

            var lastIndex = this.count - 1;
            var last = this.values[lastIndex];
            this.count--;
            return last;
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.values[i]);
            }
        }
    }
}
