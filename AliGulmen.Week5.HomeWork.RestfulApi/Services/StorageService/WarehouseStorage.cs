using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories.ContainerRepositories;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Services.StorageService
{
    public class WarehouseStorage : IStorageService
    {
        private readonly IStockRepository _repository;

        public WarehouseStorage(IStockRepository repository)
        {
            _repository = repository;
        }
        public void AddToStock(Container container)
        {
            
           
            var stock = _repository.GetStocks().FirstOrDefault(s => s.ProductId == container.ProductId);
            if (stock != null)
                stock.StockOnRack += 1;
            else
                _repository.CreateStock(new Stock { ProductId = container.ProductId, ReadyToShip = 0, StockOnRack = 1 });
        }

        public void Locate(Container container)
        {
            container.LocationId = 2;
        }
    }
}
