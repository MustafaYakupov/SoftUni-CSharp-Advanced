using TemplatePatternBreadCreator.Abstraction;

namespace TemplatePatternBreadCreator.Models
{
    public class TwelveGrain : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Mixing ingredients for 12-Grain bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain bread. (25 minutes)");
        }
    }
}
