using NossoERP.WebApi.Nuvem.Clinica.Pagination;
using System.Linq.Expressions;

namespace NossoERP.WebApi.Nuvem.Clinica.Repository
{
    public interface IRepositoryConsultas<T>
    {
        /// <summary>
        /// Retorno o IQueryable
        /// </summary>
        IQueryable<T> GetIQueryable();
        /// <summary>
        /// Consulta personalizada
        /// </summary>
        Task<T> GetByPredicateAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetByPredicateToListAsync(Expression<Func<T, bool>> predicate);
    }

    public interface IRepositoryConsultasBanco<T> : IRepositoryConsultas<T>
    {
        Task<PagedList<T>> GetAllAsync(QueryStringParameters parametros, int id_banco_dados);
    }
}
