namespace LFWorkflow.Console.Presentation
{
    using Abstractions;
    using Runtime;

    internal class ViewLocator : ServiceLocator<ICommandResult, IView>
    {
    }
}