using System;

namespace App.Domain.Builders.Author
{
    public class AuthorBuilder : IWithAuthorId, IWithFirstName, IWithLastName, IBuildAuthor
    {
        private string _firstName;
        private Guid _id;
        private string _lastName;

        public Domain.Author Build()
        {
            return new Domain.Author(_id, _firstName, _lastName);
        }

        public IWithFirstName WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public IWithLastName WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public IBuildAuthor WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public static IWithAuthorId CreateNew()
        {
            return new AuthorBuilder();
        }
    }
}