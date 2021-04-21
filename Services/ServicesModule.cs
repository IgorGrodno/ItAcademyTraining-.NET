using Autofac;
using Services.ServiceInterfaces;
using Services.Services;

namespace Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<GenreService>().As<IGenreService>();
            builder.RegisterType<PictureService>().As<IPictureService>();
            builder.RegisterType<RatingService>().As<IRatingService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<FileManager>().As<IFileManager>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<ExternalLoginService>().As<IExternalLoginService>();
        }
    }
}
