using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("Prestiges")]

public class Comment : BaseEntity
{
    [Required]
    [Column("hiking_trail_id")]
    public int HikingTrailId { get; set; }
    
    [ForeignKey("HikingTrailId")]
    public required HikingTrail HikingTrail { get; set; }
    
    [Required]
    [Column("account_code")]
    public Guid AccountCode { get; set; }
    
    [Required]
    [Column("comment")]
    public required string CommentText { get; set; }
}