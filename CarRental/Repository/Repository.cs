
using CarRental.Data;
using CarRental.Models;
using CarRental.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarRental.Repository
{
    public class Repository<T> : IRepository<T> where T : class {
        protected ApplicationDbContext context { get; set; }
        public DbSet<T> dbSet { get; set; }

        public Repository(ApplicationDbContext context) {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task Add(T entity) {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAll() {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id, QueryOption<T> options) {
            IQueryable<T> query = dbSet;
            if (options.HasWhere) {
                query = query.Where(options.Where);
            }
            if (options.HasOrderBy) {
                query = query.OrderBy(options.OrderBy);
            }
            foreach (string include in options.GetIncludes()) {
                query = query.Include(include);
            }

            var key = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
            string primaryKeyName = key?.Name;
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyName) == id);
        }

        public async Task Update(T entity) {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id) {
            T entity = await dbSet.FindAsync(id);
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

    }
}
