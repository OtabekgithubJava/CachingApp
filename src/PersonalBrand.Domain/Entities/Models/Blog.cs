using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Domain.Entities.Models
{
    public class Blog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTime ReadTime { get; set; }
        public int Views { get; set; }
        public string Poster { get; set; }
        public string AuthotComment { get; set; }
        public virtual UserModel User { get; set; }
        public virtual BlogPost Post { get; set; }
    }
}
