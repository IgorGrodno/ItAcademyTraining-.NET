using DataAcces.RepositoryInterfaces;
using System;
using System.Threading.Tasks;

namespace DataAcces
{
    public interface IUnitOfWork : IDisposable
    {
        IClaimRepository Claims { get; }
        ICommentRepository Comments { get; }
        IExternalLoginRepository Logins { get; }
        IGenreRepository Genres { get; }
        IPictureRepository Pictures { get; }
        IRatingChangeEventRepository GetRatingChangeEvents { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }
        IUserClaimRepository UserClaims { get; }
        IUserExternalLoginRepository UserLogins { get; }
        IUserSetingsRepository Setings { get; }

        Task Commit();
    }
}

