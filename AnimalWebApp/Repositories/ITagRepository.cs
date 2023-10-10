using AnimalWebApp.Models;

namespace AnimalWebApp.Repositories;

public interface ITagRepository
{
    public List<Tag> GetAll();
    public Tag Get(int id);
    public bool Add(Tag tag);
    public bool Delete(int id);
    public bool Update(Tag tag);
}