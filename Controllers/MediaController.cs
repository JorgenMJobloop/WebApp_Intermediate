using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/media")]
public class MediaController : ControllerBase
{
    private readonly AppDbContext _context;

    private List<MediaModel> mediaModel = new List<MediaModel>()
    {
        new MediaModel {ID = 1, TypeOfMedia = "Movie", Title = "A Clockwork Orange", Genre = "Dark Comedy, Dystopian, Crime/Thriller", Details = new List<MediaDetails>() {
            new MediaDetails {ReleaseYear = 1971, Runtime = 190.16, Director = "Stanley Kubrick", Writers = ["Stanley Kubrick", "Anthony Burgess"], Actors = ["Malcolm Mcdowell", "Patrick Magee", "Micheal Bates"], Location = "London, UK", Synopsis = "A troubled young man copes with living in a dystopian London while commiting several crimes." }
            }, ParentalGuidanceRating = "R"
        }
    };



    public MediaController(AppDbContext context)
    {
        _context = context;

        if (!_context.Media.Any())
        {
            _context.Media.AddRange(mediaModel);
            _context.SaveChanges(); // saves the changes to the Database
        }
    }

    [HttpGet("cached")]
    public ActionResult<IEnumerable<MediaModel>> GetCached()
    {
        return mediaModel;
    }

    [HttpGet]
    public ActionResult<IEnumerable<MediaModel>> Get()
    {
        var media = _context.Media.Include(m => m.Details).ToList();
        return Ok(media);
    }


    [HttpPost]
    public IActionResult UpdateMediaContent([FromBody] MediaCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newID = mediaModel.Any() ? mediaModel.Max(m => m.ID) + 1 : 1;

        var newMedia = new MediaModel
        {
            ID = newID,
            TypeOfMedia = dto.TypeOfMedia,
            Title = dto.Title,
            Genre = dto.Genre,
            Details = dto.Details,
            ParentalGuidanceRating = dto.ParentalGuidanceRating
        };

        _context.Media.Add(newMedia);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = newID }, newMedia);
    }
}