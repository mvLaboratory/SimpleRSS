namespace PagingModule
{
    public class PagingViewModule : IPagingViewModule
    {
        public string PagingText
        {
            get
            {
                return string.Format("Page {0} From {1}", 0, 0);
            }
        }
    }
}
