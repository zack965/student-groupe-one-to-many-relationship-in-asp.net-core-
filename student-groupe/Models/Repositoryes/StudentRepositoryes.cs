using Microsoft.EntityFrameworkCore;
using student_groupe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_groupe.Models.Repositoryes
{
    public class StudentRepositoryes : IOperations<Student>
    {
        AppDbContext db;
        public StudentRepositoryes(AppDbContext _db)
        {
            db = _db;
        }
        public void Add(Student entity)
        {
            db.Students.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var std = Find(id);
            db.Students.Remove(std);
            db.SaveChanges();
        }

        public Student Find(int id)
        {
            return db.Students.Include(g => g.groupe).SingleOrDefault(s => s.Student_Id == id);
        }

        public IList<Student> List()
        {
            return db.Students.Include(g => g.groupe).ToList();
        }

        public IList<Student> ListSearch(int id)
        {
            return db.Students.Where(s => s.groupe.Groupe_Id == id).Include(g => g.groupe).ToList();
        }

        public List<Student> Search(string term)
        {
            return db.Students.Include(g => g.groupe).Where(x => x.Student_Full_Name.Contains(term)).ToList();
        }

    

        public void Update(int id,Student entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
