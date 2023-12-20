namespace EasyInjector.Tests.Fakes
{
    public interface INestedDependency
    {
        IData Data { get; }

        IDependency Dependency { get; }
    }
}
