using System.ComponentModel.DataAnnotations;

namespace linqQueries.Model
{
    public class Depart
    {
        [Key]
        public int depid { get; set; }
        public string? dName { get; set; }
    }
}
