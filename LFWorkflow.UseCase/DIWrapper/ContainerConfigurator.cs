namespace LFWorkflow.UseCase.DIWrapper
{
    internal class ContainerConfigurator
    {
        private readonly IContainerBuilderWrapper containerBuilderWrapper;

        internal ContainerConfigurator(IContainerBuilderWrapper containerBuilderWrapper)
        {
            this.containerBuilderWrapper = containerBuilderWrapper;
        }

        internal void Run()
        {
            this.Register();
            //this.containerBuilderWrapper.Run();
        }

        private void Register()
        {
            // this.containerBuilderWrapper.Register<Application, Application>();
            // register
        }
    }
}