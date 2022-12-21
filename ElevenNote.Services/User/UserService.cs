using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
       private readonly ApplicationDbContext _context;
    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        var entity = new UserEntity
        {
            Email=model.Email,
            Username=model.UserName,
            Password =model.Password,
            DateCreated =DateTime.UtcNow
        };

        _context.Users.Add(entity); 
        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    
    }
    private async Task<UserEntity> GetUserEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(UserEntity=> UserEntity.Email.ToLower() == email.ToLower());

    }
}
