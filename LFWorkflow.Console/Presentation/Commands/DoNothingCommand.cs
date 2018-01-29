namespace LFWorkflow.Console.Presentation.Commands
{
    using Abstractions;
    using CommandResults;

    internal class DoNothingCommand : ICommand
    {
        public ICommandResult Execute()
        {
            return new EmptyResult();
        }
    }
}