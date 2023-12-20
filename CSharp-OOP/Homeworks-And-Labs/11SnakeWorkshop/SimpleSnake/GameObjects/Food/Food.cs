namespace SimpleSnake.GameObjects
{
    public abstract class Food : GameObject
    {
        protected Food(char drawSymbol, int points) 
            : base(drawSymbol)
        {
            Points = points;
        }

        public int Points { get; set; }
    }
}
