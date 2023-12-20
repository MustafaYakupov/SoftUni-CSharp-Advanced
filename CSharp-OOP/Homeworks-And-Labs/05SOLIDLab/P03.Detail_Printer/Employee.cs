using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    public class Employee : BaseEmployee
    {
        public Employee(string name)
            : base(name)
        {
        }

        public override string Print()
        {
            return this.Name;
        }
    }
}
