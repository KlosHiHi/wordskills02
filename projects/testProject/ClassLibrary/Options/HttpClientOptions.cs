using System;

namespace ClassLibrary.Options;

public class HttpClientOptions
{
    public static HttpClient Client { get; set; } = new();
public static string BaseUrl { get; set; } = "http://localhost:5099/api/";
}
