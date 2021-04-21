using DataAcces.Entities;
using DataAcces.ModelBuilderConfigurations;
using System;
using System.Data.Entity;

namespace DataAcces
{
    public class DataContext : DbContext
    {
        public DbSet<PictureEntity> Pictures { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<RatingChangeEventEntity> RatingChangeEvents { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<ExternalLoginEntity> Logins { get; set; }
        public DbSet<ClaimEntity> Claims { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
        public DbSet<UserClaimEntity> UserClaims { get; set; }
        public DbSet<UserExternalLoginEntity> UserExternalLogins { get; set; }
        public DbSet<UserSettingsEntity> UserSetings { get; set; }


        public DataContext() : base("DefaultConnection")
        {
            Database.SetInitializer<DataContext>(new AppDbInitializer());
        }

        public class AppDbInitializer : CreateDatabaseIfNotExists<DataContext>
        {
            protected override void Seed(DataContext context)
            {
                context.Roles.Add(new RoleEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "user"
                });

                context.Roles.Add(new RoleEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "moderator"
                });

                var adminRole= new RoleEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "administrator"
                };

                context.Roles.Add(adminRole);

                var claim = new ClaimEntity
                {
                    Id = Guid.NewGuid(),
                    ClaimType = "defaultClaimType",
                    ClaimValue = "defaultClaimValue"
                };

                context.Claims.Add(claim);

                var admin = new UserEntity
                {
                    
                    Id=Guid.NewGuid(),
                    Name="admin",
                    SecurityStamp= "ec78b832-728a-45de-af35-c47f9153b34a",
                    PasswordHash= "AL35z6c/W5aAz1s7QEDJxZYHfB6eubkP7iXUUa3YNRKhAPosk8FQ00sDdiDPxTi01A==",
                    IsBlocked=false
                };

                context.Users.Add(admin);

                context.UserRoles.Add(new UserRoleEntity
                {
                    Id=Guid.NewGuid(),
                    RoleId=adminRole.Id,
                    UserId=admin.Id
                });

                context.UserClaims.Add(new UserClaimEntity
                {
                    Id=Guid.NewGuid(),
                    ClaimId=claim.Id,
                    UserId=admin.Id
                });

                context.SaveChanges();

                base.Seed(context);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GenreEntityConfiguration());
            modelBuilder.Configurations.Add(new PictureEntityConfiguration());
            modelBuilder.Configurations.Add(new RatingChangrEventEntityConfiguration());
            modelBuilder.Configurations.Add(new CommentEntityConfiguration());
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new RoleEntityConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginEntityConfiguration());
            modelBuilder.Configurations.Add(new ClaimEntityConfiguration());
        }
    }
}

