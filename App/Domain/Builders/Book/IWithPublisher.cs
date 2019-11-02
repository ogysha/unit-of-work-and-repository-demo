namespace App.Domain.Builders.Book
{
    public interface IWithPublisher
    {
        IWithAuthor WithPublisher(string publisher);
    }
}