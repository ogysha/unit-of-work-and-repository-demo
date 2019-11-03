using System;

namespace Core.Domain.Builders.Author
{
    public interface IWithAuthorId 
    {
        IWithFirstName WithId(Guid id);
    }
}