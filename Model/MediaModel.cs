using System.ComponentModel.DataAnnotations;

public class MediaModel
{
    /// <summary>
    /// Database Primary Key
    /// </summary>
    public int ID { get; set; }
    public Guid UUID { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Type of media can either be a TV Show or a Movie
    /// </summary>
    public required string TypeOfMedia { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string Title { get; set; }
    public required string Genre { get; set; }
    /// <summary>
    /// Details can consist of: duration/runtime, director, writers, actors, locations, plot
    /// </summary>
    public required List<MediaDetails> Details { get; set; }
}