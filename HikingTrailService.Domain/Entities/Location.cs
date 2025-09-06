using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("Location")]
public class Location : BaseEntity
{
    [Required]
    [Column("hiking_trail_id")]
    public int HikingTrailId { get; set; }

    [ForeignKey("HikingTrailId")]
    public required HikingTrail HikingTrail { get; set; }

    [MaxLength(100)]
    [Column("country")]
    public string? Country { get; set; }

    [MaxLength(2)]
    [Column("country_code")]
    public string? CountryCode { get; set; }

    [MaxLength(100)]
    [Column("state")]
    public string? State { get; set; }

    [MaxLength(10)]
    [Column("state_code")]
    public string? StateCode { get; set; }

    [MaxLength(100)]
    [Column("county")]
    public string? County { get; set; }

    [MaxLength(10)]
    [Column("county_code")]
    public string? CountyCode { get; set; }

    [MaxLength(100)]
    [Column("city")]
    public string? City { get; set; }

    [MaxLength(20)]
    [Column("post_code")]
    public string? PostCode { get; set; }

    [MaxLength(100)]
    [Column("district")]
    public string? District { get; set; }

    [MaxLength(100)]
    [Column("suburb")]
    public string? Suburb { get; set; }

    [MaxLength(100)]
    [Column("street")]
    public string? Street { get; set; }

    [Column("house_number")]
    public uint? HouseNumber { get; set; }

    [MaxLength(255)]
    [Column("formatted_address")]
    public string? FormattedAddress { get; set; }

    [MaxLength(255)]
    [Column("address_line1")]
    public string? AddressLine1 { get; set; }

    [MaxLength(255)]
    [Column("address_line2")]
    public string? AddressLine2 { get; set; }

    [MaxLength(100)]
    [Column("category")]
    public string? Category { get; set; }

    [MaxLength(50)]
    [Column("result_type")]
    public string? ResultType { get; set; }

    [Column("deleted")]
    public bool Deleted { get; set; }
}