using AliGulmen.Week5.HomeWork.RestfulApi.Common;

namespace AliGulmen.Week5.HomeWork.RestfulApi.ViewModels
{
    public class QueryParamsModel
    {
        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
        public string Sort { get; set; } = "Id";

        public string SearchQuery { get; set; } = string.Empty;
        public SortingDirection SortingDirection { get; set; }

    }
}
