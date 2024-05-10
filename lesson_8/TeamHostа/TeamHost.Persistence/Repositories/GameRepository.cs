using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Entities;
using TeamHost.Persistence.Contexts;

namespace TeamHost.Persistence.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GameRepository( ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Game>> GetAllGame()
        {
            var t =  await _dbContext.Games
                .AsNoTracking()
                .Include(x => x.Images)
                .Include(x => x.Platforms)
                .Include(x => x.Category)
                .ToListAsync();
            
            return t;
        }

        public async Task<Game> GetById(int id)
        {
            var game = await _dbContext.Games.AsNoTracking()
                .Include(x => x.Images)
                .Include(x => x.Platforms)
                .Include(x => x.Category)
                .Include(x => x.Company)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (game == null)
                return new Game();

            return game;
        }
    }
}
