using System.ComponentModel.DataAnnotations;

namespace linqQueries.Model
{
    public class Faculty
    {
        [Key]
        public int fid { get; set; }
        public string? fname { get; set; }
        public string? standing { get; set;}

        public int depid { get; set; }
    }
}
