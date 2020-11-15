using System.Text.Json.Serialization;

namespace Erplimo.Model.Classes
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
