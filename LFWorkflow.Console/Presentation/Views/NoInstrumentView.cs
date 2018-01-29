namespace LFWorkflow.Console.Presentation.Views
{
    using System.Drawing;
    using Abstractions;
    using Runtime.Utils;

    internal class NoInstrumentView : IView
    {
        public void Render()
        {
            Logger.Log("The instrument does not  exist", Color.Red);
        }
    }
}