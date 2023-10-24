using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class CuteDog : IAnimal
    {
        public string Name { get; set; }

        public string SayHello()
        {
            return "Bark!";
        }
    }
}
