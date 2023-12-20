using System;

namespace P02.Graphic_Editor
{
    public class GraphicEditor 
    {
        private IShape shape;

        public GraphicEditor(IShape shape)
        {
            this.shape = shape;
        }

        public string DrawShape()
        {
            return this.shape.DrawShape().ToString();
        }
    }
}
