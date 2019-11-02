using System;

namespace App.Domain.Builders.Author
{
    public interface IWithAuthorId 
    {
        IWithFirstName WithId(Guid id);
    }
}