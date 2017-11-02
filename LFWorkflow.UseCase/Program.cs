namespace LFWorkflow.UseCase
{
    using System;
    using System.Threading;

    using Autofac;

    using LFWorkflow.UseCase.Infrastructure;

    class Program
    {
        static void Main(string[] args)
        {
            var syncEvent = new AutoResetEvent(false);
            var idleEvent = new AutoResetEvent(false);

            var container = SetupDependencyInjection();
            using (var scope = container.BeginLifetimeScope())
            {
                var application = scope.Resolve<Application>();
                application.Run(syncEvent, idleEvent);
            }

            syncEvent.WaitOne();
            Console.WriteLine("Press any key to close the program...");
            Console.ReadKey();
        }

        //static ContainerConfigurator SetupDependencies()
        //{
        //    var containerConfigurator = new ContainerConfigurator(new AutofacContainerBuilderWrapper());

        //    return containerConfigurator;
        //}

        static IContainer SetupDependencyInjection()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>(); // root of the application

            // register the types here
            builder.RegisterType<InstanceStoreSetupper>().SingleInstance();

            // end registration of types
            return builder.Build();
        }
    }
}