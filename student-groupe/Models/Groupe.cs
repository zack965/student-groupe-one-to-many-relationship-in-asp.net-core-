using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace student_groupe.Models
{
    public class Groupe
    {
        [Key]
        public int Groupe_Id { get; set; }
        public string Groupe_Name { get; set; }

        //public ICollection<Student> students { get; set; }
    }
}
