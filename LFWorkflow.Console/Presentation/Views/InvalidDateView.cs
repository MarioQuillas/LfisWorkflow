namespace LFWorkflow.Console.Presentation.Views
{
    using System.Drawing;
    using Abstractions;
    using CommandResults;
    using Runtime.Utils;

    internal class InvalidDateView : IView
    {
        public InvalidDateView(InvalidDateResult invalidDateResult)
        {
            InvalidDateResult = invalidDateResult;
        }

        public InvalidDateResult InvalidDateResult { get; }

        public void Render()
        {
            Logger.Log("{0} is an invalid id.", InvalidDateResult.AskedDate, Color.DarkRed);
            Logger.Log("Please enter a date in the following format : {0}", "dd/mm/yyyy", Color.DarkOrange);
        }
    }
}