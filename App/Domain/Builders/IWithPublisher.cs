namespace App.Domain.Builders
{
    public interface IWithPublisher
    {
        IWithAuthor WithPublisher(string publisher);
    }
}