using NossoERP.WebApi.Nuvem.Clinica.Database;
using NossoERP.WebApi.Nuvem.Clinica.Pagination;

namespace NossoERP.WebApi.Nuvem.Clinica.Repository.Interfaces
{
    public interface ICid : IRepository<cid>
    {
        Task<PagedList<cid>> GetAllAsync(QueryStringParameters parametros);
    }
}
