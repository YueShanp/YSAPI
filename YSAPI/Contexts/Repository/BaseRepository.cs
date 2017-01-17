using System;
using System.Data.Entity;

namespace YSAPI.Contexts
{
    public class BaseRepository<T>
        where T : DbContext
    {
        protected T _context;

        protected void SaveChanges()
        {
            if (_context != null)
            {
                _context.SaveChanges();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        private void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
