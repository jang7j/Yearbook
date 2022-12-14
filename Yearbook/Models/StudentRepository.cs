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
            _conn.Execute("INSERT INTO Student (StudentID, FirstName, LastName, Image, Gender, State, Email, Hobbies, FavoriteFood, FavoriteSong, FavoriteMovie, FutureCareer, Quote) VALUES (@StudentID, @FirstName, @LastName, @Image, @Gender, @State, @Email, @Hobbies, @FavoriteFood, @FavoriteSong, @FavoriteMovie, @FutureCareer, @Quote);",
                new {studentid = newStudent.StudentID, firstname = newStudent.FirstName, lastname = newStudent.LastName, image = newStudent.Image, gender = newStudent.Gender, state = newStudent.State, email = newStudent.Email, hobbies = newStudent.Hobbies, favoritefood = newStudent.FavoriteFood, favoritesong = newStudent.FavoriteSong, favoritemovie = newStudent.FavoriteMovie, futurecareer = newStudent.FutureCareer, quote = newStudent.Quote } );
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
      
        
        public void UpdateStudent(Student student)
        {
            _conn.Execute("UPDATE STUDENT SET firstName = @firstName, lastName = @lastName, Image = @image, Gender = @gender, State = @state, Email = @email, Hobbies = @hobbies, FavoriteFood = @favoritefood, FavoriteSong = @favoritesong, FavoriteMovie = @favoritemovie, FutureCareer = @futurecareer, Quote = @quote WHERE StudentID = @studentid;",
                new { studentid = student.StudentID, firstname = student.FirstName, lastname = student.LastName, image = student.Image, gender= student.Gender, state = student.State, email = student.Email, hobbies = student.Hobbies, favoritefood = student.FavoriteFood, favoritesong = student.FavoriteSong, favoritemovie= student.FavoriteMovie, futurecareer = student.FutureCareer, quote = student.Quote });
        }

        public Student ViewStudent(int id)
        {
            return _conn.QuerySingle<Student>("SELECT * FROM STUDENT WHERE StudentID = @studentid;", new { studentid = id });
        }
        public void DeleteStudent(Student studentName)
        {
            _conn.Execute("DELETE FROM STUDENT WHERE STUDENTID = @STUDENTID;", new { studentid = studentName.StudentID });
        }

        public void InsertImage(Student student)
        {
            _conn.Execute("UPDATE STUDENT SET IMAGE = @image WHERE STUDENTID = @studentid;",
                new { image = student.Image, studentid = student.StudentID });
        }

        public IEnumerable<Student> SearchStudents(string searchString)
        {
            return _conn.Query<Student>("Search * from student where name like @name;",
                new { name = "%" + searchString + "%" });
        }

        
    }

}
