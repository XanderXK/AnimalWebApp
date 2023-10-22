using AnimalWebApp.Data;

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
}