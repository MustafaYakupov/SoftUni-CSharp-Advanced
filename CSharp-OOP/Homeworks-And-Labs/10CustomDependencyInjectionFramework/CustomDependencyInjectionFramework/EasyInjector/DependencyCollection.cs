namespace EasyInjector
{
    public class DependencyCollection
    {
        private readonly Dictionary<Type, Type> dependencyRegistrations;

        public DependencyCollection()
        {
            this.dependencyRegistrations = new Dictionary<Type, Type>();
        }

        public void Register<IDependency, IImplementation>()
            where IImplementation : IDependency
        {
            var dependencyType = typeof(IDependency);
            var implementationType = typeof(IImplementation);

            this.dependencyRegistrations[dependencyType] = implementationType;
        }

        public IDependencyContainer BuildContainer()
        {
            return new DependencyContainer(this.dependencyRegistrations);
        }
    }
}
