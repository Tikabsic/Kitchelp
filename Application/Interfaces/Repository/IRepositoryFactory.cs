namespace Application.Interfaces.Repository
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> Create<TEntity>() where TEntity : class;
    }
}
