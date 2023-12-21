using System.Text.Json;

namespace Entities;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public String? Message { get; set; }
    public DateTime AtOccuredTime { get; set; } 
    public ErrorDetails()
    {
        AtOccuredTime = DateTime.UtcNow;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
