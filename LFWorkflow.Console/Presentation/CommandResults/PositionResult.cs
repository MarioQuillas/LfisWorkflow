namespace LFWorkflow.Console.Presentation.CommandResults
{
    using Abstractions;

    public class PositionResult : ICommandResult
    {
        public PositionResult(string folioName)
        {
            FolioName = folioName;
        }

        public string FolioName { get; }
    }
}