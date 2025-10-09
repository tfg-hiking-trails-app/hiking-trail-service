namespace HikingTrailService.Application.DTOs.Update;

public record UpdateImagesEntityDto
{
    public Guid? HikingTrailCode { get; set; }
    public required string ImageUrl { get; set; }
    public int OrderIndex { get; set; }
    public bool Deleted { get; set; }
}