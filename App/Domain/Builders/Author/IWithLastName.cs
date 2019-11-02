namespace App.Domain.Builders.Author
{
    public interface IWithLastName
    {
        IBuildAuthor WithLastName(string lastName);
    }
}