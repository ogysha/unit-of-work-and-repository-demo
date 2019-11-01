using App.Domain;

namespace App.Infrastructure.Mappers
{
    public interface IDomainToDbMapper<out TDbEntity, in TDomainEntity>
        where TDbEntity : IDbEntity
        where TDomainEntity : IAggregateRoot
    {
        TDbEntity ToDbEntity(TDomainEntity domainEntity);
    }
}