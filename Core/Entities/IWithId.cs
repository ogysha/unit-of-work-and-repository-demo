using Core.Entities.Builder;

namespace Core.Entities
{
    public interface IWithId
    {
        IWithBookName WithId(string id);
    }
}