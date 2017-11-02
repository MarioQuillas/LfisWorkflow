namespace LFWorkflow.WFConsole
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    [JsonObject(IsReference = true)]
    internal class LFActivity
    {
        public string Id { get; set; }

        public string Script { get; set; }

        public List<string> Resources { get; set; }

        public List<LFActivity> Next { get; set; }
    }
}