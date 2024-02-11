namespace BookHub.API.Contract
{
    public interface IRepositoryGeneric<TEntity>
    {
        Task<TEntity> GetById(int id);
        Task<TEntity> GetAll();
        Task<bool> Delete(int id);
        void Save();
        Task<bool> Update(int id, TEntity entity);
    }
}