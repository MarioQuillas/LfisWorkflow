namespace LFWorkflow.Console.Presentation.Views
{
    using System.Drawing;
    using Abstractions;
    using CommandResults;
    using Runtime.Utils;

    internal class InvalidIdView : IView
    {
        public InvalidIdView(InvalidIdResult invalidIdResult)
        {
            InvalidIdResult = invalidIdResult;
        }

        public InvalidIdResult InvalidIdResult { get; }

        public void Render()
        {
            Logger.Log("{0} is an invalid id.", InvalidIdResult.EnteredId, Color.DarkRed);
        }
    }
}