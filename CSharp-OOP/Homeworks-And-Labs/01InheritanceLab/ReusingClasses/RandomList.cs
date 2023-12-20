

namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class RandomList : List<string>
    {
        private List<string> colleciton;
        private Random random;

        public RandomList(List<string> colleciton)
        {
            this.colleciton = colleciton;
        }

        public string RandomString()
        {
            int index = random.Next(0, this.Count);
            string element = this[index];
            this.RemoveAt(index);
            return element;
        }
    }
}
