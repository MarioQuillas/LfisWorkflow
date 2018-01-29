namespace LFWorkflow.Console.Presentation.Views
{
    using System.Drawing;
    using Abstractions;
    using CommandResults;
    using Runtime.Utils;

    internal class InstrumentView : IView
    {
        private readonly InstrumentResult instrumentResult;

        public InstrumentView(InstrumentResult instrumentResult)
        {
            this.instrumentResult = instrumentResult;
        }

        public void Render()
        {
            // Logger.Log("The instrument exists : {0}", instrument.Name, Color.LawnGreen);
            Logger.Log("The instrument exists");
            Logger.Log("Name : {0}", instrumentResult.Name, Color.DarkOrchid);

            // Logger.Log("Contract : {0}", JsonConvert.SerializeObject(instrument.Contract), Color.DarkOrchid);
            // Logger.Log("PayOff : {0}", instrument.PayOff.ToString(), Color.DarkOrchid);
            // Logger.Log("Name : {0}", instrument.Category.ToString(), Color.DarkOrchid);
        }
    }
}