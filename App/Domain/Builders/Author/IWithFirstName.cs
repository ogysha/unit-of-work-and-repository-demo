namespace App.Domain.Builders.Author
{
    public interface IWithFirstName
    {
        IWithLastName WithFirstName(string firstName);
    }
}