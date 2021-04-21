using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UserSeting : IDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GenreId { get; set; }
        public bool IsShow { get; set; }
        public int PictureCount { get; set; }
    }
}
