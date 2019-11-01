namespace Core.Entities.Builder
{
    public interface IWithBookName
    {
        IBuildable WithBookName(string bookName);
    }
}