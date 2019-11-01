using App.Domain;

namespace App.Infrastructure.Mappers
{
    public interface IDbToDomainMapper<out TDomainEntity, in TDbEntity>
        where TDbEntity : IDbEntity
        where TDomainEntity : IAggregateRoot
    {
        TDomainEntity ToDomainEntity(TDbEntity dbEntity);
    }
}