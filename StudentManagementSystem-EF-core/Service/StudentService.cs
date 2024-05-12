using StudentManagementSystem_EF_core.Data;
using StudentManagementSystem_EF_core.ModelEntity;

namespace StudentManagementSystem_EF_core.Service
{
    public class StudentService:IStudent
    {
        public readonly DbContextClass _dbContextClass;
        public StudentService(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }
        public List<Student> GetAllStudents()
        {
            var STD=_dbContextClass.student.ToList();
            return STD;
        }
        public Student GetStudentById(int id)
        {
            var GetIdStd = _dbContextClass.student.FirstOrDefault(x => x.StudentId == id);
            return GetIdStd;
        }
        public List<Student> FilterStudentByAge(int age)
        {
            var FilterStd = _dbContextClass.student.Where(v => v.StudentAge > age);
            return FilterStd.ToList();
        }
        public List<Student> SearchStudentByName(string name)
        {
            var FindStudent = _dbContextClass.student.Where(n => n.StudentName.StartsWith(name));
            return FindStudent.ToList();
        }
        public void AddStudent(Student student)
        {
            _dbContextClass.student.Add(student);
            _dbContextClass.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            var UpdateStudent = _dbContextClass.student.FirstOrDefault(i => i.StudentId == student.StudentId);
            if (UpdateStudent != null)
            {
                UpdateStudent.StudentName = student.StudentName;
                UpdateStudent.StudentAge = student.StudentAge;
            }        
            _dbContextClass.SaveChanges();
        }
        public void UpdateAge(int id, int age)
        {
            var FindId = _dbContextClass.student.FirstOrDefault(i => i.StudentId == id);
            if (FindId != null)
            {
                FindId.StudentAge = age;

            }
            _dbContextClass.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var FindId = _dbContextClass.student.FirstOrDefault(i => i.StudentId == id);
            if (FindId != null)
            {
                _dbContextClass.Remove(FindId);

            }
            _dbContextClass.SaveChanges();
        }
    }
}
