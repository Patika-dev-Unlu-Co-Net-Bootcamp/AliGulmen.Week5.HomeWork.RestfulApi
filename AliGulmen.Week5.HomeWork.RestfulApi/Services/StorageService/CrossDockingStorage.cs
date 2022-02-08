using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories.ContainerRepositories;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Services.StorageService
{

    public class CrossDockingStorage : IStorageService
    {
        private readonly IStockRepository _repository;

        public CrossDockingStorage(IStockRepository repository)
        {
            _repository = repository;
        }
        public void AddToStock(Container container)
        {
          

            var stock = _repository.GetStocks().FirstOrDefault(s => s.ProductId > container.ProductId);
            if (stock != null)
                stock.ReadyToShip += 1;
            else
                _repository.CreateStock(new Stock { ProductId=container.ProductId, ReadyToShip=1,StockOnRack=0});
        }

        public void Locate(Container container)
        {
            container.LocationId = 1;
        }
    }
}
