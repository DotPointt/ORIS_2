using TeamHost.Domain.Entities;

namespace TeamHost.Application.Interfaces.Repositories
{
    public interface IGameRepository
    {
        public Task<List<Game>> GetAllGame();

        public Task<Game> GetById(int id);
    }
}
