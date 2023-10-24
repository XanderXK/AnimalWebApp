using AnimalWebApp.Models;

namespace AnimalWebApp.Repositories;

public interface ICommentRepository
{
    public ICollection<Comment> GetAll();
    public bool Add(Comment comment);
}