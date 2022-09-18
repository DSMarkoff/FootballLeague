using FootballLeague.Common.Validation;
using FootballLeague.Containers.Abstraction;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Commands.Match.Create;
//using FootballLeague.Services.Commands.Match.Delete;
using FootballLeague.Services.Commands.Match.Update;
using FootballLeague.Services.Handlers.Match.Create;
//using FootballLeague.Services.Handlers.Match.Delete;
using FootballLeague.Services.Handlers.Match.Get;
using FootballLeague.Services.Handlers.Match.Update;
using FootballLeague.Services.Queries.Match.Get;
using FootballLeague.Services.Results.Match.Create;
using FootballLeague.Services.Results.Match.Delete;
using FootballLeague.Services.Results.Match.Get;
using FootballLeague.Services.Results.Match.Update;
using SimpleInjector;

namespace FootballLeague.Containers.SimpleInjectorPackages
{
    public class MatchesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterCommandHandlers(container);
            RegisterQueryHandlers(container);
        }

        private void RegisterCommandHandlers(Container container)
        {
            //CREATE
            container.Register<ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult>, CreateMatchHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult>, CreateMatchCommandValidationHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult>, CreateMatchErrorHandler>(Lifestyle.Scoped);

            container.Register<IValidator<CreateMatchCommand>, CompositeValidator<CreateMatchCommand>>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<CreateMatchCommand>, CreateMatchCommandHomeTeamIdValidator>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<CreateMatchCommand>, CreateMatchCommandAwayTeamIdValidator>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<CreateMatchCommand>, CreateMatchCommandDifferentTeamsValidator>(Lifestyle.Scoped);

            //UPDATE
            container.Register<ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult>, UpdateMatchHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult>, UpdateMatchCommandValidationHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult>, UpdateMatchErrorHandler>(Lifestyle.Scoped);

            container.Register<IValidator<UpdateMatchCommand>, CompositeValidator<UpdateMatchCommand>>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<UpdateMatchCommand>, UpdateMatchCommandIdValidator>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<UpdateMatchCommand>, UpdateMatchCommandEndValidator>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<UpdateMatchCommand>, UpdateMatchCommandNumValuesValidator>(Lifestyle.Scoped);

            //    //DELETE
            //    container.Register<ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult>, DeleteMatchHandler>(Lifestyle.Scoped);
            //    container.RegisterDecorator<ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult>, DeleteMatchCommandValidationHandler>(Lifestyle.Scoped);
            //    container.RegisterDecorator<ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult>, DeleteMatchErrorHandler>(Lifestyle.Scoped);

        }

        private void RegisterQueryHandlers(Container container)
        {
            //GET
            container.Register<IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult>, GetMatchByIdHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult>, MatchByIdQueryValidationHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult>, GetMatchByIdErrorHandler>(Lifestyle.Scoped);
        }
    }
}

