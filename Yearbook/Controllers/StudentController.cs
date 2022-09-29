using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Yearbook.Models;

namespace Yearbook.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository repo;

        public StudentController(IStudentRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var students = repo.GetAllStudents();
            return View(students);
        }

        public IActionResult ViewStudent(int id)
        {
            var student = repo.ViewStudent(id);
            return View(student);
        } 
        public IActionResult UpdateStudent(int id)
        {
            Student stud = repo.ViewStudent(id);
            if (stud == null)
            {
                return View("Student not found");
            }
            return View(stud);
        }
        public IActionResult UpdateStudentToDatabase(Student student)
        {
            repo.UpdateStudent(student);
            return RedirectToAction("ViewStudent", new { id = student.StudentID });
        }

        public IActionResult CreateStudent()
        {
            var newStud = repo.SelectState();
            return View(newStud);
        }

        public IActionResult CreateStudentToDatabase(Student newStudent)
        {
            repo.CreateStudent(newStudent);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteStudent(Student student)
        {
            repo.DeleteStudent(student);
            return RedirectToAction("Index");
        }
        //public IActionResult UploadButtonClick(IFormFile files, Student student)
        //{
        //    if (files != null)
        //    {
        //        if (files.Length > 0)
        //        {
        //            var fileName = Path.GetFileName(files.FileName);
        //            var unqiueFileName = Convert.ToString(Guid.NewGuid());
        //            var fileExtension = Path.GetExtension(fileName);
        //            var newFileName = String.Concat(uniqueFileName, fileExtension);
        //            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "picture")).Root + $@"{newFileName}";
        //            using (FileStream fs = System.I0.File.Create(filepath))
        //            {
        //                files.CopyTo(fs);
        //                fs.Flush();
        //            }
        //            student.picture = "/picture/" + newFileName;
        //            repo.InsertPicture(student);
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
