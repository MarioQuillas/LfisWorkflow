namespace LFWorkflow.Console.Presentation.CommandResults
{
    using Abstractions;

    internal class InstrumentResult : ICommandResult
    {
        public InstrumentResult(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}