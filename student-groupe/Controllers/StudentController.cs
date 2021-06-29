using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_groupe.Models;
using student_groupe.Models.Repositoryes;
using student_groupe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_groupe.Controllers
{
    public class StudentController : Controller
    {
        private readonly IOperations<Student> studentRepositoryes;
        private readonly IOperations<Groupe> groupeRepository;

        public StudentController(IOperations<Student> _StudentRepositoryes, IOperations<Groupe> _groupeRepository)
        {
            studentRepositoryes = _StudentRepositoryes;
            groupeRepository = _groupeRepository;
        }
        // GET: StudentController
        public ActionResult ListStudents()
        {
            return View(studentRepositoryes.List());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(studentRepositoryes.Find(id));
        }

        // GET: StudentController/Create
        public ActionResult Create_Student()
        {
            var model = new  StudentGroupeViewModel{
                Groupes = groupeRepository.List().ToList()
            };
            return View(model);
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Student(StudentGroupeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var grp = groupeRepository.Find(model.Groupe_Id);
                Student std = new Student
                {
                    Student_Full_Name = model.Student_Full_Name,
                    Student_Filiere = model.Student_Filiere,
                    groupe = grp
                };
                studentRepositoryes.Add(std);
                return RedirectToAction(nameof(ListStudents));

            }
            return View();
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit_Student(int id)
        {
            var std = studentRepositoryes.Find(id);
            var model = new StudentGroupeViewModel
            {
                Student_Full_Name = std.Student_Full_Name,
                Student_Filiere = std.Student_Filiere,
                Groupe_Id =std.groupe.Groupe_Id,
                Groupes = groupeRepository.List().ToList()
            };
            return View(model);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Student(int id,StudentGroupeViewModel model)
        {
            try
            {

                var groupe = groupeRepository.Find(model.Groupe_Id);
                Student std = new Student
                {
                    Student_Id = id,
                    Student_Full_Name = model.Student_Full_Name,
                    Student_Filiere = model.Student_Filiere,
                    groupe = groupe
                };
                studentRepositoryes.Update(id, std);
                return RedirectToAction(nameof(ListStudents));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete_Student(int id)
        {
            return View(studentRepositoryes.Find(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_Student(int id, IFormCollection collection)
        {
            try
            {
                studentRepositoryes.Delete(id);
                return RedirectToAction(nameof(ListStudents));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult GetStudents(int id)
        {

            return View(studentRepositoryes.ListSearch(id));
        }
    }
}
