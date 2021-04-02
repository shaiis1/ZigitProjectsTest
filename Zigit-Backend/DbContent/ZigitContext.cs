using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zigit_Backend.Models;

namespace Zigit_Backend.DbContent
{
    public class ZigitContext : DbContext
    {
        public ZigitContext(DbContextOptions<ZigitContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<ProjectsModel> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid shaiUserGuid = Guid.NewGuid();
            Guid yossiUserGuid = Guid.NewGuid();

            ////////////////////////////////////////////////////////////
            // Change content manually to add more users and projects //
            ////////////////////////////////////////////////////////////

            #region UserSeed
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { ID = shaiUserGuid, UserName = "Shai Test", Password = "1234", Team = "First Team", Avatar = "https://www.pinterest.com/pin/823736588076106083/", JoinedAt = DateTime.Now });
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { ID = yossiUserGuid, UserName = "Yossi Test", Password = "1212", Team = "First Team", Avatar = "https://www.pinterest.com/pin/823736588076106083/", JoinedAt = DateTime.Now });
            #endregion

            #region ProjectsSeed
            modelBuilder.Entity<ProjectsModel>().HasData(
                new ProjectsModel { ID = Guid.NewGuid(), Name = "Shai Test Project", BugsCount = 0, DurationInDays = 1, MadeDeadLine = true, Score = 100, UserID = shaiUserGuid });
            modelBuilder.Entity<ProjectsModel>().HasData(
                new ProjectsModel { ID = Guid.NewGuid(), Name = "Shai Test Project2", BugsCount = 4, DurationInDays = 14, MadeDeadLine = false, Score = 70, UserID = shaiUserGuid });
            modelBuilder.Entity<ProjectsModel>().HasData(
                new ProjectsModel { ID = Guid.NewGuid(), Name = "Shai Test Project3", BugsCount = 2, DurationInDays = 35, MadeDeadLine = true, Score = 90, UserID = shaiUserGuid });

            modelBuilder.Entity<ProjectsModel>().HasData(
                new ProjectsModel { ID = Guid.NewGuid(), Name = "Yossi Test Project", BugsCount = 6, DurationInDays = 12, MadeDeadLine = false, Score = 79, UserID = yossiUserGuid });
            modelBuilder.Entity<ProjectsModel>().HasData(
                new ProjectsModel { ID = Guid.NewGuid(), Name = "Yossi Test Project2", BugsCount = 4, DurationInDays = 7, MadeDeadLine = true, Score = 83, UserID = yossiUserGuid });
            #endregion
        }
    }
}
