using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Domain.Entities.Models
{
    public class Comments
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public virtual UserModel User { get; set; }
    }
}
