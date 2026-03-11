using DotNetEFTestBox.Dtos;
using DotNetEFTestBox.Models;

namespace DotNetEFTestBox.Services
{
    public interface IVideoGamesCharacterService
    {
        Task<List<CharacterResponse>> GetAllCharactersAsync();

        Task<CharacterResponse?> GetCharacterByIdAsync(int id);

        Task<CharacterResponse> AddCharacterAsync(Character character);
        Task<bool> UpdateCharacterAsync(int id, Character character);

        Task<bool> DeleteCharacterAsync(int id);
    }
}
