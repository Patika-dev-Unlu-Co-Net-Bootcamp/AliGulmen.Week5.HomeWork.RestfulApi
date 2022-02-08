namespace AliGulmen.Week5.HomeWork.RestfulApi.ViewModels
{
    public class PagingResponseModel
    {
        public int TotalCount { get; set; } = 0;
        public int TotalPages { get; set; } = 1;
        public int CurrentPage { get; set; } = 1;
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }


    }
}
