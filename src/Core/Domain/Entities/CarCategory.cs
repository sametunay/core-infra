using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CI.Core.Domain.Entities
{
	[Table("CarCategories")]
	public class CarCategory : BaseEntity<int>
	{
		public string Title { get; protected set; }
		public string Description { get; protected set; }

		public virtual List<Car> Cars { get; }

		public CarCategory(string title, string description)
		{
			Title = title;
			Description = description;
		}

		public CarCategory()
		{			
		}
	}
}
