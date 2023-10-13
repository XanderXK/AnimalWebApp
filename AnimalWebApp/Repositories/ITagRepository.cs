using AnimalWebApp.Models;

namespace AnimalWebApp.Repositories;

public interface ITagRepository
{
    public List<Tag> GetAll();
    public Tag Get(int id);
    public List<Tag> GetTagsForPost(int postId);
    public bool Add(Tag tag);
    public bool Update(Tag tag);
    public bool Delete(int id);
}