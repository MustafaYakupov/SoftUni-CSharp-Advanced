namespace EasyInjector
{
    public class DependencyContainer : IDependencyContainer
    {
        private readonly Dictionary<Type, Type> dependencyRegistrations;

        public DependencyContainer(Dictionary<Type, Type> dependencyRegistrations)
        {
            this.dependencyRegistrations = dependencyRegistrations;
        }

        public TDependency Get<TDependency>() 
            where TDependency : class
        {
            var dependencyType = typeof(TDependency);

            return (TDependency)this.Get(dependencyType);
        }

        public TInstance Resolve<TInstance>() 
            where TInstance : class
        {
            return (TInstance)this.CreateInstance(typeof(TInstance));
        }

        private object Get(Type dependencyType)
        {
            if (!dependencyRegistrations.ContainsKey(dependencyType))
            {
                throw new InvalidOperationException($"{dependencyType.FullName} is not registered in the dependency container.");
            }

            var implementationType = this.dependencyRegistrations[dependencyType];

            return CreateInstance(implementationType);
        }

        private object CreateInstance(Type instanceType)
        {
            var constructors = instanceType.GetConstructors();

            if (constructors.Length != 1)
            {
                throw new InvalidOperationException($"{instanceType.FullName} is invalid for EasyInjector because it has more than 1 constructor.");
            }

            var constructor = constructors.First();
            var parameters = constructor.GetParameters();

            if (!parameters.Any())
            {
                return Activator.CreateInstance(instanceType)!;
            }

            var parameterInstances = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                var parameterType = parameter.ParameterType;

                var parameterInstance = this.Get(parameterType);

                parameterInstances[i] = parameterInstance;
            }

            return constructor.Invoke(parameterInstances);
        }
    }
}
