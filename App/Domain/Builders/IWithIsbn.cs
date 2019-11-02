namespace App.Domain.Builders
{
    public interface IWithIsbn
    {
        IWithReleaseDate WithIsbn13(string isbn);
    }
}