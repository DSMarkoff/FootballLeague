using FootballLeague.Contracts.Commands;
using System;

namespace FootballLeague.Services.Commands.Match.Update
{
    public class UpdateMatchCommand : ICommand
    {
        public UpdateMatchCommand(
            int id,
            DateTime end,
            int homeTeamGoals,
            int awayTeamGoals)
        {
            Id = id;
            End = end;
            HomeTeamGoals = homeTeamGoals;
            AwayTeamGoals = awayTeamGoals;
        }

        public int Id { get; }

        public DateTime End { get; }

        public int HomeTeamGoals { get; }

        public int AwayTeamGoals { get; }
    }
}
