namespace LFWorkflow.UseCase.DIWrapper
{
    using Autofac;

    internal class AutofacContainerBuilderWrapper : IContainerBuilderWrapper
    {
        private readonly ContainerBuilder containerBuilder;

        internal AutofacContainerBuilderWrapper()
        {
            this.containerBuilder = new ContainerBuilder();
        }

        public void Register<TType, TInterface>()
        {
            this.containerBuilder.RegisterType<TType>().As<TInterface>();
        }

        public void Register<TType>()
        {
            this.containerBuilder.RegisterType<TType>();
        }

        public void RegisterSingleton<TType>()
        {
            this.containerBuilder.RegisterType<TType>().SingleInstance();
        }

        public void RegisterSingleton<TType, TInterface>()
        {
            this.containerBuilder.RegisterType<TType>().As<TInterface>().SingleInstance();
        }

        public void Run<TApplication>(TApplication application)
        {
            var container = this.containerBuilder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                //var app = scope.Resolve<TApplication>();
                //app.Run();
            }
        }
    }
}