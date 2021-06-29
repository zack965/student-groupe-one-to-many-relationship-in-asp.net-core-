using Microsoft.EntityFrameworkCore;
using student_groupe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using student_groupe.ViewModel;

namespace student_groupe.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<student_groupe.ViewModel.StudentGroupeViewModel> StudentGroupeViewModel { get; set; }
    }
}
