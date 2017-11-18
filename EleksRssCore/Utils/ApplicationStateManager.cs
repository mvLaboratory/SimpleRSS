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
        public static Int32 currentPage {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
            }
        }

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

        private static Int32 _pageCount = 0;
        private static Int32 _currentPage = 1;
    }
}
