namespace SimpleSnake.GameObjects
{
    public class FoodDollar : Food
    {
        private const char Symbol = '$';
        private const int DollarPoints = 2;

        public FoodDollar() 
            : base(Symbol, DollarPoints)
        {
        }
    }
}
