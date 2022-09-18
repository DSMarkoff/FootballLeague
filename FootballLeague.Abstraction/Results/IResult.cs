namespace FootballLeague.Abstraction.Results
{
    public interface IResult
    {
        bool IsSuccessful { get; }

        string ErrorMessage { get; }
    }
}
