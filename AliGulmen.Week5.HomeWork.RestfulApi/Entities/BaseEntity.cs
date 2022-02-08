using System;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Entities
{
    public class BaseEntity
    {
        public bool IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
