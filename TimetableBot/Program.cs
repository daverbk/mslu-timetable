using System.Net;
using System.Net.Http.Headers;

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

        request.Content = new MultipartContent();
        request.Content.Headers.Add("t:zoneid", "studyGroupZone");
        request.Content.Headers.Add("t:formid", "printForm");
        request.Content.Headers.Add("t:formcomponentid", "reports/publicreports/ScheduleListForGroupReport:printform");
        request.Content.Headers.Add("t:selectvalue", "7");
        request.Content.Headers.Add("Cookie", $"JSESSIONID={responseCookies.First(c => c.Name.Contains("JSESSIONID")).Value}");
        
        var response = await client.SendAsync(request);

        foreach (var header in response.Headers)
        {
            Console.WriteLine($"{header.Key} : {header.Value}");
        }
    }
}
