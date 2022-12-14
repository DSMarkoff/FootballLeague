using FootballLeague.Common.Validation;
using FootballLeague.Containers.Abstraction;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Commands.Team.Create;
using FootballLeague.Services.Commands.Team.Delete;
using FootballLeague.Services.Commands.Team.Update;
using FootballLeague.Services.Handlers.Team.All;
using FootballLeague.Services.Handlers.Team.Create;
using FootballLeague.Services.Handlers.Team.Delete;
using FootballLeague.Services.Handlers.Team.Get;
using FootballLeague.Services.Handlers.Team.Update;
using FootballLeague.Services.Queries.Team.All;
using FootballLeague.Services.Queries.Team.Get;
using FootballLeague.Services.Results.Team.All;
using FootballLeague.Services.Results.Team.Create;
using FootballLeague.Services.Results.Team.Delete;
using FootballLeague.Services.Results.Team.Get;
using FootballLeague.Services.Results.Team.Update;
using SimpleInjector;

namespace FootballLeague.Containers.SimpleInjectorPackages
{
    public class TeamsPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterCommandHandlers(container);
            RegisterQueryHandlers(container);
            RegisterCommonHandlers(container);
        }

        private void RegisterCommandHandlers(Container container)
        {
            //CREATE
            container.Register<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateTeamHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateTeamCommandValidationHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateTeamErrorHandler>(Lifestyle.Scoped);

            //UPDATE
            container.Register<ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult>, UpdateTeamHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult>, UpdateTeamCommandValidationHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult>, UpdateTeamErrorHandler>(Lifestyle.Scoped);

            container.Register<IValidator<UpdateTeamCommand>, CompositeValidator<UpdateTeamCommand>>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<UpdateTeamCommand>, UpdateTeamCommandIdValidator>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<UpdateTeamCommand>, UpdateTeamCommandNameValidator>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<UpdateTeamCommand>, UpdateTeamCommandNumValuesValidator>(Lifestyle.Scoped);

            //DELETE
            container.Register<ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult>, DeleteTeamHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult>, DeleteTeamCommandValidationHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult>, DeleteTeamErrorHandler>(Lifestyle.Scoped);
        }

        private void RegisterQueryHandlers(Container container)
        {
            //GET
            container.Register<IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult>, GetTeamByIdHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult>, TeamByIdQueryValidationHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult>, GetTeamByIdErrorHandler>(Lifestyle.Scoped);

            //ALL
            container.Register<IQueryHandlerAsync<GetAllTeamsQuery, GetAllTeamsResult>, GetAllTeamsHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<IQueryHandlerAsync<GetAllTeamsQuery, GetAllTeamsResult>, GetAllTeamsErrorHandler>(Lifestyle.Scoped);
        }

        private void RegisterCommonHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<UpdateTeamStatsCommand>, UpdateTeamStatsCommandHandler>(Lifestyle.Scoped);
        }
    }
}
