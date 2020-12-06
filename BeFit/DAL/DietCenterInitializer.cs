using BeFit.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BeFit.DAL
{
    public class DietCenterInitializer : DropCreateDatabaseAlways<DietCenterContext>
    {
        protected override void Seed(DietCenterContext context)
        {
            base.Seed(context);

            var user0 = new ApplicationUser { UserName = "kinia@gmail.com" };
            var user1 = new ApplicationUser { UserName = "ania@gmail.com" };
            var user2 = new ApplicationUser { UserName = "janek@gmail.com" };
            var user3 = new ApplicationUser { UserName = "krzysio@gmail.com" };
            string pass = "asdQWE123.";

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));

            roleManager.Create(new IdentityRole("Administrator"));
            roleManager.Create(new IdentityRole("Dietetyk"));
            roleManager.Create(new IdentityRole("Klient"));

            userManager.Create(user0, pass);
            userManager.Create(user1, pass);
            userManager.Create(user3, pass);
            userManager.Create(user2, pass);

            userManager.AddToRole(user0.Id, "Administrator");
            userManager.AddToRole(user1.Id, "Klient");
            userManager.AddToRole(user2.Id, "Klient");
            userManager.AddToRole(user3.Id, "Dietetyk");

            var ingridient = new List<Ingridient>
            {
                new Ingridient {Name = "Orzechy laskowe", EnergeticValue = 628, Fat = 60, Protein = 15, CarboHydrates = 17, MeasureRate = MeasureRate.gramy },
                new Ingridient {Name = "Ziemniaki", EnergeticValue = 69, Fat = 0, Protein = 2, CarboHydrates = 16, MeasureRate = MeasureRate.gramy },
                new Ingridient {Name = "Ryż", EnergeticValue = 344, Fat = 1, Protein = 7, CarboHydrates = 79, MeasureRate = MeasureRate.gramy},
                new Ingridient {Name = "Pierś z kurczaka", EnergeticValue = 99, Fat = 1, Protein = 21, CarboHydrates = 0, MeasureRate = MeasureRate.gramy},
                new Ingridient {Name ="Mleko 2%", EnergeticValue = 50, Fat = 2, Protein = 3, CarboHydrates = (Decimal)4.8, MeasureRate = MeasureRate.mililitry}
            };
            ingridient.ForEach(i => context.Ingridients.Add(i));
            context.SaveChanges();

            var dietType = new List<TypeOfDiet>
            {
                new TypeOfDiet {Name = "Bezglutenowa", Description = "Dieta nie zawierająca produktów z glutenem"},
                new TypeOfDiet {Name = "Wysokobiałkowa", Description ="Dieta wysokobiałkowa, dedykowana sportowcom"},
                new TypeOfDiet {Name = "Detoks", Description ="Dieta oczyszczająca organizm"}
            };
            dietType.ForEach(dt => context.TypeOfDiets.Add(dt));
            context.SaveChanges();

            var mealType = new List<TypeOfMeal>
            {
                new TypeOfMeal {Name = "Śniadanie", Description ="Pierwsze śniadanie"},
                new TypeOfMeal {Name = "Przekąska", Description = "Można zjeść jako drugi lub czwarty posiłek"},
                new TypeOfMeal {Name = "Obiad"},
                new TypeOfMeal {Name = "Kolacja"}
            };
            mealType.ForEach(mt => context.TypeOfMeals.Add(mt));
            context.SaveChanges();

            var meal = new List<Meal>
            {
                new Meal {Name = "Ryż z kurczakiem", Description = "Ugotuj ryż, a kurczaka przygotuj na parze"},
                new Meal {Name = "Szklanka mleka i garść orzechów"}
            };
            meal.ForEach(m => context.Meals.Add(m));
            context.SaveChanges();

            var mealIngridient = new List<MealIngridient>
            {
                new MealIngridient {Name = "Torebka ryżu", Quantity = 100, Ingridient = ingridient[2] },
                new MealIngridient {Name ="Pierś z kurczaka", Quantity = 200, Ingridient = ingridient[3] },
                new MealIngridient {Name = "Szklanka mleka", Quantity = 250, Ingridient = ingridient[4] },
                new MealIngridient {Name = "Garść orzechów", Quantity = 35, Ingridient = ingridient[0] }
            };
            mealIngridient.ForEach(mi => context.MealIngridients.Add(mi));
            context.SaveChanges();

            var mealIngridientMeal = new List<MealIngridientMeal>
            {
                new MealIngridientMeal {Meal = meal[0], MealIngridient = mealIngridient[0]},
                new MealIngridientMeal {Meal = meal[0], MealIngridient = mealIngridient[1]},
                new MealIngridientMeal {Meal = meal[1], MealIngridient = mealIngridient[2]},
                new MealIngridientMeal {Meal = meal[1], MealIngridient = mealIngridient[3]}
            };
            mealIngridientMeal.ForEach(mim => context.MealIngridientMeals.Add(mim));
            context.SaveChanges();

            var roleId0 = user0.Roles.FirstOrDefault().RoleId;
            var roleId1 = user1.Roles.FirstOrDefault().RoleId;
            var roleId2 = user2.Roles.FirstOrDefault().RoleId;
            var roleId3 = user3.Roles.FirstOrDefault().RoleId;
            var user = new List<User>
            {
                new User { Email = user0.UserName, FirstName = "Kinga", Surname = "Mikołajczuk", DateOfBirth = new DateTime(1998,10,10), roleName = roleManager.Roles.FirstOrDefault(r => r.Id == roleId0).Name},
                new User { Email = user1.UserName, FirstName = "Anna", Surname = "Kowalska", DateOfBirth = new DateTime(1998,10,17), roleName = roleManager.Roles.FirstOrDefault(r => r.Id == roleId1).Name},
                new User { Email = user2.UserName, FirstName = "Jan", Surname = "Nowak", DateOfBirth = new DateTime(1990,12,1), roleName = roleManager.Roles.FirstOrDefault(r => r.Id == roleId2).Name},
                new User { Email = user3.UserName, FirstName = "Krzysztof", Surname = "Czajka", DateOfBirth = new DateTime(1995,7,20), roleName = roleManager.Roles.FirstOrDefault(r => r.Id == roleId3).Name}
                
            };
            user.ForEach(u => context.Users.Add(u));
            context.SaveChanges();


            var customerData = new List<CustomerData>
            {
                new CustomerData { Weight = 55, Growth = 165, DateOfMeasurement = DateTime.Parse("2020-10-12"), Customer = user[0] },
                new CustomerData { Weight = 50, Growth = 165, DateOfMeasurement = DateTime.Parse("2020-11-12"), Customer = user[0] },
                new CustomerData { Weight = 100, Growth = 184, DateOfMeasurement = DateTime.Parse("2020-09-03"), Customer = user[1] }
            };
            customerData.ForEach(cd => context.CustomerDatas.Add(cd));
            context.SaveChanges();

            var physicalActivity = new List<PhysicalActivity>
            {
                new PhysicalActivity { Name = "Bieganie", CaloriessBurned = 200, DateActivity = DateTime.Parse("2020-10-15"), Description="Bieganie na bieżni przez 30 minut", Customer = user[1]},
                new PhysicalActivity {Name = "Siłownia", CaloriessBurned = 400, DateActivity = DateTime.Parse("2020-09-10"), Customer = user[0]}
            };
            physicalActivity.ForEach(pa => context.PhysicalActivities.Add(pa));
            context.SaveChanges();

            var diet = new List<Diet>
            {
                new Diet { Name = "Wiosenna", EnergeticValue = 1800, DateStart = new DateTime(2020, 10, 11), Duration = 30, AdditionalWarning = "Przygotownie posiłków jest bardzo proste, polecam", DieticianRate = 1, DietRate = 5, TypeOfDiet = dietType[2], Customer = user[0], Dietician = user[2]},
                new Diet { Name = "Detoks", EnergeticValue = 1500, DateStart = new DateTime(2020, 11, 12), Duration = 7, DieticianOpinion = "świetny dietetyk, polecam", DieticianRate = 4, DietOpinion = "Bardzo smaczna", DietRate = 4, TypeOfDiet = dietType[2], Customer= user[1], Dietician = user[2]}
            };
            diet.ForEach(d => context.Diets.Add(d));
            context.SaveChanges();


            var dietMeal = new List<DietMeal>
            {
                new DietMeal { DateOfEating = DateTime.Parse("2020-10-20"), TypeOfMeal = mealType[1], Diet = diet[0], Meal = meal[1]},
                new DietMeal { DateOfEating = DateTime.Parse("2020-10-20"), TypeOfMeal = mealType[2], Diet = diet[0], Meal = meal[0]},
                new DietMeal { DateOfEating = DateTime.Parse("2020-11-12"), TypeOfMeal = mealType[2], Diet = diet[1], Meal = meal[0]}
            };
            dietMeal.ForEach(dm => context.DietMeals.Add(dm));
            context.SaveChanges();

            var mealOpinion = new List<MealOpinion>
            {
                new MealOpinion { MealRate = 3, DateOpinion = DateTime.Parse("2020-10-20"), Description = "Całkiem niezły", Customer = user[0], Meal = meal[0], DietMeal = dietMeal[0]}
            };
            mealOpinion.ForEach(mo => context.MealOpinions.Add(mo));
            context.SaveChanges();
        }
    }
}