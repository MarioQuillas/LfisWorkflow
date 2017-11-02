namespace LFWorkflow.Console.Presentation.Views
{
    using System.Drawing;

    using LFWorkflow.Console.Presentation.Abstractions;
    using LFWorkflow.Console.Presentation.CommandResults;
    using LFWorkflow.Console.Runtime.Utils;

    internal class InvalidIdView : IView
    {
        public InvalidIdView(InvalidIdResult invalidIdResult)
        {
            this.InvalidIdResult = invalidIdResult;
        }

        public InvalidIdResult InvalidIdResult { get; }

        public void Render()
        {
            Logger.Log("{0} is an invalid id.", this.InvalidIdResult.EnteredId, Color.DarkRed);
        }
    }
}