using Microsoft.EntityFrameworkCore;
using NossoERP.WebApi.Nuvem.Clinica.Context;

namespace NossoERP.WebApi.Nuvem.Clinica.Repository
{
    public class Repository<T> : RepositoryConsultas<T>, IRepository<T> where T : class
    {
        public Repository(AppDbContext contexto) : base(contexto)
        {
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(List<T> entitys)
        {
            _context.Set<T>().AddRange(entitys);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(List<T> entitys)
        {
            _context.Set<T>().RemoveRange(entitys);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }

        public void UpdateRange(List<T> entitys)
        {
            foreach (var entity in entitys)
                _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().UpdateRange(entitys);
        }
    }
}
