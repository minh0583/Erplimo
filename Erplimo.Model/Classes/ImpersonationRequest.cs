using System.Text.Json.Serialization;

namespace Erplimo.Model.Classes
{
    public class ImpersonationRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}
