namespace Yearbook.Models
{
    public interface IStudentRepository 
    {
        public IEnumerable<Student> GetAllStudents();
        public IEnumerable<Student> SearchStudents(string searchString);
        public Student SelectState();  
        public IEnumerable<State> GetStates();
        public IEnumerable<Gender> GetGenders();
        public void CreateStudent(Student newStudent);
        public Student ViewStudent(int id);
        public void UpdateStudent(Student student);
        public void DeleteStudent(Student student);
        public void InsertImage(Student student);
        

    }
}
