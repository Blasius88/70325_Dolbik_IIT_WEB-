using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _70325_Dolbik_Vorobei.DAL
{
    public partial class ApplicationDbContext
    {
        public DbSet<Dish> Dishes { get; set; }

        public void Populate()
        {
            if (!Dishes.Any())
            {
                List<Dish> dishes = new List<Dish>
                {
                     new Dish
                     {
                         DishId =1,
                         DishName ="Суп-харчо",
                         Description ="Очень острый, невкусный",
                         Calories =200,
                         GroupName ="Супы"
                     },
                    new Dish
                    {
                        DishId =2,
                        DishName ="Борщ",
                        Description ="Много сала, без сметаны",
                        Calories =330,
                        GroupName ="Супы"
                    },
                    new Dish
                    {
                        DishId =3,
                        DishName ="Котлета пожарская",
                        Description ="Хлеб - 80%, Морковь - 20%",
                        Calories =635,
                        GroupName ="Вторые блюда"
                    },
                    new Dish
                    {
                        DishId =4,
                        DishName ="Макароны по-флотски",
                        Description ="С охотничьей колбаской",
                        Calories =524,
                        GroupName ="Вторые блюда"
                    },
                    new Dish
                    {
                        DishId =5,
                        DishName ="Компот",
                        Description ="Быстро растворимый, 2 литра",
                        Calories =180,
                        GroupName ="Напитки"
                    },
                    new Dish {
                        DishId =6,
                        DishName ="Чай",
                        Description ="Липтон",
                        Calories =180,
                        GroupName ="Напитки"
                    },
                    new Dish
                    {
                        DishId =7,
                        DishName ="Щи",
                        Description ="Настоящий русский суп",
                        Calories =180,
                        GroupName ="Супы"
                    }
                };
                Dishes.AddRange(dishes);
                SaveChanges();
            }
            if (!Roles.Any())
            {
                // Создаем менеджеры ролей и пользователей
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));
                // Создаем роли "admin" и "user"
                roleManager.Create(new IdentityRole("admin"));
                roleManager.Create(new IdentityRole("user"));
                // Создаем пользователя
                var userAdmin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru",
                    NickName = "SuperHero"
                };
                userManager.CreateAsync(userAdmin, "123456").Wait();
                // Добавляем созданного пользователя в администраторы
                userManager.AddToRole(userAdmin.Id, "admin");
            }
        }
    }
}
