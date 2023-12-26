using System.Text.Json.Serialization;

namespace BlazorDemo.Client.Utility;

public class ProblemDetails
{
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
