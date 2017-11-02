namespace LFWorkflow.Console.Presentation.Views
{
    using System.Drawing;

    using LFWorkflow.Console.Presentation.Abstractions;
    using LFWorkflow.Console.Presentation.CommandResults;
    using LFWorkflow.Console.Runtime.Utils;

    internal class PositionView : IView
    {
        private readonly PositionResult positionResult;

        public PositionView(PositionResult positionResult)
        {
            this.positionResult = positionResult;
        }

        public void Render()
        {
            Logger.Log("The position exists");
            Logger.Log("Name : {0}", this.positionResult.FolioName, Color.DarkOrchid);
        }
    }
}