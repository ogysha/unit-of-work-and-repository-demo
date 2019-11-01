namespace App.Domain.Builders.Book
{
    public interface IWithAuthors
    {
        IBuildBook WithAuthors(params Domain.Author[] authors);
    }
}