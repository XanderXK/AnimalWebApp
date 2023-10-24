using AnimalWebApp.Models;

namespace AnimalWebApp.Repositories;

public interface ILikeRepository
{
    public int GetLikeCount(int postId);
    public bool ToggleLike(Like like);
}