using Microsoft.EntityFrameworkCore;
using LoginDataAccess.Model;

namespace LoginDataAccess {
    public class LoginContext : DbContext {
        public LoginContext(DbContextOptions<LoginContext> options): base(options) { }

        public DbSet<Login> Logins { get; set; }
    }
}