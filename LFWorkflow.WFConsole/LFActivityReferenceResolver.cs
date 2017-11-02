namespace LFWorkflow.WFConsole
{
    using System.Collections;
    using System.Collections.Generic;

    using Newtonsoft.Json.Serialization;

    internal class LFActivityReferenceResolver : IReferenceResolver
    {
        private readonly IDictionary<string, LFActivity> nodes;

        public LFActivityReferenceResolver()
        {
            this.nodes = new Dictionary<string, LFActivity>();
        }

        public object ResolveReference(object context, string reference)
        {
            return this.nodes.TryGetValue(reference, out var node) ? this.nodes[node.Id] : null;
        }

        public string GetReference(object context, object value)
        {
            //TODO : more safe code
            var node = (LFActivity)value;
            this.nodes[node.Id] = node;

            return node.Id;
        }

        public bool IsReferenced(object context, object value)
        {
            //TODO: safer code
            var node = (LFActivity)value;

            return this.nodes.ContainsKey(node.Id);
        }

        public void AddReference(object context, string reference, object value)
        {
            var nodeId = reference;
            this.nodes[nodeId] = (LFActivity)value;
        }
    }
}