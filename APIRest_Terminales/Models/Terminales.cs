using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIRest_Terminales.Models
{
    public class Terminales
    {
        [Key]
        public int Id_terminal { get; set; }
        [Required]

        [ForeignKey("Id_fab")]
        public Fabricantes Fabricantes { get; set; }

        [ForeignKey("Id_estado")]
        public Estado Estado { get; set; }

        public DateTime Fecha_fabricacion { get; set; }
        public DateTime Fecha_estado { get; set; }
        public String? Terminal_desc { get; set; }
        public String? Terminal_name { get; set; }
    }
}
