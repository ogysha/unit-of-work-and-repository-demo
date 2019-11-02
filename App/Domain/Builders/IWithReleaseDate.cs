using System;

namespace App.Domain.Builders
{
    public interface IWithReleaseDate
    {
        IWithPublisher WithReleaseDate(DateTime releaseDate);
        IWithPublisher WithReleaseDate(int year, int month, int day = 1);
    }
}