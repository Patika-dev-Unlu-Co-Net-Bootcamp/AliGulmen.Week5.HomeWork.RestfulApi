using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using System.Collections.Generic;


namespace AliGulmen.Week5.HomeWork.RestfulApi.Repositories
{
    public interface IContainerRepository
    {
        List<Container> GetContainers();
        Container GetContainerDetail(int containerId);
        void CreateContainer(Container container);
        void DeleteContainer(int containerId);
        void UpdateContainer(Container model, int containerId);
        List<Container> GetContainerListByWeight(int maxWeight);
        void UpdateContainerLocation(int containerId, int locationId);
    }
}
