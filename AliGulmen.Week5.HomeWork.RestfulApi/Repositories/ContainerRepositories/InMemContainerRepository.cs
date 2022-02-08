using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using AliGulmen.Week5.HomeWork.RestfulApi.Extensions;
using AliGulmen.Week5.HomeWork.RestfulApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Repositories.ContainerRepositories
{
    public class InMemContainerRepository : IContainerRepository
    {
        private Container _model = new Container();
        private int _containerId;
        private int _maxWeight;
        private int _locationId;

        private static readonly List<Container> containerList = new()
        {
            new Container { Id = 1, ProductId = 1, UomId = 1, Quantity = 200, LocationId = 1, Weight = 300, CreationDate = DateTime.Today.AddDays(-100) },
            new Container { Id = 2, ProductId = 1, UomId = 2, Quantity = 100, LocationId = 5, Weight = 250, CreationDate = DateTime.Today.AddDays(-45) },
            new Container { Id = 3, ProductId = 2, UomId = 3, Quantity = 150, LocationId = 3, Weight = 400, CreationDate = DateTime.Today.AddDays(-15) },
            new Container { Id = 4, ProductId = 3, UomId = 2, Quantity = 150, LocationId = 6, Weight = 300, CreationDate = DateTime.Today.AddDays(-1) },
            new Container { Id = 5, ProductId = 2, UomId = 1, Quantity = 150, LocationId = 7, Weight = 300, CreationDate = DateTime.Today.AddDays(-97) },
            new Container { Id = 6, ProductId = 4, UomId = 3, Quantity = 240, LocationId = 8, Weight = 240, CreationDate = DateTime.Today.AddDays(-16) },
            new Container { Id = 7, ProductId = 5, UomId = 4, Quantity = 300, LocationId = 11, Weight = 500, CreationDate = DateTime.Today.AddDays(-16) },
            new Container { Id = 8, ProductId = 1, UomId = 1, Quantity = 140, LocationId = 9, Weight = 250, CreationDate = DateTime.Today.AddDays(-78) }

        };

        public static List<Container> ContainerListOut { get => containerList; }




     



        public void CreateContainer(Container model)
        {
            if (_model == null)
                throw new InvalidOperationException("No data entered!");

            var container = containerList.SingleOrDefault(c => c.Id == _model.Id);

            if (container is not null)
                throw new InvalidOperationException("You already have this container in your list!");

            container = _model;
            containerList.Add(container);
        }



        public void DeleteContainer(int containerId)
        {
            _containerId = containerId;
            var ourRecord = containerList.SingleOrDefault(container => container.Id == _containerId);
            if (ourRecord is null)
                throw new InvalidOperationException("There is no record to delete!");

            containerList.Remove(ourRecord);
        }



        public Container GetContainerDetail(int containerId)
        {
            _containerId = containerId;

            var container = containerList.Where(container => container.Id == _containerId).SingleOrDefault();
            if (container is null)
                throw new InvalidOperationException("The container is not exist!");


            return container;
        }



        public List<Container> GetContainerListByWeight(int maxWeight)
        {
            _maxWeight = maxWeight;

            var containers = containerList
                                   .Where(container => container.Weight <= _maxWeight)
                                   .OrderBy(container => container.Weight)
                                   .ToList();
            if (containers is null)
                throw new InvalidOperationException("The container is not exist!");


            return containers;
        }




        public List<Container> GetContainers()
        {
            var containers = containerList.OrderBy(c => c.Id).ToList<Container>();
            return containers;
        }



    

        public PagingResultModel<Container> GetContainersWithParameters(QueryParamsModel query)
        {
            PagingResultModel<Container> containers = new PagingResultModel<Container>(query);

            containers.GetData(containerList.AsQueryable());
            

            return containers;
        }




        public void UpdateContainer(Container model, int containerId)
        {
            _model = model;
            _containerId = containerId;
            if (_model is null)
                throw new InvalidOperationException("No data entered!");


            var container = containerList.SingleOrDefault(c => c.Id == _containerId);
            if (container is null)
                throw new InvalidOperationException("Container is not found!");



            container.ValidateWith(_model);
        }




        public void UpdateContainerLocation(int containerId, int locationId)
        {
            _containerId = containerId;
            _locationId = locationId;
            var container = containerList.SingleOrDefault(c => c.Id == _containerId);
            if (container is null)
                throw new InvalidOperationException("Container is not found!");


            container.LocationId = _locationId != default ? _locationId : container.LocationId;
        }

      
    }
}
