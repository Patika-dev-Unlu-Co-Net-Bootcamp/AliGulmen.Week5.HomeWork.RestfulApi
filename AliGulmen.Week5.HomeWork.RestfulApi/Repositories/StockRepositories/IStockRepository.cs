using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using System.Collections.Generic;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Repositories
{
    public interface IStockRepository
    {
        List<Stock> GetStocks();
        void UpdateStock(int stockId, Stock newStock);

        void CreateStock(Stock newStock);
    }
}
