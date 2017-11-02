namespace LFWorkflow.UseCase.CustomActivities
{
    using System;
    using System.Activities;
    using System.Diagnostics;
    using System.Security;
    using System.Threading.Tasks;

    public sealed class ProcessActivity : AsyncCodeActivity
    {
        public InArgument<string> ArgumentPath { get; set; }

        // Define an activity input argument of type string
        public InArgument<string> ExecutablePath { get; set; }

        public OutArgument<string> MyStandardOutput { get; set; }

        // protected override void CacheMetadata(NativeActivityMetadata metadata)
        // {
        // metadata.AddArgument(this.ExecutablePath);
        // }

        protected override IAsyncResult BeginExecute(
            AsyncCodeActivityContext context,
            AsyncCallback callback,
            object state)
        {
            var processStartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                //UserName = "quillass",
                //Domain = "UFG_DOM",
                //Password = this.GetPasswordPrevileges(),
                FileName = this.ExecutablePath.Get(context),
                Arguments = this.ArgumentPath.Get(context)
            };

            var process = new Process() {StartInfo = processStartInfo};
            context.UserState = process;
            var task = Task.Factory.StartNew(
                _ =>
                {
                    process.Start();
                    process.WaitForExit();
                },
                state);
            if (callback != null)
            {
                task.ContinueWith(res => callback(task));
            }

            return task;
        }

        protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            var readToEnd = (context.UserState as Process).StandardOutput.ReadToEnd();

            this.MyStandardOutput.Set(context, readToEnd);
        }
    }
}