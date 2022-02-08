using System.ComponentModel.DataAnnotations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Entities
{
    
    public class Location : BaseEntity
    {
       
        public int Id { get; set; }

        [Required]
        public string LocationName { get; set; }

        public int RotationId { get; set; }
        public Rotation Rotation { get; set; }

        public Container Container { get; set; }
    }
}
