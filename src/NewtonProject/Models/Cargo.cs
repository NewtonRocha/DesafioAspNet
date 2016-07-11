using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtonProject.Models
{
    /// <summary>
    /// Cargo que uma Pessoa pode assumir 
    /// </summary>
    public class Cargo
    {
        //Identificador unico do cargo
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Name do cargo
        public string Nome { get; set; }

        //Descrição do cargo
        public string Descricao { get; set; }

        //Cliente associado ao cargo
        public Cliente Cliente { get; set; }
    }
}
