using PrototypePatternSandwichBuilder.Models;

namespace DesignPatternsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["Beef"] = new Sandwich("White bread", "Beef", "Cheese", "Tomatoes");
            sandwichMenu["Turkey"] = new Sandwich("White bread", "Turkey", "Cheese", "Lettuce");
            sandwichMenu["Chicken"] = new Sandwich("White bread", "Chicken", "Cheese", "Cucumber");

            Sandwich sandwich1 = sandwichMenu["Beef"].Clone() as Sandwich;
            Sandwich sandwich2 = sandwichMenu["Turkey"].Clone() as Sandwich;
            Sandwich sandwich3 = sandwichMenu["Chicken"].Clone() as Sandwich;
        }
    }
}