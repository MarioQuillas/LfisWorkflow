namespace LFWorkflow.Console.Presentation.CommandResults
{
    using Abstractions;

    internal class InvalidIdResult : ICommandResult
    {
        public InvalidIdResult(string enteredId)
        {
            EnteredId = enteredId;
        }

        public string EnteredId { get; }
    }
}