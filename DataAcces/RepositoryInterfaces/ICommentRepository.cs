using DataAcces.Entities;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface ICommentRepository : IRepository<CommentEntity>
    {
        Task<Comment> GetById(Guid id);
        void Add(Comment item);
        Task<List<Comment>> GetByUserId(Guid userId);
        Task<List<Comment>> GetByPictureId(Guid pictureId);
        Task Update(Comment item);
    }
}
