using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Entities
{
	
	public class Product : BaseEntity
	{
		
		public int Id { get; set; }

		[Required]
		public string ProductCode { get; set; }

		public string Description { get; set; }
		public int RotationId { get; set; }
		

		public int LifeTime { get; set; }

	
		public List<Container> Container { get; set; }
		public Rotation Rotation { get; set; }
	}
}
