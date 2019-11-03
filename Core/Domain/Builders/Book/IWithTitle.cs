namespace Core.Domain.Builders.Book
{
    public interface IWithTitle
    {
        IWithIsbn WithTitle(string title);
    }
}