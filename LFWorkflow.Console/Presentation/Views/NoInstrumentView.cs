namespace LFWorkflow.Console.Presentation.Views
{
    using System.Drawing;

    using LFWorkflow.Console.Presentation.Abstractions;
    using LFWorkflow.Console.Runtime.Utils;

    internal class NoInstrumentView : IView
    {
        public void Render()
        {
            Logger.Log("The instrument does not  exist", Color.Red);
        }
    }
}