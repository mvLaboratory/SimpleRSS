namespace EleksRssCore
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RssStorage : DbContext
    {

        public RssStorage() : base("Data Source = ~\\Storage\\RssDB.sqlite")
        {
            Database.SetInitializer<RssStorage>(new Initializer());
            Database.Initialize(true);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Category> Categories { get; set; }
    }
}