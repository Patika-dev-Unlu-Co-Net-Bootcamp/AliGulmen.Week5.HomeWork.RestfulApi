using System.ComponentModel.DataAnnotations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Entities
{
    public class Stock : BaseEntity
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ReadyToShip { get; set; }
        public int StockOnRack { get; set; }
    }
}
