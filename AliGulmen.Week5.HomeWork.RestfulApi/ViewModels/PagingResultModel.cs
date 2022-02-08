using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week5.HomeWork.RestfulApi.ViewModels
{
    public class PagingResultModel<T> : List<T>
    {

        public QueryParamsModel Params { get; }
        public PagingResponseModel Result { get; set; }

        public PagingResultModel(QueryParamsModel query)
        {
            Params = query;
            Result = new PagingResponseModel();
        }

        public void GetData(IQueryable<T> query)
        {

            Result.TotalCount = query.Count();
            Result.TotalPages = (int)Math.Ceiling(Result.TotalCount / (double)Params.PageSize);
            Result.CurrentPage = Params.Page;
            Result.NextPage = Result.TotalPages >= Result.CurrentPage + 1 ? Result.CurrentPage + 1 : Result.CurrentPage;
            Result.PreviousPage = Result.CurrentPage == 1 ? Result.CurrentPage : Result.CurrentPage - 1;

            List<T> result = new List<T>();

            if (!String.IsNullOrEmpty(Params.SearchQuery))
            {
                foreach (var item in query)
                {
                    var columns = item.GetType().GetProperties().ToList();
                    foreach (var column in columns)
                    {

                        if (column.GetValue(item) != null)

                        {
                            var value = column.GetValue(item);
                            bool stringFound = value.ToString().Contains(Params.SearchQuery);
                            if (stringFound)
                                result.Add(item);

                        }

                    }

                }
                result = result.Skip((Params.Page - 1) * Params.PageSize).Take(Params.PageSize).ToList();

            }
            else
                 result = query.Skip((Params.Page - 1) * Params.PageSize).Take(Params.PageSize).ToList();



          


            if (!string.IsNullOrWhiteSpace(Params.Sort))
            {


                var entity = typeof(T);

                var property = entity.GetProperty(char.ToUpper(Params.Sort[0]) + Params.Sort.Substring(1).ToLower());


                result = Params.SortingDirection == Common.SortingDirection.DESC
                    ? result.OrderByDescending(x => property.GetValue(x, null)).ToList() 
                    : result.OrderBy(x => property.GetValue(x, null)).ToList();
            }

          

            AddRange(result);
        }


   
    }
    
}
