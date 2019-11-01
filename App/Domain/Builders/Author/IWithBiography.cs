namespace App.Domain.Builders.Author
{
    public interface IWithBiography
    {
        IBuildAuthor WithBiography(string biography);
    }
}