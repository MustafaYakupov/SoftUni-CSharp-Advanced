namespace SimpleSnake.GameObjects
{
    public class FoodAsterisk : Food
    {
        private const char Symbol = '*';
        private const int AsteriskPoints = 1;

        public FoodAsterisk() 
            : base(Symbol, AsteriskPoints)
        {
        }
    }
}
