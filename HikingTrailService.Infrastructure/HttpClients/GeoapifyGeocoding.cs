using System.Globalization;
using System.Net.Http.Json;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace HikingTrailService.Infrastructure.HttpClients;

public class GeoapifyGeocoding : IGeoapifyGeocoding
{
    private readonly string _baseUrl = "https://api.geoapify.com/";
    
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public GeoapifyGeocoding(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(_baseUrl);
        _apiKey = Environment.GetEnvironmentVariable("GEOAPIFY_API_KEY") 
                  ?? throw new InvalidOperationException("GEOAPIFY_API_KEY is required.");
    }
    
    public async Task<LocationEntityDto?> ReverseGeocodingAsync(double latitude, double longitude)
    {
        Dictionary<string, string> query = new Dictionary<string, string>
        {
            ["lat"] = latitude.ToString(CultureInfo.InvariantCulture),
            ["lon"] = longitude.ToString(CultureInfo.InvariantCulture),
            ["apiKey"] = _apiKey
        };

        string url = QueryHelpers.AddQueryString("v1/geocode/reverse", query!);
        
        using HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        GeoapifyResponse? geoapifyResponse = await response.Content.ReadFromJsonAsync<GeoapifyResponse>();
        var properties = geoapifyResponse?.features?.FirstOrDefault()?.properties;
        
        if (properties == null)
            return null;

        return new LocationEntityDto()
        {
            Country = properties.country ?? String.Empty,
            CountryCode = properties.country_code ?? String.Empty,
            State = properties.state,
            StateCode = properties.state_code,
            County = properties.county,
            CountyCode = properties.county_code,
            City = properties.city,
            PostCode = properties.postcode,
            District = properties.district,
            Suburb = properties.suburb,
            Street = properties.street,
            HouseNumber = string.IsNullOrEmpty(properties.housenumber) ? uint.Parse(properties.housenumber!) : null,
            FormattedAddress = properties.formatted,
            AddressLine1 = properties.address_line1,
            AddressLine2 = properties.address_line2,
            Category = properties.category,
            ResultType = properties.result_type
        };
    }
    
    private sealed class GeoapifyResponse
    {
        public Feature[]? features { get; set; }
        public sealed class Feature
        {
            public Properties? properties { get; set; }
        }

        public sealed class Properties
        {
            public string? country { get; set; }
            public string? country_code { get; set; }
            public string? state { get; set; }
            public string? state_code { get; set; }
            public string? county { get; set; }
            public string? county_code { get; set; }
            public string? city { get; set; }
            public string? postcode { get; set; }
            public string? district { get; set; }
            public string? suburb { get; set; }
            public string? street { get; set; }
            public string? housenumber { get; set; }
            public string? formatted { get; set; }
            public string? address_line1 { get; set; }
            public string? address_line2 { get; set; }
            public string? category { get; set; }
            public string? result_type { get; set; }
        }
    }
}