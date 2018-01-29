namespace LFWorkflow.Console.Presentation
{
    using System;
    using System.Drawing;
    using Abstractions;
    using Commands;
    using Runtime.Utils;

    internal class MenuItem
    {
        private readonly string caption;

        private readonly char hotkey;

        // todo: it is a func because the visibility can depend on the state of the program (user logged in for example)
        private readonly Func<bool> isVisible;

        private MenuItem(string caption, char hotkey, bool isTerminal, ICommand command, Func<bool> isVisible)
        {
            this.caption = caption;
            this.hotkey = hotkey;
            IsTerminalCommand = isTerminal;
            Command = command;
            this.isVisible = isVisible;
        }

        public ICommand Command { get; }

        public bool IsTerminalCommand { get; }

        public static MenuItem CreateNonTerminal(string caption, char hotkey, ICommand command, Func<bool> isVisible)
        {
            return new MenuItem(caption, hotkey, false, command, isVisible);
        }

        public static MenuItem CreateTerminal(string caption, char hotkey)
        {
            return new MenuItem(caption, hotkey, true, new DoNothingCommand(), () => true);
        }

        public void Display()
        {
            if (!isVisible()) return;

            var pos = caption.IndexOf(hotkey);

            if (pos > 0) Logger.Write(caption.Substring(0, pos));

            Logger.Write(hotkey.ToString(), Color.AliceBlue);

            if (pos < caption.Length - 1) Logger.Write(caption.Substring(pos + 1));

            Logger.Log(string.Empty);
        }

        public bool MatchesKey(char key)
        {
            return isVisible() && char.ToLower(hotkey) == char.ToLower(key);
        }
    }
}