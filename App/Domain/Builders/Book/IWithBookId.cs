using System;

namespace App.Domain.Builders.Book
{
    public interface IWithBookId
    {
        IWithTitle WithId(Guid id);
    }
}