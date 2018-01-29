namespace LFWorkflow.Console.Presentation.MenuSelectionHandlers
{
    using System;
    using Abstractions;
    using Runtime.Utils;

    internal class ValidMenuSelectionHandler : IMenuSelectionHandler
    {
        private readonly ICommand currentCommand;

        private readonly Action<IView> renderAction;

        private readonly ViewLocator viewLocator;

        public ValidMenuSelectionHandler(ICommand currentCommand, ViewLocator viewLocator, Action<IView> renderAction)
        {
            this.currentCommand = currentCommand;
            this.viewLocator = viewLocator;
            this.renderAction = renderAction;
        }

        public void DisplayContent()
        {
            // 15751, 189727
            var result = this.currentCommand.Execute();
            var view = this.viewLocator.LocateServiceFor(result);

            this.renderAction(view);

            Logger.Log(string.Empty);
            Logger.Log("Press ENTER to try again...");
            Logger.ReadLine();
        }
    }
}