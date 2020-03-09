namespace WeatherForecast.Core.Paging
{
    public class PagedResponse<TResponse>
    {
        public PagedResponse(int total, int itemsPerPage, int pageNumber, params TResponse[] data)
        {
            ItemsCount = total;
            ItemsPerPage = itemsPerPage;
            PageNumber = pageNumber;
            Data = data;
        }

        public int ItemsCount { get; }

        public int ItemsPerPage { get; }

        public int PageNumber { get; }

        public TResponse[] Data { get; }
    }
}
