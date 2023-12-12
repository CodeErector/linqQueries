using System.ComponentModel.DataAnnotations;

namespace linqQueries.Model
{
    public class Enrolled
    {
        [Key]
        public int eid { get; set; }

        public virtual IList<Student>? students { get; set; }
        public virtual IList<Class>? classes { get; set; }
    }
}
