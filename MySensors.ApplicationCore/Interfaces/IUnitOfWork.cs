using System;
using System.Threading.Tasks;

namespace MySensors.ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;
        Task<bool> SaveChanges();
    }
}