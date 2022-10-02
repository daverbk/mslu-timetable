using System.Text.Json.Serialization;

namespace TimetableBot;

public class RequestModel
{
    [JsonPropertyName("t:zoneid")]
    public string ZoneId { get; set; }

    [JsonPropertyName("t:formid")] 
    public string FormId { get; set; } = "printForm";

    [JsonPropertyName("t:formcomponentid")]
    public string FormComponentId { get; set; } = "reports/publicreports/ScheduleListForGroupReport:printform";
    
    [JsonPropertyName("t:selectvalue")]
    public string SelectValue { get; set; }
}
