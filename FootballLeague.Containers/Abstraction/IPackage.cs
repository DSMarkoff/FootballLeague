using SimpleInjector;

namespace FootballLeague.Containers.Abstraction
{
    public interface IPackage
    {
        void RegisterServices(Container container);
    }
}
