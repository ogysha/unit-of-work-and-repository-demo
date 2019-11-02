namespace App.Domain.Builders
{
    public interface IWithTitle
    {
        IWithIsbn WithTitle(string title);
    }
}