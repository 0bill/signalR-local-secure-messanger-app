using System;
using Database.Repositories;

namespace Database
{
    public interface IUnitOfWork : IDisposable
    {
        ILoginUserRepository LoginUserRepository { get; }
        IUsersRepository UsersRepository { get; }
        IMessageRepository MessageRepository { get; }
        
        IConversationRepository ConversationRepository { get; }
        int Save();
    }
    
    public class UnitOfWork : IUnitOfWork
    {
        private SQLiteContext _context;
        public ILoginUserRepository LoginUserRepository { get; }
        public IUsersRepository UsersRepository { get; }
        public IMessageRepository MessageRepository { get; }

        public IConversationRepository ConversationRepository { get; }

        public UnitOfWork()
        {
            _context = new SQLiteContext();
            LoginUserRepository = new LoginUserRepository(_context);
            UsersRepository = new UsersRepository(_context);
            ConversationRepository = new ConversationRepository(_context);
            MessageRepository = new MessageRepository(_context);
        }

        public UnitOfWork(SQLiteContext context)
        {
            _context = context;
            LoginUserRepository = new LoginUserRepository(_context);
            UsersRepository = new UsersRepository(_context);
            ConversationRepository = new ConversationRepository(_context);
            MessageRepository = new MessageRepository(_context);
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