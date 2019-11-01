using System;
using System.Linq;
using App.Domain;
using App.Infrastructure;
using Data.Mappers.Abstractions;

namespace Data.Repositories.EF
{
    public class AuthorRepository : IAuthorRepository, IUnitOfWorkRepository
    {
        private readonly IAuthorMapper _authorMapper;
        private readonly BookStoreDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorRepository(IUnitOfWork unitOfWork, IAuthorMapper authorMapper,
            BookStoreDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _authorMapper = authorMapper;
            _dbContext = dbContext;
        }

        public Author FindById(Guid id)
        {
            var authorDbEntity = _dbContext.Authors.FirstOrDefault(a => a.Id == id);

            return authorDbEntity != null
                ? _authorMapper.ToDomainEntity(authorDbEntity)
                : null;
        }

        public void Add(Author author)
        {
            _unitOfWork.RegisterAdded(author, this);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            var author = (Author) entity;

            var authorDbEntity = _authorMapper.ToDbEntity(author);
            _dbContext.Authors.Add(authorDbEntity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }
    }
}