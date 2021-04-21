using DataAcces;
using Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;

namespace Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWorkFactory _factory;

        public CommentService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public async Task Add(Comment comment)
        {
            using (var unitOfWork = _factory.Create())
            {
                unitOfWork.Comments.Add(comment);
                await unitOfWork.Commit();
            }
        }

        public async Task<List<Comment>> GetByPictureId(Guid pictureId)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Comments.GetByPictureId(pictureId);
            }
        }        

        public async Task DeleteById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.Comments.DeleteById(id);

                await unitOfWork.Commit();
            }
        }



        public async Task<Comment> GetById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Comments.GetById(id);
            }
        }



        public async Task<List<Comment>> GetByUserId(Guid userId)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Comments.GetByUserId(userId);
            }
        }


        public async Task Update(Comment item)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.Comments.Update(item);
                await unitOfWork.Commit();
            }
        }
    }
}
