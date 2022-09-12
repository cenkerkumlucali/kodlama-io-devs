using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class SocialPlatform:Entity
{
    public int UserId { get; set; }
    public string Name { get; set; }
    
    public virtual User? User { get; set; }

    public SocialPlatform()
    {
        
    }

    public SocialPlatform(int id, int userId, string name) : this()
    {
        Id = id;
        UserId = userId;
        Name = name;
    }
}