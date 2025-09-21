using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("Prestiges")]
public class Prestige : BaseEntity
{
    [Required]
    [Column("hiking_trail_id")]
    public int HikingTrailId { get; set; }
    
    [ForeignKey("HikingTrailId")]
    public required HikingTrail HikingTrail { get; set; }
    
    [Required]
    [Column("receiver_account_code")]
    public Guid ReceiverAccountCode { get; set; }
    
    [Required]
    [Column("giver_account_code")]
    public Guid GiverAccountCode { get; set; }
}