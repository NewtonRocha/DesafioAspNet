using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtonProject.Models
{
    /// <summary>
    /// Atividades Realizadas por uma Pessoa
    /// </summary>
    public class Atividade
    {
        //Identificador unico da atividade
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Name da atividade
        public string Nome { get; set; }

        //Descrição da atividade
        public string Descricao { get; set; }

        //Data de inicio da Atividade
        public DateTime? inicio { get; set; }

        //Data de Término da Atividade
        public DateTime? Termino { get; set; }
    }
}
