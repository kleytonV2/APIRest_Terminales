using System.ComponentModel.DataAnnotations;

namespace APIRest_Terminales.Models
{
    public class Estado
    {
        [Key]
        public int Id_estado { get; set; }
        [Required]

        public String Estado_name { get; set; }
        [Required]

        public String? Estado_desc { get; set; }
    }
}
