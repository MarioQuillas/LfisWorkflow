namespace LFWorkflow.Console.Presentation.Abstractions
{
    public interface IUserInterface
    {
        void ExecuteCommand();

        bool ReadCommand();
    }
}