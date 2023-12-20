using TemplatePatternBreadCreator.Abstraction;

namespace TemplatePatternBreadCreator.Models
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Mixing ingredients for Sourdough bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the Sourdough. (20 minutes)");
        }
    }
}
