namespace LFWorkflow.Console.Presentation.CommandResults
{
    using LFWorkflow.Console.Presentation.Abstractions;

    public class PositionResult : ICommandResult
    {
        public PositionResult(string folioName)
        {
            this.FolioName = folioName;
        }

        public string FolioName { get; }
    }
}