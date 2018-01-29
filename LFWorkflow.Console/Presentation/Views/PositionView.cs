namespace LFWorkflow.Console.Presentation.Views
{
    using System.Drawing;
    using Abstractions;
    using CommandResults;
    using Runtime.Utils;

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
            Logger.Log("Name : {0}", positionResult.FolioName, Color.DarkOrchid);
        }
    }
}