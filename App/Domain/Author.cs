using System;

namespace App.Domain
{
    public class Author : IAggregateRoot
    {
        public Author(Guid id, string firstName, string lastName, DateTime birthDate, string biography)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Biography = biography;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public string Biography { get; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(BirthDate)}: {BirthDate}, {nameof(Biography)}: {Biography}";
        }
    }
}