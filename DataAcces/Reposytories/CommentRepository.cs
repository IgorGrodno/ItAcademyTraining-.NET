using DataAcces.Entities;
using DataAcces.RepositoryInterfaces;
using Domain.DTO;
using ExpressMapper.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.Repositories
{
    public class CommentRepository : Repository<CommentEntity>, ICommentRepository
    {
        public CommentRepository(DataContext context) : base(context)
        {
        }

        public void Add(Comment item)
        {
            base._dbSet.Add(item.Map<Comment, CommentEntity>());
        }

        public async Task<Comment> GetById(Guid id)
        {
            var result = await base._dbSet.FindAsync(id);
            return result.Map<CommentEntity, Comment>();
        }

        public async Task<List<Comment>> GetByPictureId(Guid pictureId)
        {
            List<CommentEntity> result = base.GetByPredicate(x => x.PictureId == pictureId).ToList();
            result.OrderBy(x => x.AddingDate);
            return result.Map<List<CommentEntity>, List<Comment>>();
        }
             

        public async Task<List<Comment>> GetByUserId(Guid userId)
        {
            List<CommentEntity> result = base.GetByPredicate(x => x.UserId == userId).ToList();
            result.OrderBy(x => x.AddingDate);
            return result.Map<List<CommentEntity>, List<Comment>>();
        }

        public async Task Update(Comment item)
        {
            var itemToUpdate = await base._dbSet.FindAsync(item.Id);

            base._context.Entry(itemToUpdate).State = EntityState.Modified;
        }
    }
}
