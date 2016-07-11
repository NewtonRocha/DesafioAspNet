using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NewtonProject.Models;
using NewtonProject.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NewtonProject.Controllers
{
    [Route("api/[controller]")]
    public class AtividadeController : Controller
    {
        //Repositorio de atividades
        private IRepository<Atividade> Atividades { get; set; }

        public AtividadeController(IRepository<Atividade> atividades)
        {
            this.Atividades = atividades;
        }

        // GET: api/atividade
        //Retorna todas as atividades
        [HttpGet]
        public IEnumerable<Atividade> GetAll()
        {
            return this.Atividades.GetAll();
        }

        // GET api/atividade/5
        //Retorna uma atividade especifica
        [HttpGet("{id}", Name = "GetAtividade")]
        public IActionResult GetById(int id)
        {
            var item = this.Atividades.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // GET api/atividade/user/5
        //Retorna atividades de uma pessoa especifica
        [HttpGet("user/{userId}", Name = "GetAtividadeByUser")]
        public IActionResult GetByUserId(int id)
        {
            var item = this.Atividades.GetAllById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/atividade
        //Cria uma atividade
        [HttpPost]
        public IActionResult Create([FromBody]Atividade item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            item = this.Atividades.Add(item);
            return CreatedAtRoute("GetAtividade", new {Controller = "Atividade", id = item.Id}, item);
        }

        // PUT api/atividade/5
        //Atualiza uma atividade
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Atividade item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var atividade = this.Atividades.Find(id);
            if (atividade == null)
            {
                return NotFound();
            }

            atividade.Descricao = item.Descricao;
            atividade.Nome = item.Nome;
            atividade.Termino = item.Termino;
            atividade.inicio = item.inicio;
            this.Atividades.Update(atividade);
            return new NoContentResult();
        }

        // DELETE api/values/5
        //Deleta uma atividade
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Atividades.Remove(id);
        }
    }
}
