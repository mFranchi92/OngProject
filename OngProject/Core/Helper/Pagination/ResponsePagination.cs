namespace OngProject.Core.Helper.Pagination
{
    public class ResponsePagination<T>
    {
        public ResponsePagination(T data)
        {
            Data = data;
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public string NextPageUrl { get; set; }
        public string PreviousPageUrl { get; set; }
        public T Data { get; set; }
    }
}
