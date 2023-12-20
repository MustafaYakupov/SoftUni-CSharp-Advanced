using System.Reflection;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Get another class' method

            Type type = typeof(Laptop);

            MethodInfo methods = type.GetMethod("ToString");
            Laptop laptop = new Laptop();

            Console.WriteLine(methods.Invoke(laptop, null));

            //Type type = typeof(Laptop);

            //ConstructorInfo[] constructors = type.GetConstructors();

            //foreach (var constructor in constructors)
            //{
            //    ParameterInfo[] parameters = constructor.GetParameters();

            //    object[] paramValues = new object[parameters.Length];

            //    int index = 0;

            //    foreach (var param in parameters)
            //    {
            //        paramValues[index++] = GetDefault(param.ParameterType);
            //    }

            //    Laptop laptop = Activator.CreateInstance(type, paramValues) as Laptop;

            //    Console.WriteLine(laptop.Name);
            //    Console.WriteLine(laptop.Year);
            //    Console.WriteLine(laptop.Price);
            //}
        }

        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
    }
}

