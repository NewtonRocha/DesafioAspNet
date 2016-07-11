using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewtonProject.Models;
using NewtonProject.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NewtonProject.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
        //Repositorio de Pessoas
        private IRepository<Pessoa> Pessoas { get; set; }

        public PessoaController(IRepository<Pessoa> pessoas)
        {
            this.Pessoas = pessoas;
        }

        // GET: api/pessoa
        // Retorna todas as pessoas
        [HttpGet]
        public IEnumerable<Pessoa> GetAll()
        {
            return this.Pessoas.GetAll();
        }

        // GET api/pessoa/5
        // Retorna uma pessoa especifica
        [HttpGet("{id}", Name = "GetPessoa")]
        public IActionResult GetById(int id)
        {
            var item = this.Pessoas.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // GET api/pessoa/customer/5
        // Retorna todas as pessoas de um cliente especifico
        [HttpGet("customer/{id}", Name = "GetPessoaByCustomer")]
        public IActionResult GetByCustomerId(int id)
        {
            var item = this.Pessoas.GetAllById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/pessoa
        // Adiciona uma nova pessoa
        [HttpPost]
        public IActionResult Create([FromBody]Pessoa item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            item = this.Pessoas.Add(item);
            return CreatedAtRoute("GetPessoa", new { Controller = "Pessoa", id = item.Id }, item);
        }

        // PUT api/pessoa/5
        // Atualiza uma pessoa
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Pessoa item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var pessoa = this.Pessoas.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            
            pessoa.Nome = item.Nome;
            pessoa.Atividades = null;
            pessoa.Atividades = item.Atividades;
            pessoa.Cargo = item.Cargo;
            pessoa.Demissao = item.Demissao;
            pessoa.Perfil = item.Perfil;
            pessoa.Cliente = item.Cliente;
            this.Pessoas.Update(pessoa);
            return new NoContentResult();
        }

        // DELETE api/pessoa/5
        // Deleta uma pessoa
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Pessoas.Remove(id);
        }
    }
}
