using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using System.Collections.Generic;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Repositories
{
    public interface ILocationRepository
    {
        void CreateLocation(Location newLocation);
        void DeleteLocation(int locationId);
        Location GetLocationDetail(int locationId);
        List<Location> GetLocationListByRotation(int rotationId);
        List<Location> GetLocations();
        void UpdateLocation(int locationId, Location newLocation);
       
        void UpdateLocationRotation(int locationId, int rotationId);
    }
}
