namespace LFWorkflow.WFConsole
{
    using System;
    using System.Activities;

    public class LFAsyncAgent : AsyncCodeActivity<LFAgentResult>
    {
        private InArgument<string> lolo;

        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        protected override LFAgentResult EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }
}