using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem_EF_core.ModelEntity
{
    public class Student
    {
        [Key]
        public int StudentId {  get; set; }
        public string StudentName { get; set;}
        public int StudentAge { get; set;}
    }
}
