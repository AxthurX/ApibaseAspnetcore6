using Microsoft.EntityFrameworkCore;
using NossoERP.WebApi.Nuvem.Clinica.Context;
using NossoERP.WebApi.Nuvem.Clinica.Repository.Interfaces;
using NossoERP.WebApi.Nuvem.Clinica.Repository.Models;

namespace NossoERP.WebApi.Nuvem.Clinica.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Cid _cidRep;
        public AppDbContext _context;
        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }

        public ICid cid
        {
            get
            {
                return _cidRep = _cidRep ?? new Cid(_context);
            }
        }
        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int ExecuteSqlRaw(string sql, params object[] parameters)
        {
            return _context.Database.ExecuteSqlRaw(sql, parameters);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
