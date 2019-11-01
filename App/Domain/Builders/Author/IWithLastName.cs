namespace App.Domain.Builders.Author
{
    public interface IWithLastName
    {
        IWithBirthDate WithLastName(string lastName);
    }
}