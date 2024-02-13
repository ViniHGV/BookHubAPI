namespace BookHub.API.Contract
{
    public interface IGenericRepository<TEntity, TEntityDTO, TEntityUpdate>
    {
        Task<TEntity> GetById(int id, int pageSkip);
        Task<List<TEntity>> GetAll(int pageSkip);
        Task<bool> Delete(int id);
        void Save();
        Task<bool> Update(int id, TEntityUpdate entityDTO);
        Task<bool> Create(TEntityDTO entityDTO);
    }
}