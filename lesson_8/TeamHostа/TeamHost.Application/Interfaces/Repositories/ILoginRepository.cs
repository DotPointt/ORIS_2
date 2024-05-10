using TeamHost.Domain.Entities;

namespace TeamHost.Application.Interfaces.Repositories;

public interface ILoginRepository
{
    public Task<List<User>> GetAllUser();

    public Task<User> GetUserById(int id);
    
    public Task<User> GetUserByName(string name);
    
    public Task<User> GetUserByEmail(string email);

}