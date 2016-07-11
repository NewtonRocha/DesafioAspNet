using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtonProject.Models
{
    /// <summary>
    /// Model de Cliente
    /// </summary>
    public class Cliente
    {
        //identificador único de cliente
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Name do cliente
        public string Name { get; set; }
    }
}
