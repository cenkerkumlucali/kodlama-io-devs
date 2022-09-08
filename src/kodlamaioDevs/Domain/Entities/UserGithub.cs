using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class UserGithub:Entity
{
    public int UserId { get; set; }
    public string Name { get; set; }
    
    public virtual User? User { get; set; }

    public UserGithub()
    {
        
    }

    public UserGithub(int id, int userId, string name) : this()
    {
        Id = id;
        UserId = userId;
        Name = name;
    }
}