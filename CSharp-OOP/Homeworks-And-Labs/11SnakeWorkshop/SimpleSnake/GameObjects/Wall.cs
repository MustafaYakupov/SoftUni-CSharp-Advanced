namespace SimpleSnake.GameObjects
{
    public class Wall : GameObject
    {
        private const char WallSymbol = '\u25A0';

        public Wall(int x, int y)
            : base(WallSymbol, x, y)
        {
        }

        public override void Draw()
        {
            DrawHorizontalLine(0);
            DrawHorizontalLine(Y);

            DrawVerticalLine(0);
            DrawVerticalLine(X - 1);
        }

        private void DrawVerticalLine(int x)
        {
            for (int y = 0; y < Y; y++)
            {
                GameObject drawPoint = new GameObject(DrawSymbol, x, y);
                drawPoint.Draw();
            }
        }

        private void DrawHorizontalLine(int column)
        {
            for (int row = 0; row < X; row++)
            {
                GameObject drawPoint = new GameObject(DrawSymbol, row, column);
                drawPoint.Draw();
            }
        }

        public override bool IsCollidesWith(Point point)
        {
            return point.X == X - 1 ||
                   point.Y == Y ||
                   point.X == 0 ||
                   point.Y == 0;
        }
    }
}