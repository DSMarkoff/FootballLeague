using FootballLeague.Contracts.Commands;
using System;

namespace FootballLeague.Services.Commands.Match.Create
{
    public class CreateMatchCommand : ICommand
    {
        public CreateMatchCommand(
            DateTime start,
            int homeTeamId,
            int awayTeamId)
        {
            Start = start;
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
        }

        public DateTime Start { get; }
                                     
        public int HomeTeamId { get; }
                                     
        public int AwayTeamId { get; }
    }
}
