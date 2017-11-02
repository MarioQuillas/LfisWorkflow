namespace LFWorkflow.Console.Presentation.Views
{
    using System.Drawing;

    using LFWorkflow.Console.Presentation.Abstractions;
    using LFWorkflow.Console.Presentation.CommandResults;
    using LFWorkflow.Console.Runtime.Utils;

    internal class InvalidDateView : IView
    {
        public InvalidDateView(InvalidDateResult invalidDateResult)
        {
            this.InvalidDateResult = invalidDateResult;
        }

        public InvalidDateResult InvalidDateResult { get; }

        public void Render()
        {
            Logger.Log("{0} is an invalid id.", this.InvalidDateResult.AskedDate, Color.DarkRed);
            Logger.Log("Please enter a date in the following format : {0}", "dd/mm/yyyy", Color.DarkOrange);
        }
    }
}