namespace Yearbook.Models
{
    public class Student
    {
        public int StudentID { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        //public IEnumerable<Picture> Pictures { get; set; }
        public string Link { get; set; }
        public string Gender { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
      
        public string State { get; set; }               //the state column itself
        public IEnumerable<State> States { get; set; }  //the dropdown with collection inside
        public string Email { get; set; }
        public string Hobbies { get; set; }
        public string FavoriteFood { get; set; }
        public string FavoriteSong { get; set; }
        public string FavoriteMovie { get; set; }
        public string FutureCareer { get; set; }
        public string Quote { get; set; }

    }
}
