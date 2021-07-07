using Microsoft.EntityFrameworkCore;

namespace todo_list.DbInfrastructure
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext( DbContextOptions<ToDoDbContext> options )
            : base( options )
        { }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new ToDoEntityConfiguration() );
        }
    }
}
