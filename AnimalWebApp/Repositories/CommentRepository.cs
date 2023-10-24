using AnimalWebApp.Data;
using AnimalWebApp.Models;

namespace AnimalWebApp.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly DataContext _dataContext;


    public CommentRepository(IConfiguration configuration)
    {
        _dataContext = new DataContext(configuration);
    }

    public ICollection<Comment> GetAll()
    {
        var sql = $"SELECT * FROM Comments";
        return _dataContext.LoadData<Comment>(sql);
    }

    public bool Add(Comment comment)
    {
        var sql = $"INSERT INTO Comments ([Description], [AnimalPostId], [UserId]) VALUES ('{comment.Description}', {comment.AnimalPostId}, '{comment.UserId}')";
        return _dataContext.Execute(sql);
    }
}