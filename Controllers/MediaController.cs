using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/media")]
public class MediaController
{
    private List<MediaModel> mediaModel = new List<MediaModel>()
    {
        new MediaModel {ID = 1, UUID = Guid.NewGuid(), TypeOfMedia = "Movie", Title = "A Clockwork Orange", Genre = "Dark Comedy, Dystopian, Crime/Thriller", Details = new List<MediaDetails>() {
            new MediaDetails {ReleaseYear = 1971, Runtime = 190.16, Director = "Stanley Kubrick", Writers = ["Stanley Kubrick", "Anthony Burgess"], Actors = ["Malcolm Mcdowell", "Patrick Magee", "Micheal Bates"], Location = "London, UK", Synopsis = "A troubled young man copes with living in a dystopian London while commiting several crimes." }
            }
        }
    };

    [HttpGet]
    public ActionResult<IEnumerable<MediaModel>> Get()
    {
        return mediaModel;
    }
}