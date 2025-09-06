using HikingTrailService.Application.DTOs;

namespace HikingTrailService.Application.Interfaces;

public interface IGeoapifyGeocoding
{
    Task<LocationEntityDto?> ReverseGeocodingAsync(double latitude, double longitude);
}