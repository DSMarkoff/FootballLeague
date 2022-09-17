using FootballLeague.Abstraction.Handlers;
using FootballLeague.Containers.Abstraction;
using FootballLeague.Services.Commands.Create;
using FootballLeague.Services.Handlers.Create;
using FootballLeague.Services.Results.Create;
using SimpleInjector;

namespace FootballLeague.Containers.SimpleInjectorPackages
{
    public class TeamsPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterCommandHandlers(container);
        }

        private void RegisterCommandHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateTeamHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateCommandValidationHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateTeamErrorHandler>(Lifestyle.Scoped);
        }
    }
}
