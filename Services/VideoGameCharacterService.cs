using DotNetEFTestBox.Data;
using DotNetEFTestBox.Dtos;
using DotNetEFTestBox.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetEFTestBox.Services
{
    public class VideoGameCharacterService (AppDbContext context) : IVideoGamesCharacterService
    {
        private readonly AppDbContext _context = context;

        public async Task<CharacterResponse> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CharacterResponse>> GetAllCharactersAsync()
            => await _context.Characters.Select(c => new CharacterResponse
            {
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).ToListAsync();

        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            var result = await _context.Characters
                .Where(c => c.Id == id)
                .Select(c => new CharacterResponse
                {
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
