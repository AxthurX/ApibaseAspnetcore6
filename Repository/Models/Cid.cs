using NossoERP.WebApi.Nuvem.Clinica.Context;
using NossoERP.WebApi.Nuvem.Clinica.Database;
using NossoERP.WebApi.Nuvem.Clinica.Pagination;
using NossoERP.WebApi.Nuvem.Clinica.Repository.Interfaces;


namespace NossoERP.WebApi.Nuvem.Clinica.Repository.Models
{
    public class Cid : Repository<cid>, ICid
    {
        public Cid(AppDbContext contexto) : base(contexto)
        {
        }

        public Task<PagedList<cid>> GetAllAsync(QueryStringParameters parametros)
        {
            return PagedList<cid>.ToPagedListAsync(GetIQueryable().OrderBy(on => on.codigo).ThenBy(c => c.descricao),
                               parametros.PageNumber,
                               parametros.PageSize);
        }
    }
}
