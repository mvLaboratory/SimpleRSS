using EleksRssCore;

namespace GuiEnvironment
{
    public class GuiManager
    {
        public static void setCurrentCategory(Category currCat)
        {
            ApplicationStateManager.currentCategory = currCat;
        }
    }
}
