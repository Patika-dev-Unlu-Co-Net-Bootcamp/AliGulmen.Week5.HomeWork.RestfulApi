using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Repositories.LocationRepositories
{
    public class InMemLocationRepository : ILocationRepository
    {
        private Location _model = new Location();
        private int _locationId;
        private int _rotationId;

        /*
        * locationName =  xxyyzz 
        * xx = side (left=01, right=02)
        * yy = vertical cell (floor)
        * zz = horizontal cell (slot) 
        */

        private static readonly List<Location> locationList = new() {
            new Location { Id = 1, LocationName = "DockArea", RotationId = 1 },
            new Location { Id = 2, LocationName = "010102", RotationId = 2 },
            new Location { Id = 3, LocationName = "010103", RotationId = 3 },
            new Location { Id = 4, LocationName = "010201", RotationId = 1 },
            new Location { Id = 5, LocationName = "010202", RotationId = 2 },
            new Location { Id = 6, LocationName = "010203", RotationId = 3 },
            new Location { Id = 7, LocationName = "020101", RotationId = 1 },
            new Location { Id = 8, LocationName = "020102", RotationId = 2 },
            new Location { Id = 9, LocationName = "020103", RotationId = 3 },
            new Location { Id = 10, LocationName = "020201", RotationId = 1 },
            new Location { Id = 11, LocationName = "020202", RotationId = 2 },
            new Location { Id = 12, LocationName = "020203", RotationId = 3 }

        };

        public static List<Location> LocationListOut { get => locationList; }

  
        public void CreateLocation(Location newLocation)
        {
            _model = newLocation;

            if (_model == null)
                throw new InvalidOperationException("No data entered!");

            var location = locationList.SingleOrDefault(u => u.Id == _model.Id);

            if (location is not null)
                throw new InvalidOperationException("You already have this locationCode in your list!");

            location = _model;
            locationList.Add(location);
        }




        public void DeleteLocation(int locationId)
        {
            _locationId = locationId;
            var ourRecord = locationList.SingleOrDefault(l => l.Id == _locationId);
            if (ourRecord is null)
                throw new InvalidOperationException("There is no record to delete!");

            locationList.Remove(ourRecord);
        }



        public Location GetLocationDetail(int locationId)
        {
            _locationId = locationId;
            var location = locationList.Where(l => l.Id == _locationId).SingleOrDefault();
            if (location is null)
                throw new InvalidOperationException("The location is not exist!");


            return location;
        }



        public List<Location> GetLocationListByRotation(int rotationId)
        {
            _rotationId = rotationId;
            var locations = locationList.Where(l => l.RotationId == _rotationId).ToList();
            if (locations is null)
                throw new InvalidOperationException("The location is not exist!");


            return locations;

        }


        public List<Location> GetLocations()
        {
            var locations = locationList.OrderBy(l => l.Id).ToList<Location>();
            return locations;
        }

        public void UpdateLocation(int locationId, Location newLocation)
        {
            _model = newLocation;
            _locationId = locationId;

            if (_model is null)
                throw new InvalidOperationException("No data entered!");


            var location = locationList.SingleOrDefault(loc => loc.Id == _locationId);
            if (location is null)
                throw new InvalidOperationException("Location is not found!");



            location.Id = _model.Id != default ? _model.Id : location.Id;
            location.LocationName = _model.LocationName != default ? _model.LocationName : location.LocationName;
            location.RotationId = _model.RotationId != default ? _model.RotationId : location.RotationId;

        }


        public void UpdateLocationRotation(int locationId, int rotationId)
        {
            _locationId=locationId;
            _rotationId=rotationId;

            var location = locationList.SingleOrDefault(loc => loc.Id == _locationId);
            if (location is null)
                throw new InvalidOperationException("Uom is not found!");


            location.RotationId = _rotationId != default ? _rotationId : location.RotationId;
        }
    }
}
