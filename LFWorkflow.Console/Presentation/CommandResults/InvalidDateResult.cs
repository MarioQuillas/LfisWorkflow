namespace LFWorkflow.Console.Presentation.CommandResults
{
    using LFWorkflow.Console.Presentation.Abstractions;

    internal class InvalidDateResult : ICommandResult
    {
        public InvalidDateResult(string askedDate)
        {
            this.AskedDate = askedDate;
        }

        public string AskedDate { get; }
    }
}