using System;

namespace EleksRssCore
{
    public class UnitOfWork : IDisposable
    {
        private IStorage context = new RssStorage();
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<RssItem> feedRepository;

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                return this.categoryRepository ?? new GenericRepository<Category>(context);
            }
        }

        public GenericRepository<RssItem> FeedRepository
        {
            get
            {
                return this.feedRepository ?? new GenericRepository<RssItem>(context);
            }
        }

        public IStorage RssStorage { get
            {
                return context;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
