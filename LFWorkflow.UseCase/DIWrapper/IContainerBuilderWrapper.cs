namespace LFWorkflow.UseCase.DIWrapper
{
    internal interface IContainerBuilderWrapper
    {
        void Register<TType, TInterface>();

        void Register<TType>();

        void RegisterSingleton<TType>();

        void RegisterSingleton<TType, TInterface>();

        void Run<TApplication>(TApplication application);
    }
}