namespace LFWorkflow.Console.Runtime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ServiceLocator<TKey, TService>
    {
        public ServiceLocator()
        {
            Mappings = new List<Tuple<Func<TKey, bool>, Func<TKey, TService>>>();
        }

        private IList<Tuple<Func<TKey, bool>, Func<TKey, TService>>> Mappings { get; }

        public TService LocateServiceFor(TKey key)
        {
            return
                Mappings
                    .Where(mapping => mapping.Item1(key))
                    .Select(mapping => mapping.Item2)
                    .First()(key);
        }

        public void RegisterService(Func<TKey, bool> selector, Func<TKey, TService> serviceFactory)
        {
            Mappings.Add(Tuple.Create(selector, serviceFactory));
        }
    }
}