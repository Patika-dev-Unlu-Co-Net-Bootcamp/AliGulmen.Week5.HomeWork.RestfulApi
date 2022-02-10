using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Repositories
{
    public class InMemStockRepository : IStockRepository
    {

        private readonly IDistributedCache _distributedCache;

        public InMemStockRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        private static List<Stock> stockList = new()
        {
            new Stock { ProductId = 1, ReadyToShip = 12, StockOnRack = 145 },
            new Stock { ProductId = 2, ReadyToShip = 55, StockOnRack = 425 },
            new Stock { ProductId = 3, ReadyToShip = 47, StockOnRack = 123 },
            new Stock { ProductId = 4, ReadyToShip = 34, StockOnRack = 262 },
            new Stock { ProductId = 5, ReadyToShip = 23, StockOnRack = 190 },
            new Stock { ProductId = 6, ReadyToShip = 17, StockOnRack = 43 },
            new Stock { ProductId = 7, ReadyToShip = 0, StockOnRack = 0 },
            new Stock { ProductId = 8, ReadyToShip = 23, StockOnRack = 21 }
        };


        public static List<Stock> StockListOut { get => stockList; }
        private Stock _model = new Stock();
        private int _stockId;




        public List<Stock> GetStocks()
        {
            var cachedStocks = _distributedCache.Get("stockList");


            if (cachedStocks == null)
            {
                var stocks = stockList.OrderBy(u => u.ProductId).ToList<Stock>();

                if (stocks.Count >= 100)
                {
                    var cacheOptions = new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(30)
                    };

                    _distributedCache.Set("stockList", Encoding.UTF8.GetBytes(stocks.ToString()), cacheOptions);

                }

                return stocks;
            }
            else
            {
                return JsonConvert.DeserializeObject<List<Stock>>(Encoding.UTF8.GetString(cachedStocks));

            }



        }




        public void UpdateStock(int stockId, Stock newStock)
        {
            _model = newStock;
            _stockId = stockId;

            if (_model is null)
                throw new InvalidOperationException("No data entered!");


            var stock = stockList.SingleOrDefault(u => u.Id == _stockId);
            if (stock is null)
                throw new InvalidOperationException("Stock is not found!");


            stock.ProductId = _model.ProductId != default ? _model.ProductId : stock.ProductId;
            stock.ReadyToShip = _model.ReadyToShip != default ? _model.ReadyToShip : stock.ReadyToShip;
            stock.StockOnRack = _model.StockOnRack != default ? _model.StockOnRack : stock.StockOnRack;
            _distributedCache.Remove("stockList");
        }

        public void CreateStock(Stock newStock)
        {
            _model = newStock;

            if (_model == null)
                throw new InvalidOperationException("No data entered!");

            var stock = stockList.SingleOrDefault(u => u.Id == _model.Id);

            if (stock is not null)
                throw new InvalidOperationException("You already have this uomCode in your list!");

            stock = _model;
            _distributedCache.Remove("stockList");
            stockList.Add(stock);
        }
    }
}
