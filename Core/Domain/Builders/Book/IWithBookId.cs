using System;

namespace Core.Domain.Builders.Book
{
    public interface IWithBookId
    {
        IWithTitle WithId(Guid id);
    }
}