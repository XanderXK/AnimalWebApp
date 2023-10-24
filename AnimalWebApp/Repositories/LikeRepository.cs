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

    public bool ToggleLike(Like like)
    {
        var sqlLiked = $"SELECT Count(*) FROM Likes WHERE PostId = {like.AnimalPostId} AND UserId = '{like.UserId}'";
        var liked = _dataContext.LoadSingleData<int>(sqlLiked) > 0;
        if (liked)
        {
            var sql = $"DELETE FROM Likes WHERE PostId = {like.AnimalPostId} AND UserId = '{like.UserId}'";
            return _dataContext.Execute(sql);
        }
        else
        {
            var sql = $"INSERT INTO Likes (PostId, UserId) VALUES ({like.AnimalPostId}, '{like.UserId}')";
            return _dataContext.Execute(sql);
        }
    }
}