using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroupDatabase.Database
{
    public class GroupDatabase : DbContext
    {
        public GroupDatabase(DbContextOptions<GroupDatabase> context) : base(context) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
    }
}
