using FootballLeague.Abstraction.Handlers;
using FootballLeague.Containers.Abstraction;
using FootballLeague.Services.Commands.Team.Create;
using FootballLeague.Services.Handlers.Team.Create;
using FootballLeague.Services.Handlers.Team.Get;
using FootballLeague.Services.Queries.Team.Get;
using FootballLeague.Services.Results.Team.Create;
using FootballLeague.Services.Results.Team.Get;
using SimpleInjector;

namespace FootballLeague.Containers.SimpleInjectorPackages
{
    public class TeamsPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterCommandHandlers(container);
            RegisterQueryHandlers(container);
        }

        private void RegisterCommandHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateTeamHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateTeamCommandValidationHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateTeamErrorHandler>(Lifestyle.Scoped);
        }

        private void RegisterQueryHandlers(Container container)
        {
            container.Register<IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult>, GetTeamByIdHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult>, TeamByIdQueryValidationHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult>, GetTeamByIdErrorHandler>(Lifestyle.Scoped);
        }
    }
}
