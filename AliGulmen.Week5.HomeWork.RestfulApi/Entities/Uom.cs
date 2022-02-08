using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Entities
{
  
    public class Uom : BaseEntity
    {
       
        public int Id { get; set; }

        [Required]
        public string UomCode { get; set; }
        public string Description { get; set; }

     public List<Container> Container { get; set; }
    }
}
