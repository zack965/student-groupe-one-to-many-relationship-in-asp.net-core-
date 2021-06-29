using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace student_groupe.Models
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }
        public string Student_Full_Name { get; set; }
        public string Student_Filiere { get; set; }
        //public int Groupe_Id { get; set; }
        public Groupe groupe { get; set; }
    }
}
