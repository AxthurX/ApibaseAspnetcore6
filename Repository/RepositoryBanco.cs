using NossoERP.WebApi.Nuvem.Clinica.Context;
using NossoERP.WebApi.Nuvem.Clinica.Pagination;

namespace NossoERP.WebApi.Nuvem.Clinica.Repository
{
    public class RepositoryBanco<T> : Repository<T> where T : class, IPesquisaPorBanco, new()
    {
        public RepositoryBanco(AppDbContext contexto) : base(contexto)
        {
        }

        public Task<PagedList<T>> GetAllAsync(QueryStringParameters parametros, int id_banco_dados)
        {
            return PagedList<T>.ToPagedListAsync(GetIQueryable().Where(c => c.id_banco_dados == id_banco_dados).OrderBy(c => c.id_banco_dados),
                                parametros.PageNumber,
                                parametros.PageSize);
        }
    }
}
