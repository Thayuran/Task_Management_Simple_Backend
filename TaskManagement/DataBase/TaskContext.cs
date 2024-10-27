using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;

namespace TaskManagement.DataBase
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(o => o.Tasks)
                .WithOne(u => u.assignee)
                .HasForeignKey(o => o.assigneeId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
