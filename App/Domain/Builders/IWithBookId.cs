using System;

namespace App.Domain.Builders
{
    public interface IWithBookId
    {
        IWithTitle WithId(Guid id);
    }
}