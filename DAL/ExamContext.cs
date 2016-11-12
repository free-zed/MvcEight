using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcEight.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcEight.DAL
{
    public class ExamContext : DbContext
    {
        public ExamContext() : base("ExamContext")
        {

        }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Bengali> Bengalis { get; set; }
        public DbSet<English> Englishs { get; set; }
        public DbSet<BengaliTwo> BengaliTwos { get; set; }
        public DbSet<EnglishTwo> EnglishTwo { get; set; }
        public DbSet<BengaliThree> BengaliThree { get; set; }
        public DbSet<EnglishThree> EnglishThree { get; set; }
        public DbSet<BengaliFour> BengaliFours { get; set; }
        public DbSet<EnglishFour> EnglishFours { get; set; }
        public DbSet<BengaliOneFive> BengaliOneFives { get; set; }
        public DbSet<BengaliTwoFive> BengaliTwoFive { get; set; }
        public DbSet<EnglishOneFive> EnglishOneFives { get; set; }
        public DbSet<EnglishTwoFive> EnglishTwoFives { get; set; }
        public DbSet<BengaliOneSix> BengaliOneSixs { get; set; }
        public DbSet<BengaliTwoSix> BengaliTwoSixs { get; set; }
        public DbSet<EnglishOneSix> EnglishOneSixs { get; set; }
        public DbSet<EnglishTwoSix> EnglishTwoSixs { get; set; }
        public DbSet<BengaliOneSeven> BengaliOneSevens { get; set; }
        public DbSet<BengaliTwoSeven> BengaliTwoSevens { get; set; }
        public DbSet<EnglishOneSeven> EnglishOneSevens { get; set; }
        public DbSet<EnglishTwoSeven> EnglishTwoSevens { get; set; }
        public DbSet<BengaliOneEight> BengaliOneEights { get; set; }
        public DbSet<BengaliTwoEight> BengaliTwoEights { get; set; }
        public DbSet<EnglishOneEight> EnglishOneEights { get; set; }
        public DbSet<EnglishTwoEight> EnglishTwoEights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        
    }
}