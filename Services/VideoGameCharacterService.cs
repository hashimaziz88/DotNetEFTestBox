using DotNetEFTestBox.Models;

namespace DotNetEFTestBox.Services
{
    public class VideoGameCharacterService : IVideoGamesCharacterService
    {
        static List<Character> characters = new List<Character>
        {
            new Character { Id = 1, Name = "Mario", Game = "Super Mario", Role = "Hero" },
            new Character { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Hero" },
            new Character { Id = 3, Name = "Bowser", Game = "Super Mario", Role = "Villain" },
        };

        public async Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetAllCharactersAsync()
            => await Task.FromResult(characters);

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            var result = characters.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
