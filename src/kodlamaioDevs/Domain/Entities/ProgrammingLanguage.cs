using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Entities;

public class ProgrammingLanguage:Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Technology> Technologies { get; set; }

    public ProgrammingLanguage()
    {
        
    }

    public ProgrammingLanguage(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}