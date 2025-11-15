using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("MetricsScore")]
public class MetricsScore : BaseEntity
{
    [Required]
    [Column("account_code")]
    public required Guid AccountCode { get; set; }

    [Column("distance")]
    [Range(0, 10)]
    public byte Distance { get; set; } = 0;

    [Column("duration")]
    [Range(0, 10)]
    public byte Duration { get; set; } = 0;

    [Column("steps")]
    [Range(0, 10)]
    public byte Steps { get; set; } = 0;

    [Column("calories")]
    [Range(0, 10)]
    public byte Calories { get; set; } = 0;

    [Column("pace")]
    [Range(0, 10)]
    public byte Pace { get; set; } = 0;

    [Column("elevation")]
    [Range(0, 10)]
    public byte Elevation { get; set; } = 0;

    [Column("heart_rate")]
    [Range(0, 10)]
    public byte HeartRate { get; set; } = 0;

    [Column("speed")]
    [Range(0, 10)]
    public byte Speed { get; set; } = 0;
}