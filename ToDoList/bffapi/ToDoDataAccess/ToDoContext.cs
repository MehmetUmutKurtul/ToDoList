using Microsoft.EntityFrameworkCore;
using ToDoDataAccess.Model;

namespace ToDoDataAccess {
    public class ToDoContext : DbContext {
        public ToDoContext(DbContextOptions<ToDoContext> options): base(options) { }

        public DbSet<ToDo> ToDos { get; set; }
    }
}