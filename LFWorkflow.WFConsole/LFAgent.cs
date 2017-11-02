namespace LFWorkflow.WFConsole
{
    using System.Activities;

    public class LFAgent : CodeActivity<LFAgentResult>
    {
        private InArgument<string> lolo;

        protected override LFAgentResult Execute(CodeActivityContext context)
        {
            var toto = this.lolo.Get(context);
            throw new System.NotImplementedException();
        }
    }
}