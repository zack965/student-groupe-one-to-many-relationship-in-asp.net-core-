using student_groupe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_groupe.Models.Repositoryes
{
    public class GroupeRepository : IOperations<Groupe>
    {
        AppDbContext db;
        public GroupeRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void Add(Groupe entity)
        {
            db.Groupes.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var gr = Find(id);
            db.Groupes.Remove(gr);
            db.SaveChanges();

        }

        public Groupe Find(int id)
        {
            return db.Groupes.SingleOrDefault(x => x.Groupe_Id == id);
        }

        public IList<Groupe> List()
        {
            return db.Groupes.ToList();
        }

        public List<Groupe> Search(string term)
        {
            return db.Groupes.Where(x => x.Groupe_Name.Contains(term)).ToList();
        }
        
        public List<Student> ListSearchById(int id)
        {
            return db.Students.Where(s => s.groupe.Groupe_Id == id).ToList();
        }
         

        public void Update(int id,Groupe entity)
        {
            db.Groupes.Update(entity);
            db.SaveChanges();
        }

        public IList<Groupe> ListSearch(int id)
        {
            return db.Groupes.Where(s => s.Groupe_Id == id).ToList();
        }
    }
}
