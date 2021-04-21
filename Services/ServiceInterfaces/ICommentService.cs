using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ServiceInterfaces
{
    public interface ICommentService : IService<Comment>
    {
        Task Add(Comment comment);
        Task<List<Comment>> GetByUserId(Guid id);
        Task<List<Comment>> GetByPictureId(Guid id);
    }
}
