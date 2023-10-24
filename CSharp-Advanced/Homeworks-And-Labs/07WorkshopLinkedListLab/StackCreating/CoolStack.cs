namespace StackCreating
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class CoolStack
    {
        private List<object> values;

        public CoolStack()               // Constructor
        { 
            this.values = new List<object>();
        }

        public int Count  // Property
        {
            get
            { 
                return this.values.Count;
            }
        } 

        public void Push(object value)  //Method
        {
            this.values.Add(value);
        }

        public object Pop()     //Method
        {
            if (this.values.Count == 0)
            {
                throw new InvalidOperationException("Cool stack is empty");
            }

            var lastIndex = this.values.Count - 1;
            var last = this.values[lastIndex];
            this.values.RemoveAt(lastIndex);
            return last;
        }

        public void ForEach(Action<object> action)
        {
            foreach (var item in values)
            {
                action(item);
            }
        }
    }
}
