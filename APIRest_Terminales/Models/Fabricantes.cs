using System.ComponentModel.DataAnnotations;

namespace APIRest_Terminales.Models
{
    public class Fabricantes
    {
        [Key]
        public int Id_fab { get; set; }
        [Required]

        public String Fab_name { get; set; }
        [Required]

        public String? Fab_desc { get; set; }
    }
}
