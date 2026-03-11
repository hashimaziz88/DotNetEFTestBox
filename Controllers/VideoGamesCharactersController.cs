using DotNetEFTestBox.Dtos;
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
        public async Task<ActionResult<List<CharacterResponse>>> GetCharacters()
            => Ok(await service.GetAllCharactersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharacter(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            if (character is null)
                return NotFound("Character with given Id not found");
            return Ok(character);

        }
    }
}
