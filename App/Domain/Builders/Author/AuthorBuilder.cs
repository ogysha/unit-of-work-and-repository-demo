using System;

namespace App.Domain.Builders.Author
{
    public class AuthorBuilder : IWithAuthorId, IWithFirstName, IWithLastName, IWithBirthDate, IWithBiography,
        IBuildAuthor
    {
        private string _biography;
        private DateTime _birthDate;
        private string _firstName;
        private Guid _id;
        private string _lastName;

        public static IWithAuthorId CreateNew()
        {
            return new AuthorBuilder();
        }

        public Domain.Author Build()
        {
            return new Domain.Author(_id, _firstName, _lastName, _birthDate, _biography);
        }

        public IWithFirstName WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public IBuildAuthor WithBiography(string biography)
        {
            _biography = biography;
            return this;
        }

        public IWithBiography WithBirthDate(int year, int month, int day)
        {
            _birthDate = new DateTime(year, month, day);
            return this;
        }

        public IWithBiography WithBirthDate(DateTime birthDate)
        {
            _birthDate = birthDate;
            return this;
        }

        public IWithLastName WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public IWithBirthDate WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }
    }
}