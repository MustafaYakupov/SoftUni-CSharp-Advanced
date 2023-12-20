using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public object StringBUilder { get; private set; }

        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            Type type = Type.GetType(className);

            StringBuilder sb = new();

            sb.AppendLine($"Class under investigation: {type}");

            var classInstance = Activator.CreateInstance(type);

            var fields = type.GetFields((BindingFlags)(60));

            foreach (var field in fields.Where(f => fieldsNames.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);

            var classInstance = Activator.CreateInstance(type);

            FieldInfo[] classFields = type.GetFields((BindingFlags)(60));
            MethodInfo[] classPubilcMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPubilcMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new();

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in classPubilcMethods)
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in classNonPubilcMethods)
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);

            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new();

            sb.AppendLine($"All Private Methods of Class: {type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new();

            Type type = Type.GetType(className);

            MethodInfo[] methods = type.GetMethods((BindingFlags)(60));

            foreach (var method in methods.Where(x => x.Name.Contains("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.GetType().Name}");
            }

            foreach (var method in methods.Where(x => x.Name.Contains("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }
}
