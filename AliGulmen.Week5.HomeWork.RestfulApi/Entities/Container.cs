using System;
using System.ComponentModel.DataAnnotations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Entities
{
  
    public class Container : BaseEntity
    {
        
        public int Id { get; set; }

       public int ProductId { get; set; } 
       public Product Product { get; set; }

        public int UomId { get; set; }
        public Uom Uom { get; set; }

        [Required]
        public int Quantity { get; set; }

       public int LocationId { get; set; }
      public Location Location { get; set; }
        
        public int Weight { get; set; }

    

    }
}
