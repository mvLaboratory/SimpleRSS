using System;

namespace EleksRssCore
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork(RssStorage context)
        {
            _context = context;
            _categoryRepository = new GenericRepository<Category>(_context);
            _feedRepository = new GenericRepository<RssItem>(_context);
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                return this._categoryRepository ?? new GenericRepository<Category>(_context);
            }
        }

        public GenericRepository<RssItem> FeedRepository
        {
            get
            {
                return this._feedRepository ?? new GenericRepository<RssItem>(_context);
            }
        }

        public IStorage RssStorage { get
            {
                return _context;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private RssStorage _context;
        private GenericRepository<Category> _categoryRepository;
        private GenericRepository<RssItem> _feedRepository;
        private bool disposed = false;
    }
}
