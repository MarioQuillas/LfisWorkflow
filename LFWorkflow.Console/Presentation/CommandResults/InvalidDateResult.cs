namespace LFWorkflow.Console.Presentation.CommandResults
{
    using Abstractions;

    internal class InvalidDateResult : ICommandResult
    {
        public InvalidDateResult(string askedDate)
        {
            AskedDate = askedDate;
        }

        public string AskedDate { get; }
    }
}