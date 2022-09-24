using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CI.Core.Domain.Entities
{
    [Table("Brands")]
    public class Brand : BaseEntity<int>
    {
        public string Title { get; protected set; }
        public string National { get; protected set; }

        public virtual List<Car> Cars { get; }

        public Brand(string title, string national)
        {
            Title = title;
            National = national;
        }

        public Brand()
        {            
        }
    }
}