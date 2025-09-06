using Common.Application.DTOs;

namespace HikingTrailService.Application.DTOs;

public record LocationEntityDto : BaseEntityDto
{
    public string? Country { get; set; }
    public string? CountryCode { get; set; }
    public string? State { get; set; }
    public string? StateCode { get; set; }
    public string? County { get; set; }
    public string? CountyCode { get; set; }
    public string? City { get; set; }
    public string? PostCode { get; set; }
    public string? District { get; set; }
    public string? Suburb { get; set; }
    public string? Street { get; set; }
    public uint? HouseNumber { get; set; }
    public string? FormattedAddress { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? Category { get; set; }
    public string? ResultType { get; set; }
    public bool Deleted { get; set; }
}