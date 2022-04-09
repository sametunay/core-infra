using System.ComponentModel.DataAnnotations.Schema;
using MyGallery.Core.Domain.ValueObjects;

namespace MyGallery.Core.Domain.Entities
{
	[Table("Cars")]
	public class Car : BaseEntity<int>
	{
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public string CaseType { get; protected set; }
		public int CarCategoryId { get; protected set; }
		public int BrandId { get; protected set; }
		public PowerInfo PowerInfo { get; protected set; }

		public virtual CarCategory CarCategory { get; }
		public virtual Brand Brand { get; }

		public Car(string name, string description, string caseType, int carCategoryId, int brandId, PowerInfo powerInfo)
		{
			Name = name;
			Description = description;
			CaseType = caseType;
			CarCategoryId = carCategoryId;
			BrandId = brandId;
			PowerInfo = powerInfo;
		}

		public Car()
		{			
		}
	}
}
