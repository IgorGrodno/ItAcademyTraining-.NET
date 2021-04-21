using DataAcces.Repositories;
using DataAcces.RepositoryInterfaces;
using DataAcces.Reposytories;
using System.Threading.Tasks;

namespace DataAcces
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        private IClaimRepository _claimRepository;
        private ICommentRepository _commentRepository;
        private IExternalLoginRepository _externalLoginRepository;
        private IGenreRepository _genreReposytory;
        private IPictureRepository _pictureRepository;
        private IRatingChangeEventRepository _ratingChangeEventRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private IUserRoleRepository _userRoleRepository;
        private IUserClaimRepository _userClaimRepository;
        private IUserExternalLoginRepository _userExternalLoginRepository;
        private IUserSetingsRepository _userSetingsRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IClaimRepository Claims
        {
            get
            {
                if (_claimRepository == null)
                    _claimRepository = new ClaimRepository(_context);
                return _claimRepository;
            }
        }
        public IUserSetingsRepository Setings
            {
            get
            {
                if (_userSetingsRepository == null)
                    _userSetingsRepository = new UserSetingRepository(_context);
                return _userSetingsRepository;
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_context);
                return _commentRepository;
            }
        }

        public IExternalLoginRepository Logins
        {
            get
            {
                if (_externalLoginRepository == null)
                    _externalLoginRepository = new ExternalLoginRepository(_context);
                return _externalLoginRepository;
            }
        }
        public IGenreRepository Genres
        {
            get
            {
                if (_genreReposytory == null)
                    _genreReposytory = new GenreRepository(_context);
                return _genreReposytory;
            }
        }
        public IPictureRepository Pictures
        {
            get
            {
                if (_pictureRepository == null)
                    _pictureRepository = new PictureRepository(_context);
                return _pictureRepository;
            }
        }
        public IRatingChangeEventRepository GetRatingChangeEvents
        {
            get
            {
                if (_ratingChangeEventRepository == null)
                    _ratingChangeEventRepository = new RatingChangeEventRepository(_context);
                return _ratingChangeEventRepository;
            }
        }
        public IRoleRepository Roles
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(_context);
                return _roleRepository;
            }
        }
        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public IUserRoleRepository UserRoles
        {
            get
            {
                if (_userRoleRepository == null)
                    _userRoleRepository = new UserRoleRepository(_context);
                return _userRoleRepository;
            }
        }

        public IUserClaimRepository UserClaims
        {
            get
            {
                if (_userClaimRepository == null)
                    _userClaimRepository = new UserClaimRepository(_context);
                return _userClaimRepository;
            }
        }

        public IUserExternalLoginRepository UserLogins
        {
            get
            {
                if (_userExternalLoginRepository == null)
                    _userExternalLoginRepository = new UserExternalLoginRepository(_context);
                return _userExternalLoginRepository;
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
