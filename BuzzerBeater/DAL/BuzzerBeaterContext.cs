using BuzzerBeater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BuzzerBeater.DAL
{
    public class BuzzerBeaterContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //teacher >> classes >> students
            //teacher >> tests >> questions

            //modelBuilder.Entity<Class>().HasMany(a => a.Students).WithOptional().WillCascadeOnDelete();
            //modelBuilder.Entity<Teacher>().HasMany(a => a.Classes).WithOptional().WillCascadeOnDelete();

            //modelBuilder.Entity<Question>().HasRequired(a => a.Test).WithRequiredDependent().WillCascadeOnDelete();
            //modelBuilder.Entity<Teacher>().HasMany(a => a.Tests).WithOptional().WillCascadeOnDelete();

        }

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public BuzzerBeaterContext() : base("name=BuzzerBeaterContext")
        {
        }

        public DbSet<School> Schools { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<TestHistory> TestHistories { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Test> Tests { get; set; }

    }
}