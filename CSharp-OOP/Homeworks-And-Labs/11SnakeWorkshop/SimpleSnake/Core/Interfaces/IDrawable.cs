namespace SimpleSnake.Core.Interfaces
{
    public interface IDrawable
    {
        char DrawSymbol { get; }

        void Draw();
    }
}