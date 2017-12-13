using DotNetNuke.Collections;

namespace Connect.ApiBrowser.Core.Common
{
    public class SerializedPagedList<T>
    {
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public IPagedList<T> data { get; set; }
    }
}
