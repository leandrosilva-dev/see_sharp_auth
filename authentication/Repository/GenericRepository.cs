using authentication.Data;
using authentication.Domain;
using Microsoft.EntityFrameworkCore;

namespace authentication.Repository{
    public class GenericRepository(ApplicationDbContext context){
        protected readonly ApplicationDbContext _context = context;

        public async Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : class{
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public async Task<TEntity?> FindById<TEntity>(int id) where TEntity : class{
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }


    public class UserRepository(ApplicationDbContext context) : GenericRepository(context){
        public async Task<List<User>> GetAllUser(){
            return await _context.Users.ToListAsync();
        }
    }

}