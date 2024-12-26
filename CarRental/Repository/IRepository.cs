namespace CarRental.Repository {
    public interface IRepository<T> where T : class {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id, QueryOption<T> options);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
