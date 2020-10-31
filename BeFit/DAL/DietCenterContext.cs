using BeFit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeFit.DAL
{
    public class DietCenterContext : DbContext
    {
        public DietCenterContext() : base("DefaultConnection")
        {

        }
        public DbSet<CustomerData> CustomerDatas { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<DietMeal> DietMeals { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealIngridient> MealIngridients { get; set; }
        public DbSet<MealOpinion> MealOpinions { get; set; }
        public DbSet<PhysicalActivity> PhysicalActivities { get; set; }
        public DbSet<TypeOfDiet> TypeOfDiets { get; set; }
        public DbSet<TypeOfMeal> TypeOfMeals { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealOpinion>().HasRequired<DietMeal>(mp => mp.DietMeal).WithOptional(dm => dm.MealOpinion).WillCascadeOnDelete(false);
        }

    }
}