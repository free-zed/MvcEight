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
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        
    }
}