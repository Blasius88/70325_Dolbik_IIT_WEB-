using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _70325_Dolbik_Vorobei.DAL
{
    public class EFDishRepository : IRepository<Dish>
    {
        private ApplicationDbContext context;
        private DbSet<Dish> table;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="ctx">Контекст базы данных</param>
        public EFDishRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.Dishes;
        }
        public void Create(Dish t)
        {
            table.Add(t);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context
            .Entry(new Dish { DishId = id })
            .State = EntityState.Deleted;
            context.SaveChanges();
        }
        public IEnumerable<Dish> Find(Func<Dish, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }
        public Dish Get(int id)
        {
            return table.Find(id);
        }
        public IEnumerable<Dish> GetAll()
        {
            return table;
        }
        public Task<Dish> GetAsync(int id)
        {
            return context.Dishes.FindAsync(id);
        }
        public void Update(Dish t)
        {
            if (t.Image == null)
            {
                var dish = context.Dishes
                    .AsNoTracking()
                    .Where(d => d.DishId == t.DishId)
                    .FirstOrDefault();
                t.Image = dish.Image;
                t.MimeType = dish.MimeType;
            }
            context.Entry<Dish>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
