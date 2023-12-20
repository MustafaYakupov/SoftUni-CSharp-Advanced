using P03.Detail_Printer;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Manager : BaseEmployee 
    {
        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string Print()
        {
            return this.Name;
        }
    }
}
