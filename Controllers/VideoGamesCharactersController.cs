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

        [HttpPost]
        public async Task<ActionResult<CharacterResponse>> AddCharacter(CreateCharacterRequest character)
        {
            var newCharacter = await service.AddCharacterAsync(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = newCharacter.Id }, newCharacter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, UpdateCharacterRequest character)
        {
            var updated = await service.UpdateCharacterAsync(id, character);
            if (!updated)
                return NotFound("Character with given Id not found");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var deleted = await service.DeleteCharacterAsync(id);
            if (!deleted)
                return NotFound("Character with given Id not found");
            return NoContent();
        }
    }
}
