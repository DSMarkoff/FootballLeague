using FootballLeague.Containers.Abstraction;
using FootballLeague.Containers.SimpleInjectorPackages;
using SimpleInjector;

namespace FootballLeague.Containers.Initializer
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize(Container container)
        {
            var packages = new IPackage[]
            {
                new TeamsPackage(),
                new MatchesPackage()
            };

            foreach (var package in packages)
            {
                package.RegisterServices(container);
            }
        }
    }
}
