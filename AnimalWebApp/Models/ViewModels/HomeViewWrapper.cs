namespace AnimalWebApp.Models.ViewModels;

public class HomeViewWrapper
{
    public List<AnimalPost> Posts { get; private set; }
    public List<Tag> Tags { get; private set; }

    public HomeViewWrapper(List<AnimalPost> animalPosts, List<Tag> tags)
    {
        Posts = animalPosts;
        Tags = tags;
    }
}