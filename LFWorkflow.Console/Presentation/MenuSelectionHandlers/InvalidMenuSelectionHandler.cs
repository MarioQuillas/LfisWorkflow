namespace LFWorkflow.Console.Presentation.MenuSelectionHandlers
{
    using System.Drawing;

    using LFWorkflow.Console.Presentation.Abstractions;
    using LFWorkflow.Console.Runtime.Utils;

    internal class InvalidMenuSelectionHandler : IMenuSelectionHandler
    {
        public void DisplayContent()
        {
            Logger.Log("Invalid selected menu item.", Color.Bisque);
            Logger.Log("Press ENTER to try again...");
            Logger.ReadLine();
        }
    }
}