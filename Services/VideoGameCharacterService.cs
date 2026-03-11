using DotNetEFTestBox.Data;
using DotNetEFTestBox.Dtos;
using DotNetEFTestBox.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetEFTestBox.Services
{
    public class VideoGameCharacterService (AppDbContext context) : IVideoGamesCharacterService
    {
        private readonly AppDbContext _context = context;

        public async Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character)
        {
            var newCharacter = new Character
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };
            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();
            return new CharacterResponse
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Role = newCharacter.Role
            };
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
                return false;

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CharacterResponse>> GetAllCharactersAsync()
            => await _context.Characters.Select(c => new CharacterResponse
            {
                Id = c.Id,
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
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        {
            var existingCharacter = await _context.Characters.FindAsync(id);

            if (existingCharacter == null) return false;

            existingCharacter.Name = character.Name;
            existingCharacter.Game = character.Game;
            existingCharacter.Role = character.Role;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
