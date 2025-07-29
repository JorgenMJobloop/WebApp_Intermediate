using System.ComponentModel.DataAnnotations;
public class MediaModel
{
    /// <summary>
    /// Database Primary Key
    /// </summary>
    public int ID { get; set; }
    public Guid UUID = Guid.NewGuid();

    /// <summary>
    /// Type of media can either be a TV Show or a Movie
    /// </summary>
    [Required]
    [RegularExpression("Movie|TV Show")]
    public string? TypeOfMedia { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string? Title { get; set; }
    [Required]
    public string? Genre { get; set; }
    /// <summary>
    /// Details can consist of: duration/runtime, director, writers, actors, locations, plot
    /// </summary>
    public List<MediaDetails>? Details { get; set; }
    [Required]
    [RegularExpression("G|PG|PG-13|R|NC-17")]
    public string? ParentalGuidanceRating { get; set; }
}