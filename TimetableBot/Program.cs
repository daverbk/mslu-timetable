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
        var responseCookies = cookies.GetCookies(uri).Cast<Cookie>();

        foreach (var cookie in responseCookies)
        {
            Console.WriteLine(cookie.Name + ": " + cookie.Value);
        }
    }
}
