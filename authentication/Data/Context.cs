using authentication.Domain;
using Microsoft.EntityFrameworkCore;

namespace authentication.Data{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options){
        public DbSet<User> Users{ get; set;}
    }
}