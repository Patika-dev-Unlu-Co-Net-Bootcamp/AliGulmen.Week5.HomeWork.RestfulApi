using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories.ContainerRepositories;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Repositories.ProductRepositories
{
    public class InMemProductRepository : IProductRepository
    {

        private Product _model = new Product();
        private int _productId;
        private int _rotationId;
        private bool _isActive;
        private List<Container> containerList = InMemContainerRepository.ContainerListOut;

        private static readonly List<Product> productList = new() {
            new Product { Id = 1, ProductCode = "87965493291", Description = "Prod1", RotationId = 1, IsActive = true, LifeTime = 365 },
            new Product { Id = 2, ProductCode = "87965493292", Description = "Prod2", RotationId = 2, IsActive = true, LifeTime = 365 },
            new Product { Id = 3, ProductCode = "87965493293", Description = "Prod3", RotationId = 3, IsActive = true, LifeTime = 365 },
            new Product { Id = 4, ProductCode = "87965493294", Description = "Prod4", RotationId = 1, IsActive = true, LifeTime = 365 },
            new Product { Id = 5, ProductCode = "87965493295", Description = "Prod5", RotationId = 2, IsActive = false, LifeTime = 365 },
            new Product { Id = 6, ProductCode = "87965493296", Description = "Prod6", RotationId = 3, IsActive = true, LifeTime = 365 },
            new Product { Id = 7, ProductCode = "87965493297", Description = "Prod7", RotationId = 1, IsActive = true, LifeTime = 365 },
            new Product { Id = 8, ProductCode = "87965493298", Description = "Prod8", RotationId = 1, IsActive = true, LifeTime = 365 }

        };

        public static List<Product> ProductListOut { get => productList; }



        public void CreateProduct(Product newProduct)
        {
            _model = newProduct;
            if (_model == null)
                throw new InvalidOperationException("No data entered!");

            var product = productList.SingleOrDefault(p => p.Id == _model.Id);

            if (product is not null)
                throw new InvalidOperationException("You already have this productCode in your list!");

            product = _model;
            productList.Add(product);
        }



        public void DeleteProduct(int productId)
        {
            _productId = productId;

            var ourRecord = productList.SingleOrDefault(p => p.Id == _productId);
            if (ourRecord is null)
                throw new InvalidOperationException("There is no record to delete!");

            productList.Remove(ourRecord);
        }



        public List<Container> GetProductContainers(int productId)
        {
            _productId = productId;

            var containers = containerList.Where(c => c.Product.Id == _productId).ToList();
            if (containers.Count == 0)
                throw new InvalidOperationException("There is no container defined with this product");

            return containers;
        }



        public Product GetProductDetail(int productId)
        {
            _productId = productId;
            var product = productList.Where(p => p.Id == _productId).SingleOrDefault();
            if (product is null)
                throw new InvalidOperationException("The product is not exist!");


            return product;
        }



        public List<Product> GetProductListByRotation(int rotationId)
        {
            _rotationId = rotationId;
            var products = productList.Where(b => b.RotationId == _rotationId).ToList();
            if (products is null)
                throw new InvalidOperationException("The product is not exist!");


            return products;
        }



        public List<Product> GetProducts()
        {
            var products = productList.OrderBy(p => p.Id).ToList<Product>();
            return products;
        }



        public void UpdateProduct(int productId, Product newProduct)
        {
            _model = newProduct;
            _productId = productId;

            if (_model is null)
                throw new InvalidOperationException("No data entered!");


            var product = productList.SingleOrDefault(u => u.Id == _productId);
            if (product is null)
                throw new InvalidOperationException("Product is not found!");



            product.Id = _model.Id != default ? _model.Id : product.Id;
            product.ProductCode = _model.ProductCode != default ? _model.ProductCode : product.ProductCode;
            product.Description = _model.Description != default ? _model.Description : product.Description;
            product.RotationId = _model.RotationId != default ? _model.RotationId : product.RotationId;
            product.IsActive = _model.IsActive != default ? _model.IsActive : product.IsActive;
            product.LifeTime = _model.LifeTime != default ? _model.LifeTime : product.LifeTime;

        }

        public void UpdateProductAvailability(int productId, bool isActive)
        {
            _productId = productId;
            _isActive = isActive;  

            var product = productList.SingleOrDefault(p => p.Id == _productId);
            if (product is null)
                throw new InvalidOperationException("Product is not found!");


            product.IsActive = _isActive != default ? _isActive : product.IsActive;
        }
    }
}
