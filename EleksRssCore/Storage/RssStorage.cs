namespace EleksRssCore
{
    using System;
    using System.Data.Entity;
    using System.Data.SQLite;
    using System.Linq;

    public class RssStorage : DbContext
    {

        public RssStorage() : base(new SQLiteConnection()
                                {
                                    ConnectionString = new SQLiteConnectionStringBuilder()
                                    {
                                        DataSource = Environment.CurrentDirectory + Properties.Settings.Default.ConnectionString,
                                        ForeignKeys = true
                                    }.ConnectionString
                                }, true)
        {
            Database.SetInitializer<RssStorage>(null);

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<RssItem> RssItems { get; set; }
    }
}