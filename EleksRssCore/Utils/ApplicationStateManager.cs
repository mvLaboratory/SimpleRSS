using System;

namespace EleksRssCore
{
    public class ApplicationStateManager
    {
        public static Category currentCategory { get; set; }
        public static Int32 itemsPerPage
        {
            get
            {
                return 10;
            }
        }
        public static Int32 currentPage { get; set; }
        public static Int32 pageCount {
            get
            {
                return _pageCount;
            }
            set
            {
                _pageCount = (Int32) Math.Ceiling((Double)(value / itemsPerPage));
            }
        }

        private static Int32 _pageCount;
    }
}
