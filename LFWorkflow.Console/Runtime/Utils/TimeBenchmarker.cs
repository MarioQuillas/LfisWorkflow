namespace LFWorkflow.Console.Runtime.Utils
{
    using System;
    using System.Diagnostics;
    using System.Drawing;

    internal class TimeBenchmarker : IDisposable
    {
        private readonly Color messageConsoleColor;

        private readonly string messageName;

        private readonly Color timeConsoleColor;

        private readonly Stopwatch timer = new Stopwatch();

        public TimeBenchmarker(string messageName)
        {
            this.messageName = messageName;
            timer.Start();
            messageConsoleColor = Color.Cyan;
            timeConsoleColor = Color.Yellow;
        }

        public void Dispose()
        {
            timer.Stop();
            Logger.Log(
                "{0} {1}",
                messageName,
                timer.Elapsed.ToString(),
                messageConsoleColor,
                timeConsoleColor);
        }
    }
}