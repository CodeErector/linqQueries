using System.ComponentModel.DataAnnotations;

namespace linqQueries.Model
{
    public class Enrolled
    {
        [Key]
        public int eid { get; set; }
        public int fid { get; set; }
        public int sid { get; set; }
        public int cid { get; set; }

        public virtual IList<Student>? students { get; set; }
        public virtual Faculty? faculty { get; set; }
        public virtual Class? cls { get; set; }
    }
}
