namespace api.interfaces
{
    public interface iRepository<T>
    {
         T GetByID(int id);
         List<T> GetAll();
         void Add(T item);
         void Update(T item);
         void Delete(int id);
    }
}