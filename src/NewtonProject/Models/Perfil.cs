using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtonProject.Models
{
    /// <summary>
    /// Perfil de pessoa
    /// </summary>
    public class Perfil
    {
        //Identificador unico de perfil
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Name do perfil
        public string Nome { get; set; }
    }
}
