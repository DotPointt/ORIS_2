using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Entities;
using TeamHost.Persistence.Contexts;

namespace TeamHost.Persistence.Repositories;

public class LoginRepository : ILoginRepository
{
    
    private readonly ApplicationDbContext _dbContext;

    public LoginRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<User>> GetAllUser()
    {
        return await _dbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
       var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) ?? null;

       return user!;
    }
    
    public async Task<User> GetUserByName(string name)
    {
        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == name) ?? null;
        
        return user!;
    }
    
    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email) ?? null;

        return user!;
    }
}