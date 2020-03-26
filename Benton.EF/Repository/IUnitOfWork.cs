// https://gunnarpeipman.com/aspnet/defensive-database-context/
// https://aspnetboilerplate.com/Pages/Documents/Articles/Developing-MultiTenant-SaaS-ASP.NET-CORE-Angular/index.html

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Benton.EF.Repository {
    public interface IUnitOfWork: IDisposable
    {
        T GetRepository<T>() where T : class;
        void Save();

        Task SaveAsync();

    }
    
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext: DbContext
    {
        private bool disposed = false;
        protected readonly TContext _context;
        
        public UnitOfWork(TContext context) {
            this._context = context;
        }

        public T GetRepository<T>() where T : class
        {
            var result = (T)Activator.CreateInstance(typeof(T), this._context);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public virtual void Save()
        {
            var entities = (from entry in _context.ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                {
                    throw new ValidationException();
                }
            }

            _context.SaveChanges();
        }

        public virtual Task SaveAsync()
        {
            var entities = (from entry in _context.ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                {
                    throw new ValidationException();
                }
            }

            return _context.SaveChangesAsync();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed) {
                if (disposing) {
                    this._context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}