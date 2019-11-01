namespace App.Domain.Builders.Book
{
    public interface IWithPublisher
    {
        IWithAuthors WithPublisher(string publisher);
    }
}