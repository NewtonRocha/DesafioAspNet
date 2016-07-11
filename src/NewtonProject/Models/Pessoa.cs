using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtonProject.Models
{
    /// <summary>
    /// Model de Pessoa
    /// </summary>
    public class Pessoa
    {
        // Identificador de Pessoa
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Name da Pessoa
        public string Nome { get; set; }

        //Cargo da Pessoa
        public Cargo Cargo { get; set; }

        //Data de nascimento da Pessoa
        public DateTime Nascimento { get; set; }

        //Data de admissão da Pessoa
        public DateTime Admissao { get; set; }

        //Data de Demissão da Pessoa
        public DateTime? Demissao { get; set; }

        //Tipo de Perfil
        public Perfil Perfil { get; set; }

        //Atividades da Pessoa
        public ICollection<Atividade> Atividades { get; set; }

        //Cliente associado a pessoa
        public Cliente Cliente { get; set; }

    }
}
