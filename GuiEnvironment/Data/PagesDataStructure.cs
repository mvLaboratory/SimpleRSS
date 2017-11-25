using EleksRssCore;
using System;

namespace GuiEnvironment
{
    public struct PagesDataStructure
    {
        public Int32 CurrentPage {
            get 
            {
                return ApplicationStateManager.currentPage;
            }
        }

        public Int32 PageCount {
            get {
                return ApplicationStateManager.pageCount;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} / {1}", CurrentPage, PageCount);
        }
    }
}
