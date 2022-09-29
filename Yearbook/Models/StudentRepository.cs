using Dapper;
using System.Data;

namespace Yearbook.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _conn;

        public StudentRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return _conn.Query<Student>("SELECT * FROM STUDENT ORDER BY FIRSTNAME ASC;");
        }


        public void CreateStudent(Student newStudent)
        {
            _conn.Execute("INSERT INTO Student (FirstName, LastName, Picture, Gender, State, Email, Hobbies, FavoriteFood, FavoriteSong, FavoriteMovie, FutureCareer, Quote) VALUES (@FirstName, @LastName, @Picture, @Gender, @State, @Email, @Hobbies, @FavoriteFood, @FavoriteSong, @FavoriteMovie, @FutureCareer, @Quote);",
                new {newStudent.FirstName, newStudent.LastName, newStudent.Picture, newStudent.Gender, newStudent.State, newStudent.Email, newStudent.Hobbies, newStudent.FavoriteFood, newStudent.FavoriteSong, newStudent.FavoriteMovie, newStudent.FutureCareer, newStudent.Quote } );
        }

        public Student SelectState()
        {
            var stateList = GetStates();
            var student = new Student();
            student.States = stateList;
            student.Genders = GetGenders();
            return student;
            
        }
             
        public IEnumerable<State> GetStates()
        {
            return _conn.Query<State>("SELECT * FROM STATE;");
        }

        public IEnumerable<Gender> GetGenders()
        {
            return _conn.Query<Gender>("select * from gender;" );
        }
      
        public void InsertPicture(Student student)
        {
            _conn.Execute("UPDATE STUDENT SET PICTURE = @picture WHERE STUDENTNAME = @studentname;",
                new { studentname = student.FirstName });
        }

        public void UpdateStudent(Student student)
        {
            _conn.Execute("UPDATE STUDENT SET StudentName = @StudentName, Picture = @picture, Gender = @gender, States = @state, Email = @email, Hobbies = @hobbies, FavoriteFood = @favoritefood, FavoriteSong = @favoritesong, FavoriteMovie = @favoritemovie, FutureCareer = @futurecareer, Quote = @quote;",
                new { studentname = student.FirstName });
        }

        public Student ViewStudent(int id)
        {
            return _conn.QuerySingle<Student>("SELECT * FROM STUDENT WHERE StudentID = @studentid;", new { studentid = id });
        }
        public void DeleteStudent(Student studentName)
        {
            _conn.Execute("DELETE FROM STUDENT WHERE STUDENTNAME= @STUDENTNAME;", new { studentname = studentName.FirstName });
        }

        
    }

}
