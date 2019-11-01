namespace App.Domain.Builders.Book
{
    public interface IWithIsbn
    {
        IWithReleaseDate WithIsbn13(string isbn);
    }
}