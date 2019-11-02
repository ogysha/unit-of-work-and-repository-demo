namespace App.Domain.Builders
{
    public interface IWithAuthor
    {
        IBuildBook WithAuthor(string author);
    }
}