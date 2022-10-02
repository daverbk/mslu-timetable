using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace TimetableBot;

public class Program
{
    public static async Task Main(string[] args)
    {
        var uri = new Uri("http://raspisanie.mslu.by/schedule/reports/publicreports/schedulelistforgroupreport");

        var cookies = new CookieContainer();
        var handler = new HttpClientHandler();
        handler.CookieContainer = cookies;

        var client = new HttpClient(handler);
        
        client.Timeout = TimeSpan.FromHours(1);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        client.DefaultRequestHeaders.Connection.Add("keep-alive");
        
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        await client.SendAsync(request);
        var responseCookies = cookies.GetCookies(uri).ToList();

        foreach (var cookie in responseCookies)
        {
            Console.WriteLine(cookie.Name + ": " + cookie.Value);
        }
        
        request = new HttpRequestMessage(HttpMethod.Post, "http://raspisanie.mslu.by/schedule/reports/publicreports/schedulelistforgroupreport.faculty:change");

        var request1 = new RequestModel
        {
            ZoneId = ZoneId.StudyGroupZone.ToString().FirstLetterToLower()!,
            SelectValue = "5"
        };
        
        request.Content = new StringContent(JsonSerializer.Serialize(request1));
        request.Content.Headers.Add("Cookie", $"JSESSIONID={responseCookies.First(c => c.Name.Contains("JSESSIONID")).Value}");
        
        var response = await client.SendAsync(request);

        foreach (var header in response.Headers)
        {
            Console.WriteLine($"{header.Key} : {header.Value}");
        }
    }
}
