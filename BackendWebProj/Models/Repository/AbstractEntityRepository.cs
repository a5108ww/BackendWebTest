using BackendWebProj.Context;
using Microsoft.EntityFrameworkCore;

namespace BackendWebProj.Models.Repository
{
    public abstract class AbstractEntityRepository<T> where T : AbstractEntity
    {
        private protected readonly BackendWebContext db;

        public AbstractEntityRepository(BackendWebContext _db)
        {
            db = _db;
        }

        public abstract T GetById(Int64 id);

        public abstract IQueryable<T> GetEntitiesQ();


        public async Task<int> SaveAsync(T entity)
        {
            return await SaveAsync(new List<T>() { entity });
        }

        public async Task<int> SaveAsync(List<T> entitys)
        {
            int state = 0;
            if (entitys != null && entitys.Count > 0)
            {
                foreach (T entity in entitys)
                {
                    db.Entry(entity).State = EntityState.Modified;
                    if (entity.id == 0)
                    {
                        db.Entry(entity).State = EntityState.Added;
                    }
                }
                state = await db.SaveChangesAsync();
            }

            return state;
        }
    }
}
