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

        private static Int32 _updateInterval = 600000;
    }
}
