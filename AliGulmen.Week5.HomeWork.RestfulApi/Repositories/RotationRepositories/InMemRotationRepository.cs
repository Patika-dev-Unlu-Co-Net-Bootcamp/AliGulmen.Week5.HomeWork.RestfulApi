using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories.LocationRepositories;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Repositories.RotationRepositories
{
    public class InMemRotationRepository : IRotationRepository
    {
        private Rotation _model = new Rotation();
        private int _rotationId;
        private string _rotationCode;

        private List<Location> locationList = InMemLocationRepository.LocationListOut;
        private List<Product> productList = InMemProductRepository.ProductListOut;


        /*
       * Category A, Category B, Category C (CatA > Cat B > Cat C)
       */
        private readonly List<Rotation> rotationList = new () {
           new Rotation { Id = 1, RotationCode = "Cat A"},
            new Rotation { Id = 2, RotationCode = "Cat B" },
            new Rotation { Id = 3, RotationCode = "Cat C" },
            new Rotation { Id = 4, RotationCode = "Cat D" }
        };


        public void CreateRotation(Rotation newRotation)
        {
            _model = newRotation;

            if (_model == null)
                throw new InvalidOperationException("No data entered!");

            var rotation = rotationList.SingleOrDefault(u => u.RotationCode == _model.RotationCode);

            if (rotation is not null)
                throw new InvalidOperationException("You already have this rotation in your list!");

            rotation = _model;
            rotationList.Add(rotation);

        }



        public void DeleteRotation(int rotationId)
        {
            _rotationId = rotationId;

            var ourRecord = rotationList.SingleOrDefault(r => r.Id == _rotationId);
            if (ourRecord is null)
                throw new InvalidOperationException("There is no record to delete!");

            rotationList.Remove(ourRecord);
        }



        public Rotation GetRotationDetail(int rotationId)
        {
            _rotationId = rotationId;

            var rotation = rotationList.Where(r => r.Id == _rotationId).SingleOrDefault();
            if (rotation is null)
                throw new InvalidOperationException("The rotation is not exist!");


            return rotation;
        }



        public List<Location> GetRotationLocations(int rotationId)
        {
            _rotationId = rotationId;

            var locations = locationList.Where(loc => loc.RotationId == _rotationId).ToList();
            if (locations.Count == 0)
                throw new InvalidOperationException("There is no location defined with this rotation");

            return locations;
        }


        public List<Product> GetRotationProducts(int rotationId)
        {
            _rotationId=rotationId;

            var products = productList.Where(p => p.RotationId == _rotationId).ToList();
            if (products.Count == 0)
                throw new InvalidOperationException("There is no product defined with this rotation");

            return products;
        }



        public List<Rotation> GetRotations()
        {
            var rotations = rotationList.OrderBy(r => r.Id).ToList<Rotation>();
            return rotations;
        }



        public void UpdateRotation(int rotationId, Rotation newRotation)
        {
            _model = newRotation;
            _rotationId = rotationId;

            if (_model is null)
                throw new InvalidOperationException("No data entered!");


            var rotation = rotationList.SingleOrDefault(u => u.Id == _rotationId);
            if (rotation is null)
                throw new InvalidOperationException("Rotation is not found!");


            rotation.Id = _model.Id != default ? _model.Id : rotation.Id;
            rotation.RotationCode = _model.RotationCode != default ? _model.RotationCode : rotation.RotationCode;
        }




        public void UpdateRotationCode(int rotationId, string rotationCode)
        {
            _rotationId = rotationId;
            _rotationCode = rotationCode;

            var rotation = rotationList.SingleOrDefault(u => u.Id == _rotationId);
            if (rotation is null)
                throw new InvalidOperationException("Rotation is not found!");


            rotation.RotationCode = rotationCode != default ? rotationCode : rotation.RotationCode;
        }
    }
}
