namespace LFWorkflow.Console.Presentation
{
    using LFWorkflow.Console.Presentation.Abstractions;
    using LFWorkflow.Console.Runtime;

    internal class ViewLocator : ServiceLocator<ICommandResult, IView>
    {
    }
}