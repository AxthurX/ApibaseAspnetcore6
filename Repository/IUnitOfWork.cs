using NossoERP.WebApi.Nuvem.Clinica.Repository.Interfaces;

namespace NossoERP.WebApi.Nuvem.Clinica.Repository
{
    public interface IUnitOfWork
    {
        ICid cid { get; }
        Task CommitAsync();
        int ExecuteSqlRaw(string sql, params object[] parameters);
    }
}
