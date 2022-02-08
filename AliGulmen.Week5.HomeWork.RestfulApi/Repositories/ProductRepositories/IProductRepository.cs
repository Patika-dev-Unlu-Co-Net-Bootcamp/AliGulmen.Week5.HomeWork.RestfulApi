using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using System.Collections.Generic;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Repositories
{
    public interface IProductRepository
    {
        void CreateProduct(Product newProduct);
        void DeleteProduct(int productId);
        List<Container> GetProductContainers(int productId);
        Product GetProductDetail(int productId);
        List<Product> GetProductListByRotation(int rotationId);
        List<Product> GetProducts();
        void UpdateProduct(int productId, Product newProduct);
        void UpdateProductAvailability(int productId, bool isActive);
    }
}
