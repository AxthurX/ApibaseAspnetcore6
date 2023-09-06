using Microsoft.EntityFrameworkCore;
using NossoERP.WebApi.Nuvem.Clinica.Context;
using System.Linq.Expressions;

namespace NossoERP.WebApi.Nuvem.Clinica.Repository
{
    public class RepositoryConsultas<T> : IRepositoryConsultas<T> where T : class
    {
        protected AppDbContext _context;

        public RepositoryConsultas(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IQueryable<T> GetIQueryable()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public Task<T> GetByPredicateAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public Task<List<T>> GetByPredicateToListAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }
    }
}
