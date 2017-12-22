using System;

namespace EleksRssCore
{
    public class ConfigurationProvider
    {
        public static Int32 UpdateInterval
        {
            get
            {
                return _updateInterval;
            }
        }

        public static Int32 ItemsPerPage
        {
            get
            {
                return _itemsPerPage;
            }
        }

        private static Int32 _updateInterval = 60000;
        private static Int32 _itemsPerPage = 10;
    }
}
