using AnimalWebApp.Data;
using AnimalWebApp.Models;

namespace AnimalWebApp.Repositories;

public class LikeRepository : ILikeRepository
{
    private readonly DataContext _dataContext;

    public LikeRepository(IConfiguration configuration)
    {
        _dataContext = new DataContext(configuration);
    }

    public int GetLikeCount(int postId)
    {
        var sql = $"SELECT Count(*) FROM Likes WHERE PostId = {postId}";
        var result = _dataContext.LoadSingleData<int>(sql);
        return result;
    }

    public bool AddLike(Like like)
    {
        var sql = $"INSERT INTO Likes (PostId, UserId) VALUES ({like.AnimalPostId}, '{like.UserId}')";
        Console.WriteLine(sql);
        return _dataContext.Execute(sql);
    }
}