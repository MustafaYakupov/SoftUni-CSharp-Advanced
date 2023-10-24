using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class CuteCatEnumerator : IEnumerator<CuteCat>
    {
        private List<CuteCat> cuteCats;
        private int index = -1;

        public CuteCatEnumerator()
        {
        }

        public CuteCatEnumerator(List<CuteCat> cuteCats)
        {
            this.cuteCats = cuteCats;
        }
        public CuteCat Current 
        {
            get
            {
                return this.cuteCats[this.index]; 
            }
        }

        object IEnumerator.Current 
        {
            get
            {
                return this.Current;
            }
        }

        public void Dispose()  // We leave this empty for now
        {
        }

        public bool MoveNext() // returns true if there is a next element and false if there is not 
        {
            this.index++;

            if (this.index < this.cuteCats.Count)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
        }
    }
}
