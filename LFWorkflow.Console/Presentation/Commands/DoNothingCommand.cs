namespace LFWorkflow.Console.Presentation.Commands
{
    using LFWorkflow.Console.Presentation.Abstractions;
    using LFWorkflow.Console.Presentation.CommandResults;

    internal class DoNothingCommand : ICommand
    {
        public ICommandResult Execute()
        {
            return new EmptyResult();
        }
    }
}