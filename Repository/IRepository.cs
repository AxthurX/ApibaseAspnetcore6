namespace NossoERP.WebApi.Nuvem.Clinica.Repository
{
    public interface IRepository<T> : IRepositoryConsultas<T>
    {
        void Add(T entity);
        void AddRange(List<T> entitys);
        void Update(T entity);
        void UpdateRange(List<T> entitys);
        void Delete(T entity);
        void DeleteRange(List<T> entitys);
    }
}
