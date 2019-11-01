using System;

namespace App.Domain.Builders.Author
{
    public interface IWithBirthDate
    {
        IWithBiography WithBirthDate(int year, int month, int day);
        IWithBiography WithBirthDate(DateTime birthDate);
    }
}