namespace LFWorkflow.Console.Presentation.CommandResults
{
    using LFWorkflow.Console.Presentation.Abstractions;

    internal class InstrumentResult : ICommandResult
    {
        public InstrumentResult(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}