using EleksRssCore;
using System;

namespace GuiEnvironment
{
    public class GuiManager
    {
        public static void setCurrentCategory(Category currCat)
        {
            ApplicationStateManager.currentCategory = currCat;
        }

        public static void setCurrentPage(Int32 pageOffset)
        {
            Int32 currentPage = ApplicationStateManager.currentPage + pageOffset;
            currentPage = Math.Max(1, currentPage);
            currentPage = Math.Min(ApplicationStateManager.pageCount, currentPage);
            ApplicationStateManager.currentPage = currentPage;
        }
    }
}
