public class MediaDetails
{
    public required int ReleaseYear { get; set; }
    public required double Runtime { get; set; }
    public string? Director { get; set; }
    public List<string>? Writers { get; set; }
    public List<string>? Actors { get; set; }
    public string? Location { get; set; }
    public string? Synopsis { get; set; }
    public int NumberOfSeasons { get; set; }
    public int NumberOfEpisodes { get; set; }
}