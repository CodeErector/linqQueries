using System.ComponentModel.DataAnnotations;

namespace linqQueries.Model
{
    public class Student
    {
        [Key]
        public int sid { get; set; }    
        public string? sname { get; set; }
        public string? major { get; set; }
        public string? standing { get; set; }
        public int age { get; set; }
        public int marks { get; set; }
    }
}
