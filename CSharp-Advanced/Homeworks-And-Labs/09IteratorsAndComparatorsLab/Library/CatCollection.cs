using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class CatCollection : IEnumerable<CuteCat>
    {
        private List<CuteCat> cats;

        public CatCollection()
        { 
            this.cats = new List<CuteCat>();
        }

        public void Add(CuteCat cat)
        {
            this.cats.Add(cat);
        }

        public IEnumerator<CuteCat> GetEnumerator() // Foreach will use this class to iterate using the methods in CuteCatEnumerator
        {
            return new CuteCatEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()  // Legacy method
        {
            return GetEnumerator();
        }
    }
}
