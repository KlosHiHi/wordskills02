using System;

namespace ClassLibrary.Options;

public class HttpOption
{
    public static readonly HttpClient httpClient = new();
    public static readonly string baseUrl = "http://localhost:5110/api/";
}
