using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Domain.Entities.Models
{
    public class BlogPost
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
    }
}
