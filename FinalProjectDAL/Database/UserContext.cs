using System;
using System.Collections.Generic;
using System.Data.Entity;
using FinalProjectDAL.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinalProjectDAL.Database
{
    public class UserContext : IdentityDbContext<User>
    {
        public DbSet<Question> Questions { get; set; }

        public UserContext() { }
        public UserContext(string connectionString)
            : base(connectionString, throwIfV1Schema: false)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<Question>().ToTable("Question");
        }
    }

    //public class UserContext : DbContext
    //{
    //    public DbSet<User> Users { get; set; }
    //    public DbSet<Role> Roles { get; set; }
    //    static UserContext()
    //    {
    //        System.Data.Entity.Database.SetInitializer<UserContext>(new UserDbInitializer());
    //    }
    //    public UserContext(string connectionString) : base(connectionString)
    //    {
    //    }


    //}

    //public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
    //{
    //    protected override void Seed(UserContext db)
    //    {
    //        Role admin = new Role { Name = "admin" };
    //        Role user = new Role { Name = "user" };
    //        db.Roles.Add(admin);
    //        db.Roles.Add(user);
    //        db.Users.Add(new User
    //        {
    //            Email = "somemail@gmail.com",
    //            Password = "123456",
    //            Role = admin
    //        });
    //        base.Seed(db);
    //    }
    //}
}
