namespace LFWorkflow.Console.Presentation.CommandResults
{
    using LFWorkflow.Console.Presentation.Abstractions;

    internal class InvalidIdResult : ICommandResult
    {
        public InvalidIdResult(string enteredId)
        {
            this.EnteredId = enteredId;
        }

        public string EnteredId { get; }
    }
}