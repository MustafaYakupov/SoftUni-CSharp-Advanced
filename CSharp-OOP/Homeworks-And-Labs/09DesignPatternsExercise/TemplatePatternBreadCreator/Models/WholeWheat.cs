using TemplatePatternBreadCreator.Abstraction;

namespace TemplatePatternBreadCreator.Models
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Mixing ingredients for Whole Wheat bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the Whole Wheat bread. (15 minutes)");
        }
    }
}
