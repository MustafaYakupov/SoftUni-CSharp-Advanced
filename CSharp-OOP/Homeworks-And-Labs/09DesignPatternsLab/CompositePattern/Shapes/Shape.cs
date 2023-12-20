using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Shapes
{
    public abstract class Shape
    {
        private List<Shape> children;

        protected Shape(Position position)
        {
            Position = position;
        }

        public Position Position { get; set; }

        public ConsoleColor ConsoleColor { get; set; }

        public virtual void Draw()
        {
            Console.ForegroundColor = ConsoleColor;

            foreach (var child in children)
            {
                child.Draw();
            }
        }

        public virtual void Color(ConsoleColor color)
        {
            this.ConsoleColor = color;
            foreach (var child in children)
            {
                child.Color(color);
            }
        }

        public virtual void Move(Direction direction)
        {
            foreach (var child in children)
            {
                child.Move(direction);
            }
        }

        public void AddChild(Shape shape)
        {
            children.Add(shape);
        }

        protected void SetCursorPosition(int leftOffset = 0, int rightOffset = 0)
        {
            Console.SetCursorPosition(Position.Left + leftOffset, Position.Top + rightOffset);
        }
    }
}
