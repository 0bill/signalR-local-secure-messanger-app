using System;
using Database.Repositories;

namespace Database
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        int Save();
    }
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SQLiteContext _context;
        public IUserRepository UserRepository { get; }

        public UnitOfWork()
        {
            _context = new SQLiteContext();
            UserRepository = new UserRepository(_context);
        }

        public UnitOfWork(SQLiteContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}