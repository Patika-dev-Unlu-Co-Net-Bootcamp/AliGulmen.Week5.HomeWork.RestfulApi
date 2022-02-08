using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Entities
{

   
    public class Rotation : BaseEntity
    {
       
        public int Id { get; set; }

        [Required]
        public string RotationCode { get; set; }

        public List<Location> Locations { get; set; }
        public List<Product> Products { get; set; }
    
    }
}
