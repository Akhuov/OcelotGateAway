namespace WepApi_1.DataAccess.Repositories
{
    public interface IBaseRepository<T>
    {
        public ValueTask<T> Create(T employee);
        public ValueTask<T> Update(int id,T employee);
        public ValueTask<List<T>> GetAll();
    }
}
