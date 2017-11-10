using System;

namespace EleksRssCore
{
    class UnitOfWork : IDisposable
    {
        private IStorage context = new RssStorage();
        private GenericRepository<ICategory> categoryRepository;
        private GenericRepository<IFeedItem> feedRepository;

        public GenericRepository<ICategory> DepartmentRepository
        {
            get
            {
                return this.categoryRepository ?? new GenericRepository<ICategory>(context);
            }
        }

        public GenericRepository<IFeedItem> CourseRepository
        {
            get
            {
                return this.feedRepository ?? new GenericRepository<IFeedItem>(context);
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
