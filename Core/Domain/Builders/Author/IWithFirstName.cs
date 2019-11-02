namespace Core.Domain.Builders.Author
{
    public interface IWithFirstName
    {
        IWithLastName WithFirstName(string firstName);
    }
}