namespace LFWorkflow.WFConsole
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class LFActivityDto
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Script")]
        public string Script { get; set; }

        [JsonProperty("Resources")]
        public List<string> Resources { get; set; }

        [JsonProperty("Next")]
        public List<string> Next { get; set; }
    }
}