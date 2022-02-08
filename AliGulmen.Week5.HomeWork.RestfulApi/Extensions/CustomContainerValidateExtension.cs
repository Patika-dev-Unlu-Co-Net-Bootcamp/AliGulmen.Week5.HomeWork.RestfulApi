using AliGulmen.Week5.HomeWork.RestfulApi.Entities;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Extensions
{
    public static class CustomContainerValidateExtension
    {
       
          
            public static void ValidateWith(this Container existingContainer, Container newContainer)
            {

            existingContainer.Id = newContainer.Id != default ? newContainer.Id : existingContainer.Id;
            existingContainer.ProductId = newContainer.ProductId != default ? newContainer.ProductId : existingContainer.ProductId;
            existingContainer.UomId = newContainer.UomId != default ? newContainer.UomId : existingContainer.UomId;
            existingContainer.Quantity = newContainer.Quantity != default ? newContainer.Quantity : existingContainer.Quantity;
            existingContainer.LocationId = newContainer.LocationId != default ? newContainer.LocationId : existingContainer.LocationId;
            existingContainer.Weight = newContainer.Weight != default ? newContainer.Weight : existingContainer.Weight;
            existingContainer.CreationDate = newContainer.CreationDate != default ? newContainer.CreationDate : existingContainer.CreationDate;
            existingContainer.CreatedBy = newContainer.CreatedBy != default ? newContainer.CreatedBy : existingContainer.CreatedBy;
            existingContainer.IsActive = newContainer.IsActive != default ? newContainer.IsActive : existingContainer.IsActive;
            existingContainer.UpdateDate = newContainer.UpdateDate != default ? newContainer.UpdateDate : existingContainer.UpdateDate;
            existingContainer.UpdatedBy = newContainer.UpdatedBy != default ? newContainer.UpdatedBy : existingContainer.UpdatedBy;
          
        }
        
    }
}
