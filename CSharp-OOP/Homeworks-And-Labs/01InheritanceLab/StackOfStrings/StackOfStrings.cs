using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOfStrings
{
    public class StackOfStrings : Stack<string>
    {
        private List<string> items;
        
        public StackOfStrings(List<string> items)
        {
            this.items = items;
        }

        public bool IsEmpty()
        { 
            return this.items.Count == 0;
        }

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                this.Push(item);
            }
        }
    }
}
