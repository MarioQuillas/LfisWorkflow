namespace LFWorkflow.Console.Runtime.Utils
{
    using System;
    using System.Drawing;
    using System.Threading;
    using Console = Colorful.Console;

    internal class ConsoleSpinner : IDisposable
    {
        private const string Sequence = @"/-\|";

        private readonly int delay;

        private readonly int left;

        private readonly Thread thread;

        private readonly int top;

        private bool active;

        private int counter;

        public ConsoleSpinner(int left, int top, int delay = 100)
        {
            this.left = left;
            this.top = top;
            this.delay = delay;
            thread = new Thread(Spin);
            Start();
        }

        public void Dispose()
        {
            Stop();
        }

        public void Start()
        {
            active = true;
            if (!thread.IsAlive) thread.Start();
        }

        public void Stop()
        {
            active = false;
            Draw(' ');
        }

        private void Draw(char c)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = Color.Green;
            Console.Write(c);
        }

        private void Spin()
        {
            while (active)
            {
                Turn();
                Thread.Sleep(delay);
            }
        }

        private void Turn()
        {
            Draw(Sequence[++counter % Sequence.Length]);
        }
    }
}