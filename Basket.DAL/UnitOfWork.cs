﻿using Basket.DAL.Context;

namespace Basket.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
