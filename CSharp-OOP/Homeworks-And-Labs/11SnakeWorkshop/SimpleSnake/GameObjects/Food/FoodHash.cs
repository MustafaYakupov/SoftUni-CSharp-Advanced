namespace SimpleSnake.GameObjects
{
    public class FoodHash : Food
    {
        private const char Symbol = '#';
        private const int HashPoints = 3;

        public FoodHash()
            : base(Symbol, HashPoints)
        {
        }
    }
}
