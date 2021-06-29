using Microsoft.AspNetCore.Mvc;
using student_groupe.Models;
using student_groupe.Models.Repositoryes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_groupe.Controllers
{
    public class GroupeController : Controller
    {
        private readonly IOperations<Groupe> GroupeRepository;
        private readonly IOperations<Student> studentRepositoryes;

        public GroupeController(IOperations<Groupe> groupeRepository, IOperations<Student> _StudentRepositoryes)
        {
            GroupeRepository = groupeRepository;
            studentRepositoryes = _StudentRepositoryes;
        }
        [HttpGet]
        public IActionResult ListGroupes()
        {
            return View(GroupeRepository.List());
        }
        [HttpGet]
        public IActionResult DetailsGroupe(int id)
        {
            return View(GroupeRepository.Find(id));
        }
        [HttpGet]
        public IActionResult CreateGroupe()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGroupe(Groupe gr)
        {
            if (ModelState.IsValid)
            {
                GroupeRepository.Add(gr);
                return RedirectToAction("ListGroupes");
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateGroupe(int id)
        {
            return View(GroupeRepository.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateGroupe(int id,Groupe gr)
        {
            if (ModelState.IsValid)
            {
                GroupeRepository.Update(id,gr);
                return RedirectToAction("ListGroupes");
            }
            return View();
        }
        [HttpGet]
        public IActionResult DeleteGroupe(int id)
        {
            return View(GroupeRepository.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteGroupe(int id,Groupe gr)
        {
            if (ModelState.IsValid)
            {
                GroupeRepository.Delete(id);
                return RedirectToAction("ListGroupes");
            }
            return View();
        }
        

    }
}
