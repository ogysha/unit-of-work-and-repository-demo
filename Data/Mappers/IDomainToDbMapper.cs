using App.Domain;
using Data.Entities;

namespace Data.Mappers
{
    public interface IDomainToDbMapper<out TDbEntity, in TDomainEntity>
        where TDbEntity : IDbEntity
        where TDomainEntity : IAggregateRoot
    {
        TDbEntity ToDbEntity(TDomainEntity domainEntity);
    }
}