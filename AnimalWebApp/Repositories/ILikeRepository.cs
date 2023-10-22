namespace AnimalWebApp.Repositories;

public interface ILikeRepository
{
    public int GetLikeCount(int postId);
}