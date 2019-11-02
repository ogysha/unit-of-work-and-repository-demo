namespace App.Domain.Builders.Book
{
    public interface IWithAuthor
    {
        IBuildBook WithAuthor(Domain.Author author);
    }
}