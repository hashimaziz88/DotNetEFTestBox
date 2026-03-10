using DotNetEFTestBox.Models;
using DotNetEFTestBox.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetEFTestBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesCharactersController(IVideoGamesCharacterService service) : ControllerBase
    {



        [HttpGet]

        public async Task<ActionResult<List<Character>>> GetCharacters()
            => Ok(await service.GetAllCharactersAsync());
    }
}
