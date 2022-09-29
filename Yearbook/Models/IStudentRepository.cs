namespace Yearbook.Models
{
    public interface IStudentRepository 
    {
        public IEnumerable<Student> GetAllStudents();
        public Student SelectState();  
        public IEnumerable<State> GetStates();
        public IEnumerable<Gender> GetGenders();
        public void CreateStudent(Student newStudent);
        public Student ViewStudent(int id);
        public void UpdateStudent(Student student);
        public void InsertPicture(Student student);
        public void DeleteStudent(Student student);

    }
}
